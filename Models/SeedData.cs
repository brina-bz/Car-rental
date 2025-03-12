using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Odpelji_me.Data;
using OpremiSe.Models;

namespace Odpelji_me.Models
{
    public class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider, UserManager<IdentityUser> userManager)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            // Ensure the Administrator role exists
            if (!await roleManager.RoleExistsAsync("Administrator"))
            {
                await roleManager.CreateAsync(new IdentityRole("Administrator"));
            }

            // Ensure a specific user exists
            var adminEmail = "admin@odpeljime.com";
            var adminUser = await userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                // Create an admin user
                adminUser = new IdentityUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true // Skip confirmation for simplicity
                };

                await userManager.CreateAsync(adminUser, "AdminPassword123!"); // Set a strong password
            }

            // Assign the user to the Administrator role
            if (!await userManager.IsInRoleAsync(adminUser, "Administrator"))
            {
                await userManager.AddToRoleAsync(adminUser, "Administrator");
            }
        }
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Odpelji_meContext(
                serviceProvider.GetRequiredService<
                DbContextOptions<Odpelji_meContext>>()))
            {
                if (context == null || context.Avtomobil == null)
                {
                    throw new ArgumentNullException("Null RazorPagesMovieContext");
                }

                // Look for any cars.
                if (context.Avtomobil.Any())
                {
                    return;   // DB has been seeded
                }
                context.Avtomobil.AddRange(
                     new Avtomobil
                     {
                         Znamka = "Tesla",
                         Model = "Model 3",
                         Leto = 2022,
                         CenaNaDan = 49.99m,
                         RegistrskaStevilka = "LJ-123-AB",
                         Status = "Na voljo"
                     },
                    new Avtomobil
                    {
                        Znamka = "Volkswagen",
                        Model = "Golf 8",
                        Leto = 2021,
                        CenaNaDan = 39.99m,
                        RegistrskaStevilka = "MB-456-CD",
                        Status = "Na voljo"
                    },
                    new Avtomobil
                    {
                        Znamka = "BMW",
                        Model = "iX3",
                        Leto = 2023,
                        CenaNaDan = 59.99m,
                        RegistrskaStevilka = "KP-789-EF",
                        Status = "Na voljo"
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
