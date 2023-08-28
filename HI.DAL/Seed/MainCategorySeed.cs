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
    internal class MainCategorySeed : IEntityTypeConfiguration<MainCategory>
    {
        public void Configure(EntityTypeBuilder<MainCategory> builder)
        {
            builder.HasData(new List<MainCategory>
            {
                new MainCategory {Id=1,Name="Hidrolik Bağlantı Elemanları"},
                new MainCategory {Id=2,Name="Pnömatik"},
                new MainCategory {Id=3,Name="Elektronik"},
            });
        }
    }
}
