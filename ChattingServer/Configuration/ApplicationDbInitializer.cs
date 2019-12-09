using ChattingServer.DAL.Models.Users;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChattingServer.Configuration
{
    public static class ApplicationDbInitializer
    {
        public static void SeedRoles(RoleManager<Role> roleManager) {
            if (roleManager.FindByNameAsync("Admin").Result == null) {
                var role = new Role() {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                };
                roleManager.CreateAsync(role).Wait(); 
            }
        }
        public static void SeedUsers(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            if (userManager.FindByEmailAsync("admin@chatting.com").Result == null)
            {
                User user = new User
                {
                    UserName = "admin",
                    Email = "admin@chatting.com"
                };
                var adminRole = roleManager.FindByNameAsync("Admin").Result;
                if (adminRole != null)
                {
                    IdentityResult result = userManager.CreateAsync(user, "passAdmin#1").Result;

                    if (result.Succeeded)
                    {
                        userManager.AddToRoleAsync(user, adminRole.Name).Wait();
                    }
                }
            }
           
        }
    }
}
