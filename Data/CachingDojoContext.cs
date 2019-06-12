using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CachingDojo.Data
{
    public partial class CachingDojoContext : DbContext
    {
        public CachingDojoContext(DbContextOptions<CachingDojoContext> options)
            : base(options)
        {
        }

        #region Generated Properties
        public virtual DbSet<CachingDojo.Data.Entities.Company> Companies { get; set; }

        public virtual DbSet<CachingDojo.Data.Entities.Person> People { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Generated Configuration
            modelBuilder.ApplyConfiguration(new CachingDojo.Data.Mapping.CompanyMap());
            modelBuilder.ApplyConfiguration(new CachingDojo.Data.Mapping.PersonMap());
            #endregion
        }
    }
}
