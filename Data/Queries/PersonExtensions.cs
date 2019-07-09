using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CachingDojo.Data.Queries
{
    public static partial class PersonExtensions
    {
        #region Generated Extensions
        public static CachingDojo.Data.Entities.Person GetByKey(this IQueryable<CachingDojo.Data.Entities.Person> queryable, int id)
        {
            if (queryable is DbSet<CachingDojo.Data.Entities.Person> dbSet)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(q => q.Id == id);
        }

        public static Task<CachingDojo.Data.Entities.Person> GetByKeyAsync(this IQueryable<CachingDojo.Data.Entities.Person> queryable, int id)
        {
            if (queryable is DbSet<CachingDojo.Data.Entities.Person> dbSet)
                return dbSet.FindAsync(id);

            return queryable.FirstOrDefaultAsync(q => q.Id == id);
        }

        #endregion

    }
}
