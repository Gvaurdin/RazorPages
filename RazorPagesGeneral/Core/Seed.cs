using Microsoft.AspNetCore.Identity;
using RazorPagesGeneral.Model;

namespace RazorPagesGeneral.Core
{
    public class Seed
    {
        public static async Task SeedUserAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using var applicationServices = applicationBuilder.ApplicationServices.CreateScope();
            var roleManager =  applicationServices.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            }

            if (!await roleManager.RoleExistsAsync(UserRoles.User))
            {
                await roleManager.CreateAsync(new IdentityRole(UserRoles.User));
            }

            if (!await roleManager.RoleExistsAsync(UserRoles.Moderator))
            {
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Moderator));
            }

            var userManager = applicationServices.ServiceProvider.GetRequiredService<UserManager<User>>();
            string adminEmail = "gvaurdin@yandex.ru";
            var adminUser = await userManager.FindByNameAsync(adminEmail);

            if (adminUser is null)
            {
                var user = new User
                {
                    UserName = "Gvaurdin",
                    Email = adminEmail,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(user, "Pleomax!@159753");

                if (result.Succeeded)  // Ensure user creation succeeded
                {
                    await userManager.AddToRoleAsync(user, UserRoles.Admin);
                }
            }

            string userEmail = "gvaurdin777@yandex.ru";
            var simpleUser = await userManager.FindByNameAsync(userEmail);

            if (simpleUser is null)
            {
                var user = new User
                {
                    UserName = "User",
                    Email = userEmail,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(user, "Pleomax!@159");

                if (result.Succeeded)  // Ensure user creation succeeded
                {
                    await userManager.AddToRoleAsync(user, UserRoles.User);
                }
            }

            string moderatorEmail = "totalburst@yandex.ru";
            var workUser = await userManager.FindByNameAsync(moderatorEmail);

            if (workUser is null)
            {
                var user = new User
                {
                    UserName = "Moderator",
                    Email = moderatorEmail,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(user, "Pleomax!@753");

                if (result.Succeeded)  // Ensure user creation succeeded
                {
                    await userManager.AddToRoleAsync(user, UserRoles.Moderator);
                }
            }


        }
    }
}
