using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReactMVC.Configurations.Entities;
using ReactMVC.Models;

namespace ReactMVC.Data
{
    public class ApplicationContext : IdentityDbContext<APIUser>
    {
        public ApplicationContext( DbContextOptions opts) : base(opts)
        {       
        }

        public DbSet<APIUser> Users { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new AddDataToUsersTableConfiguration());   
        }
    }
}
