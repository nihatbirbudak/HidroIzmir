using HI.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace HI.DAL
{
    public class HIDbContext : DbContext
    {
        public HIDbContext(DbContextOptions<HIDbContext>options) : base(options)
        {

        }
        

        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ImagePath> ImagePaths { get; set; }
        public DbSet<MainCategory> MainCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
