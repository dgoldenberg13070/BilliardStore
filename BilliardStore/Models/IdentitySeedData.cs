using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace BilliardStore.Models
{

    public static class IdentitySeedData
    {

        private const string adminUser = "Admin";
        private const string adminPassword = "Secret123$";

        public static async void EnsurePopulated(Microsoft.AspNetCore.Builder.IApplicationBuilder app)
        {
            Microsoft.AspNetCore.Identity.UserManager<Microsoft.AspNetCore.Identity.IdentityUser> userManager = app.ApplicationServices.GetRequiredService<UserManager<Microsoft.AspNetCore.Identity.IdentityUser>>();
            Microsoft.AspNetCore.Identity.IdentityUser user = await userManager.FindByIdAsync(adminUser);
            if (user == null)
            {
                user = new Microsoft.AspNetCore.Identity.IdentityUser("Admin");
                await userManager.CreateAsync(user, adminPassword);
            }
        }

    }

}