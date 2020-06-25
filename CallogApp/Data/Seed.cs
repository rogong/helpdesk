using CallogApp.Models;
using CallogApp.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallogApp.Data
{
    public class Seed
    {
        public static async Task SeedData(ApplicationDbContext context,
          UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (!context.ITStaffs.Any())
            {
                var staff = new List<ITStaff>
                {

                     new ITStaff
                    {
                        Name = "Mr Tolu",
                        Specialisation = "Software Development"
                    },
                     new ITStaff
                    {
                        Name = "Mr Wale",
                        Specialisation = "Software Development"
                    },
                     new ITStaff
                    {
                        Name = "Mr Seyi",
                        Specialisation = "Software Development"
                    },
                     new ITStaff
                    {
                        Name = "Mr Ayo",
                        Specialisation = "System Administration"
                    },
                     new ITStaff
                    {
                        Name = "Mr Yusuf",
                        Specialisation = "System Administration"
                    },
                     new ITStaff
                    {
                        Name = "Mr Micheal",
                        Specialisation = "Data processing"
                    },
                     new ITStaff
                    {
                        Name = "Pending",
                        Specialisation = "Not Resolved"
                    },
                     new ITStaff
                    {
                        Name = "Mrs Amaka",
                        Specialisation = "System Administration"
                    }
                };
                await context.ITStaffs.AddRangeAsync(staff);
                await context.SaveChangesAsync();
            }

            var userI = await context.ApplicationUsers.FirstOrDefaultAsync(u => u.Email == "oluseyi_ayinde@superfluxnigeria.com");

            await userManager.AddToRoleAsync(userI, SD.SuperAdminUser);

            if (!userManager.Users.Any())
            {
                var users = new List<ApplicationUser>
                {

                    new ApplicationUser
                    {

                        Email = "oluseyi_ayinde@superfluxnigeria.com",
                        UserName = "Oluseyi2",
                        DepartmentId = 1,
                      
                    },
                     new ApplicationUser
                    {

                        Email = "it@superfluxnigeria.com",
                        UserName = "Itdepartment",
                        DepartmentId = 1,
                       
                    },
                };
                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Wizard4life#");

                }

            }

            if (!context.Departments.Any())
            {
                var departments = new List<Department>
                {
                    new Department
                    {

                        Name = "IT"
                    },
                    new Department
                    {

                        Name = "HR"
                    },
                    new Department
                    {

                        Name = "Admin"
                    },
                    new Department
                    {

                        Name = "Studio"
                    },
                    new Department
                    {

                        Name = "Maketing"
                    },

                };
                await context.Departments.AddRangeAsync(departments);
                await context.SaveChangesAsync();
            }



            if (!context.Devices.Any())
            {
                var devices = new List<Devices>
                {
                    new Devices
                    {

                        Name = "Laptop"
                    },
                    new Devices
                    {

                        Name = "Desktop"
                    },
                    new Devices
                    {

                        Name = "Mouse"
                    },
                    new Devices
                    {

                        Name = "USB"
                    },
                    new Devices
                    {

                        Name = "Keyboard"
                    },

                };
                await context.Devices.AddRangeAsync(devices);
                await context.SaveChangesAsync();
            }

            if (!context.Issues.Any())
            {
                var Issues = new List<Issue>
                {
                    new Issue
                    {

                        Name = "Network"
                    },

                    new Issue
                    {

                        Name = "Template"
                    },
                    new Issue
                    {

                        Name = "Data Processing"
                    },

                    new Issue
                    {

                        Name = "Reports"
                    },

                };

                await context.Issues.AddRangeAsync(Issues);
                await context.SaveChangesAsync();
            }

            if (!roleManager.Roles.Any())
            {
                var roles = new List<IdentityRole>
                {
                    new IdentityRole
                    {
                        Name = SD.SuperAdminUser
                    },
                    new IdentityRole
                    {
                        Name = SD.AdminUser
                    },
                    new IdentityRole
                    {
                        Name = SD.User
                    },
                    
                };
                foreach (var role in roles)
                {
                    await roleManager.CreateAsync(role);
                }

            }


        }
    }
}
