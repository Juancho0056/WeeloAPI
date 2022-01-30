
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeeloApi.Domain.Entities;
using WeeloApi.Infrastructure.Identity;

namespace WeeloApi.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedDefaultUserAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var administratorRole = new IdentityRole("Administrator");

            if (roleManager.Roles.All(r => r.Name != administratorRole.Name))
            {
                await roleManager.CreateAsync(administratorRole);
            }

            var administrator = new ApplicationUser { UserName = "administrator@localhost", Email = "administrator@localhost" };

            if (userManager.Users.All(u => u.UserName != administrator.UserName))
            {
                await userManager.CreateAsync(administrator, "Administrator1!");
                await userManager.AddToRolesAsync(administrator, new[] { administratorRole.Name });
            }
        }
        public static async Task SeedSampleDataAsync(ApplicationDbContext context)
        {
            // Seed, if necessary
            if (!context.Owners.Any())
            {
                IList<Owner> data = new List<Owner>();
                data.Add(new Owner
                {
                    Name = "Jameson Woodward",
                    Address = "Ap #246-2376 Aliquet, St.",
                    Birthday = DateTime.Parse("2021-08-04")
                });
                data.Add(new Owner {
                    Name = "Jamal Dawson",
                    Address = "344-286 Lacinia St.",
                    Birthday = DateTime.Parse("2022-05-12")
                });
                data.Add(new Owner {
                    Name = "Alexandra Haney",
                    Address = "Ap #535-9868 Nullam Av.",
                    Birthday = DateTime.Parse("2022-03-21")
                });
                data.Add(new Owner {
                    Name = "Laith Wolfe",
                    Address = "Ap #126-236 Hendrerit St.",
                    Birthday = DateTime.Parse("2021-04-29")
                });
                data.Add(new Owner {
                    Name = "Keely Morris",
                    Address = "198-2322 Bibendum. Road",
                    Birthday = DateTime.Parse("2021-05-10")
                });
                context.Owners.AddRange(data);
                await context.SaveChangesAsync();
            }
        }
    }
}
