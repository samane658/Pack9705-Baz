using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AttendanceApp.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public string name { get; set; }
        public string lastName { get; set; }
        public string positionName { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string cellPhone { get; set; }
        public DateTime  birthDate  { get; set; }
        public string gender { get; set; }
        public string picPath { get; set; }

        public ApplicationUser Manager { get; set; }
        public int ManagerId { get; set; }
        public ICollection<ApplicationUser> Employees { get; set; }

    }

    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext()
            : base("AppDbConnection", throwIfV1Schema: false)
        {
        }

        public virtual DbSet<rule> rules { get; set; }
        public virtual DbSet<position> Positions { get; set; }
        public virtual DbSet<rest> Rests { get; set; }
        public virtual DbSet<inout> Inouts { get; set; }
       

        public static AppDbContext Create()
        {
            return new AppDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>()
                .HasOptional(u => u.Manager)
                .WithMany(u => u.Employees);
        }
    }
}