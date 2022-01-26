using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_Cubits.Data.Models;

namespace WebApp_Cubits.Data.Mappings
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(p => p.Id);

            builder.HasOne(c => c.Category)
                .WithMany(p => p.ProductList)
                .HasForeignKey(p => p.CategoryId);

            builder.HasOne(p => p.Provider)
                .WithMany(p => p.ProductList)
                .HasForeignKey(p => p.ProviderId);
        }
    }
}
