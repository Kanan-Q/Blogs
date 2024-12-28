using BlogMain.Entites.Category;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogDAL.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasIndex(x => x.Name).IsUnique();
            builder.Property(x=>x.Name).IsRequired().HasMaxLength(32);
            builder.Property(x=>x.Icon).IsRequired().HasMaxLength(128);
        }
    }
}
