using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CachingDojo.Data.Mapping
{
    public partial class PersonMap
        : IEntityTypeConfiguration<CachingDojo.Data.Entities.Person>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<CachingDojo.Data.Entities.Person> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("Person", "dbo");

            // key
            builder.HasKey(t => t.Id);

            // properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("varchar(150)")
                .HasMaxLength(150);

            builder.Property(t => t.Surname)
                .IsRequired()
                .HasColumnName("Surname")
                .HasColumnType("varchar(150)")
                .HasMaxLength(150);

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
            #endregion
        }

    }
}
