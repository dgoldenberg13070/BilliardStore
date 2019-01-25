using BilliardStore.Models.ViewModels;

namespace BilliardStore.Controllers
{

    [Microsoft.AspNetCore.Authorization.Authorize]
    public class AccountController : Microsoft.AspNetCore.Mvc.Controller
    {
        private Microsoft.AspNetCore.Identity.UserManager<Microsoft.AspNetCore.Identity.IdentityUser> userManager;
        private Microsoft.AspNetCore.Identity.SignInManager<Microsoft.AspNetCore.Identity.IdentityUser> signInManager;

        public AccountController(Microsoft.AspNetCore.Identity.UserManager<Microsoft.AspNetCore.Identity.IdentityUser> userMgr,
                Microsoft.AspNetCore.Identity.SignInManager<Microsoft.AspNetCore.Identity.IdentityUser> signInMgr)
        {
            userManager = userMgr;
            signInManager = signInMgr;
            BilliardStore.Models.IdentitySeedData.EnsurePopulated(userMgr).Wait();
        }

        [Microsoft.AspNetCore.Authorization.AllowAnonymous]
        public Microsoft.AspNetCore.Mvc.ViewResult Login(string returnUrl)
        {
            return View(new LoginModel
            {
                ReturnUrl = returnUrl
            });
        }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        [Microsoft.AspNetCore.Authorization.AllowAnonymous]
        [Microsoft.AspNetCore.Mvc.ValidateAntiForgeryToken]
        public async System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                Microsoft.AspNetCore.Identity.IdentityUser user = await userManager.FindByNameAsync(loginModel.Name);
                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    if ((await signInManager.PasswordSignInAsync(user, loginModel.Password, false, false)).Succeeded)
                    {
                        return Redirect(loginModel?.ReturnUrl ?? "/Admin/Index");
                    }
                }
            }
            ModelState.AddModelError("", "Invalid name or password");
            return View(loginModel);
        }

        public async System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.RedirectResult> Logout(string returnUrl = "/")
        {
            await signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }
    }
}
