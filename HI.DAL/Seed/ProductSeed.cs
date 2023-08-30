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
                new Product { Id = 1,
                    Name="Hidrolik Silindir",
                    Title="Hidrolik silindir başlık",
                    Active=true,
                    CategoryId=1,
                    ShowHomePage=true,
                    Tags = "hidrolik, hidrolik sistemler,",
                    HomePageImageName = "service-image-1.jpg",
                    Content1="Hidrolik silindir içerikleri ve daha fazlası",
                    Content2="Hidrolik silindir içerikleri 2",
                    Content3="The way we all became the Brady come and listen to a story about a man barely kept his family never heard to the word possible this time there is no stopping us the Love Boat soon will be making another run the Love Boat in a promises something for eryone be from me and the card attached would say federal impossible this time there is no stopping us the Love Boat soon will be aking another run the Love Boat promises.",
                    ContentName1 = "Acıklama",
                    ContentName2 = "Tablolar",
                    ContentName3 = "Detaylı Analiz",
                    Description = "The way we all became the Brady come and listen to a story about a man barely kept his family never heard to the word to impossible this time there is no stopping us the Love Boat in soon will be making another run.",



                },
                new Product { Id = 2,
                    Name="Hidrolik Silindir",
                    Title="Hidrolik silindir başlık",
                    Active=false,
                    CategoryId=2,
                    ShowHomePage=true,
                    Tags = "hidrolik, hidrolik sistemler,",
                    HomePageImageName = "service-image-1.jpg",
                    Content1="Hidrolik silindir içerikleri ve daha fazlası",
                    Content2="Hidrolik silindir içerikleri 2",
                    Content3="The way we all became the Brady come and listen to a story about a man barely kept his family never heard to the word possible this time there is no stopping us the Love Boat soon will be making another run the Love Boat in a promises something for eryone be from me and the card attached would say federal impossible this time there is no stopping us the Love Boat soon will be aking another run the Love Boat promises.",
                    ContentName1 = "Acıklama",
                    ContentName2 = "Tablolar",
                    ContentName3 = "Detaylı Analiz",
                    Description = "The way we all became the Brady come and listen to a story about a man barely kept his family never heard to the word to impossible this time there is no stopping us the Love Boat in soon will be making another run.",

                },
                new Product { Id = 3,
                    Name="Hidrolik Silindir",
                    Title="Hidrolik silindir başlık",
                    Active=true,
                    CategoryId=3, 
                    ShowHomePage = true,
                    Tags = "hidrolik, hidrolik sistemler,",
                    HomePageImageName = "service-image-1.jpg",
                    Content1="Hidrolik silindir içerikleri ve daha fazlası",
                    Content2="Hidrolik silindir içerikleri 2",
                    Content3="The way we all became the Brady come and listen to a story about a man barely kept his family never heard to the word possible this time there is no stopping us the Love Boat soon will be making another run the Love Boat in a promises something for eryone be from me and the card attached would say federal impossible this time there is no stopping us the Love Boat soon will be aking another run the Love Boat promises.",
                    ContentName1 = "Acıklama",
                    ContentName2 = "Tablolar",
                    ContentName3 = "Detaylı Analiz",
                    Description = "The way we all became the Brady come and listen to a story about a man barely kept his family never heard to the word to impossible this time there is no stopping us the Love Boat in soon will be making another run.",

                },
            });
        }
    }
}

