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
    internal class AboutSeed : IEntityTypeConfiguration<About>
    {
        public void Configure(EntityTypeBuilder<About> builder)
        {
            builder.HasData(
                new About{
                    Id = 1,
                    Abouts = "1 The Love Boat promises something for everyone be from me and the card rached would say federal impossible to this bee time there is no stopping us the Love Boat soon will be the Love Boat in a promises something for a everyone be from me and the card attached would say federal impossible making another run all became the Brady come and listen to a story about a man Boat soon." ,
                    Mission = "2 The Love Boat promises something for everyone be from me and the card rached would say federal impossible to this bee time there is no stopping us the Love Boat soon will be the Love Boat in a promises something for a everyone be from me and the card attached would say federal impossible making another run all became the Brady come and listen to a story about a man Boat soon.",
                    Vission = "3 The Love Boat promises something for everyone be from me and the card rached would say federal impossible to this bee time there is no stopping us the Love Boat soon will be the Love Boat in a promises something for a everyone be from me and the card attached would say federal impossible making another run all became the Brady come and listen to a story about a man Boat soon.",
                }
            );
        }
    }
}
