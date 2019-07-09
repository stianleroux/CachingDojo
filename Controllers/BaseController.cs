using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CachingDojo.Data;
using CachingDojo.Definitions;
using Microsoft.Extensions.Caching.Distributed;
using CachingDojo;
using LazyCache;

namespace CachingDojo.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public abstract class EntityControllerBase<TEntity, TReadModel, TCreateModel, TUpdateModel> : ControllerBase
        where TEntity : class, IHaveIdentifier
    {
        private readonly IAppCache _cache;

        protected EntityControllerBase(IAppCache appCache, CachingDojoContext dataContext, IMapper mapper)
        {
            _cache = appCache;
            DataContext = dataContext;
            Mapper = mapper;
        }


        protected CachingDojoContext DataContext { get; }

        protected IMapper Mapper { get; }


        protected virtual async Task<TReadModel> ReadModel(int id, CancellationToken cancellationToken = default(CancellationToken))
        {
            var model = await DataContext
               .Set<TEntity>()
               .AsNoTracking()
               .Where(p => p.Id == id)
               .ProjectTo<TReadModel>(Mapper.ConfigurationProvider)
               .FirstOrDefaultAsync(cancellationToken);

            return model;
        }

        protected virtual async Task<TReadModel> CreateModel(TCreateModel createModel, CancellationToken cancellationToken = default(CancellationToken))
        {
            // create new entity from model
            var entity = Mapper.Map<TEntity>(createModel);

            // add to data set, id should be generated
            await DataContext
                .Set<TEntity>()
                .AddAsync(entity, cancellationToken);

            // save to database
            await DataContext
                .SaveChangesAsync(cancellationToken);

            // convert to read model
            var readModel = await ReadModel(entity.Id, cancellationToken);

            return readModel;
        }

        protected virtual async Task<TReadModel> UpdateModel(int id, TUpdateModel updateModel, CancellationToken cancellationToken = default(CancellationToken))
        {
            var keyValue = new object[] { id };

            // find entity to update by id, not model id
            var entity = await DataContext
                .Set<TEntity>()
                .FindAsync(keyValue, cancellationToken);

            if (entity == null)
                return default(TReadModel);

            // copy updates from model to entity
            Mapper.Map(updateModel, entity);

            // save updates
            await DataContext
                .SaveChangesAsync(cancellationToken);

            // return read model
            var readModel = await ReadModel(id, cancellationToken);

            return readModel;
        }

        protected virtual async Task<TReadModel> DeleteModel(int id, CancellationToken cancellationToken = default(CancellationToken))
        {
            var dbSet = DataContext
                .Set<TEntity>();

            var keyValue = new object[] { id };

            // find entity to delete by id
            var entity = await dbSet
                .FindAsync(keyValue, cancellationToken);

            if (entity == null)
                return default(TReadModel);

            // return read model
            var readModel = await ReadModel(id, cancellationToken);

            // delete entry
            dbSet.Remove(entity);

            // save 
            await DataContext
                .SaveChangesAsync(cancellationToken);

            return readModel;
        }

        protected virtual async Task<IReadOnlyList<TReadModel>> QueryModel(Expression<Func<TEntity, bool>> predicate = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            Func<Task<IReadOnlyList<TReadModel>>> showObjectFactory = () => PopulateShowsCache();
            var retVal = await _cache.GetOrAddAsync($"{typeof(TReadModel).FullName}.List", showObjectFactory, DateTimeOffset.Now.AddHours(8));
            return retVal;
        }

        private async Task<IReadOnlyList<TReadModel>> PopulateShowsCache(Expression<Func<TEntity, bool>> predicate = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            var dbSet = DataContext
                .Set<TEntity>();

            var query = dbSet.AsNoTracking();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            var results = await query
                  .ProjectTo<TReadModel>(Mapper.ConfigurationProvider)
                  .ToListAsync(cancellationToken);

            return results;
        }
    }
}

