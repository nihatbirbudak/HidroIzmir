using HI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HI.DAL.Seed
{
    internal class ProductSeed : IEntityTypeConfiguration<Product>
    {

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(new List<Product> {
                new Product { Id = 1,Name="Hidrolik Silindir",Title="Hidrolik silindir başlık",Content1="Hidrolik silindir içerikleri ve daha fazlası",Content2="Hidrolik silindir içerikleri 2",Active=true,CategoryId=1},
                new Product { Id = 2,Name="Hidrolik Silindir",Title="Hidrolik silindir başlık",Content1="Hidrolik silindir içerikleri ve daha fazlası",Content2="Hidrolik silindir içerikleri 2",Active=false,CategoryId=2},
                new Product { Id = 3,Name="Hidrolik Silindir",Title="Hidrolik silindir başlık",Content1="Hidrolik silindir içerikleri ve daha fazlası",Content2="Hidrolik silindir içerikleri 2",Active=true,CategoryId=3},
            });
        }
    }
}

