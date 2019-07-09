using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CachingDojo.Data.Mapping
{
    public partial class CompanyMap
        : IEntityTypeConfiguration<CachingDojo.Data.Entities.Company>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<CachingDojo.Data.Entities.Company> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("Company", "dbo");

            // key
            builder.HasKey(t => t.Id);

            // properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.CompanyMember)
                .IsRequired()
                .HasColumnName("Company")
                .HasColumnType("varchar(150)")
                .HasMaxLength(150);

            builder.Property(t => t.PersonId)
                .IsRequired()
                .HasColumnName("PersonId")
                .HasColumnType("int");

            builder.Property(t => t.DateCreated)
                .IsRequired()
                .HasColumnName("DateCreated")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            builder.Property(t => t.Active)
                .IsRequired()
                .HasColumnName("Active")
                .HasColumnType("bit")
                .HasDefaultValueSql("((1))");

            // relationships
            builder.HasOne(t => t.Person)
                .WithOne(t => t.Company)
                .HasForeignKey<CachingDojo.Data.Entities.Company>(d => d.Id)
                .HasConstraintName("FK_Companies_Person");

            #endregion
        }

    }
}
