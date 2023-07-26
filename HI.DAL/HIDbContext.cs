using HI.Model;
using Microsoft.EntityFrameworkCore;

namespace HI.DAL
{
    public class HIDbContext : DbContext
    {
        public HIDbContext(DbContextOptions<HIDbContext>options) : base(options)
        {

        }
        

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
