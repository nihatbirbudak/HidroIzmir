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
    internal class ContactSeed : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasData(new List<Contact> {
                (new Contact {Id = 1,Name="Nİhat",Email="nihat@mail.com",Phone="526235863",Context="Merhaba bana Yardımcı Olun",IsRead=false,UploadTime=DateTime.UtcNow,Title="Yardım" }),
                (new Contact {Id = 2,Name="Beril",Email="nihat@mail.com",Phone="526235863",Context="Merhaba bana Yardımcı Olun",IsRead=false,UploadTime=DateTime.UtcNow, Title = "Yardım" }),
                (new Contact {Id = 3,Name="Selin",Email="nihat@mail.com",Phone="526235863",Context="Merhaba bana Yardımcı Olun",IsRead=false,UploadTime=DateTime.UtcNow, Title="Yardım" }),
            });
        }
    }
}
