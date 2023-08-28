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
    internal class CategorySeed : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(new List<Category> { 
                new Category { Id = 1, Name = "Hidrolik Güç Üniteleri",MainCategoryId=1 },
                new Category { Id = 2, Name="Pnömatik Silindirler",MainCategoryId=2},
                new Category { Id = 3, Name="Pnömatik Valfler",MainCategoryId=2},
                new Category { Id = 4,Name="Moment Kontrol Sistemleri",MainCategoryId=3},
            });
        }
    }
}
