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
    internal class SliderSeed : IEntityTypeConfiguration<Slider>
    {
        public void Configure(EntityTypeBuilder<Slider> builder)
        {
            builder.HasData(
                new List<Slider>
                {
                    new Slider {
                        Id =1,
                        Title = "Hidrolik Sistemler",
                        Content = "Hidrolik Sistemler",
                        Content2 = "Ve Çözümler",
                        LinkName1 = "Bize Ulaşın",
                        LinkName2 = "İncele",
                        Link1 = "/iletisim",
                        Link2 = "/urunler",
                        İmageName = "1.jpg",
                    },
                    new Slider {
                        Id =2,
                        Title = "HİDRO İZMİR'E HOŞGELDİNİZ",
                        Content = "Hizmetlerimiz ve ürünlerimiz hakkında daha detaylı bilgi",
                        Content2 = "almak için bize her zaman ulaşabilirsiniz.",
                        LinkName1 = "İletişim",
                        Link1 = "/iletisim",
                        İmageName = "2.jpg",
                    },
                    new Slider {
                        Id =3,
                        Title = "Pnömatik",
                        Content = "Pnömatik ürünlerimiz",
                        Content2 = "ve daha fazlası.",
                        LinkName1 = "İletişim",
                        Link1 = "/iletisim",
                        İmageName = "3.jpg",
                    },
                }
                );
        }
    }
}
