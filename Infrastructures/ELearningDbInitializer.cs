using FastLearn.Infrastructures.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastLearn.Infrastructures
{
    public static class ELearningDbInitializer
    {
        public async static Task SeedData(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
           await SeedUser(userManager);
           await SeedRole(roleManager);
        }

        public async static Task SeedUser(UserManager<ApplicationUser> userManager)
        {
            var result = await userManager.FindByEmailAsync("psalmueloye@gmail.com");
            if(result == null)
            {
                var user = new ApplicationUser
                {
                    FullName = "Samuel Osinloye",                 
                    Email = "psalmueloye@gmail.com",
                    PhoneNumber = "08066876531",
                    UserName = "psalmueloye@gmail.com",
                    Address = "8, Mercy Seat Estate, Mowo-Kekere, Along Ijede Road, Ikorodu."
                };
                await userManager.CreateAsync(user, "@Adebayo123!.");
                await userManager.AddToRoleAsync(user, "Administrator");
            }
        }

        public async static Task SeedRole(RoleManager<IdentityRole> roleManager)
        {
            var admin = await roleManager.RoleExistsAsync("Administrator");
            if (!admin)
            {
                await roleManager.CreateAsync(new IdentityRole { Name = "Administrator" });
            }
  
            var student = await roleManager.RoleExistsAsync("Student");
            if (!student)
            {
                await roleManager.CreateAsync(new IdentityRole { Name = "Student" });
            }
            var faculty = await roleManager.RoleExistsAsync("Faculty");
            if (!faculty)
            {
                await roleManager.CreateAsync(new IdentityRole { Name = "Faculty" });
            }
        }
    }
}
