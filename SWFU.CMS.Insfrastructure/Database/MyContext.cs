using Microsoft.EntityFrameworkCore;
using SWFU.CMS.Core.Entities;
using SWFU.CMS.Insfrastructure.EntityConfigurations;

namespace SWFU.CMS.Insfrastructure.Database
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new PostConfiguration());
        }


        public DbSet<Post> Posts { get; set; }
    }
}