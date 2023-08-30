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
    internal class ContactPageSeed : IEntityTypeConfiguration<ContactPage>
    {
        public void Configure(EntityTypeBuilder<ContactPage> builder)
        {
            builder.HasData(
                new ContactPage
                {
                    Id = 1,
                    Address = "Samurlu Mh. 1248 Sk No:18/D-C",
                    Address2 = "Aliağa-İZMİR",
                    Email1 = "info@hidroizmir.com",
                    Email2 = "satis@hidroizmir.com",
                    Phone1 = "0(232) 618 02 35",
                    Phone2 = "0(232) 618 02 35",
                }
                );
        }
    }
}
