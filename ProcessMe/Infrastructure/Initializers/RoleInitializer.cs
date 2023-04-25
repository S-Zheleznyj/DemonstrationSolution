using Microsoft.AspNetCore.Identity;

namespace ProcessMe.Infrastructure.Initializers
{
    public class RoleInitializer
    {
        //private readonly UserManager<IdentityUser> _userManager;
        //private readonly RoleManager<IdentityRole> _roleManager;
        //public RoleInitializer(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        //{
        //    _userManager = userManager;
        //    _roleManager = roleManager;
        //}
        public static async Task InitializeAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager,
            IConfiguration configuration)
        {
            string adminEmail = configuration.GetSection("RoleInitializer:AdminEmail").Value;
            string password = configuration.GetSection("RoleInitializer:Password").Value;
            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }
            if (await roleManager.FindByNameAsync("employee") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("employee"));
            }
            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                IdentityUser admin = new IdentityUser { Email = adminEmail, UserName = adminEmail, EmailConfirmed = true };
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }
            }
        }
    }
}
