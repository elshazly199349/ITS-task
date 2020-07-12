using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.DbContexts
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser>
    {
        private readonly string connectionString = "server=(localdb)\\MSSQLLocalDB;database=ITS-Task;trusted_Connection=true";

        //public ApplicationDbContext() : base() { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //fill tables with Initail data
            builder.Seed();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<Step> Steps { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}
