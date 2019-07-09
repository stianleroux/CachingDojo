using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CachingDojo.Data.Queries
{
    public static partial class CompanyExtensions
    {
        #region Generated Extensions
        public static CachingDojo.Data.Entities.Company GetByKey(this IQueryable<CachingDojo.Data.Entities.Company> queryable, int id)
        {
            if (queryable is DbSet<CachingDojo.Data.Entities.Company> dbSet)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(q => q.Id == id);
        }

        public static Task<CachingDojo.Data.Entities.Company> GetByKeyAsync(this IQueryable<CachingDojo.Data.Entities.Company> queryable, int id)
        {
            if (queryable is DbSet<CachingDojo.Data.Entities.Company> dbSet)
                return dbSet.FindAsync(id);

            return queryable.FirstOrDefaultAsync(q => q.Id == id);
        }

        #endregion

    }
}
