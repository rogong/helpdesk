using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CallogApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CallogApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Call> Calls  { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Issue> Issues { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<Devices> Devices { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<ITStaff> ITStaffs { get; set; }
        public DbSet<AssignRequest> AssignRequests { get; set; }
        public DbSet<Level> Levels { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // builder.Seed();

            foreach (var foreignKey in builder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }


        }

    }
}
