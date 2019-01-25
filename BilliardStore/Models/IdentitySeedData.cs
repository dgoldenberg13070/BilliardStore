using Microsoft.AspNetCore.Identity;

namespace BilliardStore.Models
{

    public static class IdentitySeedData
    {

        private const string adminUser = "Admin";
        private const string adminPassword = "Secret123$";

        public static async System.Threading.Tasks.Task EnsurePopulated(UserManager<IdentityUser> userManager)
        {            
            Microsoft.AspNetCore.Identity.IdentityUser user = await userManager.FindByIdAsync(adminUser);
            if (user == null)
            {
                user = new Microsoft.AspNetCore.Identity.IdentityUser("Admin");
                await userManager.CreateAsync(user, adminPassword);
            }
        }

    }

}