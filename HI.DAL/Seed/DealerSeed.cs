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
    internal class DealerSeed : IEntityTypeConfiguration<Dealer>
    {
        public void Configure(EntityTypeBuilder<Dealer> builder)
        {
            builder.HasData(
                    new List<Dealer>{
                        new Dealer {
                            Id = 1,
                            Name = "Name 1",
                            ImageName = "1.jpg",
                        },
                        new Dealer {
                            Id = 2,
                            Name = "Name 2",
                            ImageName = "2.jpg",
                        },
                        new Dealer {
                            Id = 3,
                            Name = "Name 3",
                            ImageName = "3.jpg",
                        },
                        new Dealer {
                            Id = 4,
                            Name = "Name 4",
                            ImageName = "4.jpg",
                        },
                        new Dealer {
                            Id = 5,
                            Name = "Name 5",
                            ImageName = "5.jpg",
                        },
                        new Dealer {
                            Id = 6,
                            Name = "Name 6",
                            ImageName = "6.jpg",
                        },
                        new Dealer {
                            Id = 7,
                            Name = "Name 7",
                            ImageName = "7.jpg",
                        },
                    }
                );
        }
    }
}
