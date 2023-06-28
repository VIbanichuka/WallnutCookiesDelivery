using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WallnutCookiesDelivery.DataAccess.Data;

namespace WallnutCookiesDelivery.DataAccess.Identity;

public class IdentityDbContextSeed
{
    public static async Task SeedAsync(ApplicationDbContext identityDbContext, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        if (identityDbContext.Database.IsSqlServer())
        {
            identityDbContext.Database.Migrate();
        }
        
        var email = "adminUser@gmail.com";
        var password = "@Admin1234";
        var roles = new[] { "Admin", "User" };
        
        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }
        
        if (await userManager.FindByEmailAsync(email) == null)
        {
            var adminUser = new IdentityUser();
            adminUser.UserName = email;
            adminUser.Email = email;
            await userManager.CreateAsync(adminUser, password);
            await userManager.AddToRoleAsync(adminUser, "Admin");
        }
    }
}