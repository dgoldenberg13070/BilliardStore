
namespace BilliardStore.Components
{

    public class AccountPageViewComponent : Microsoft.AspNetCore.Mvc.ViewComponent
    {
          
        public AccountPageViewComponent()
        {
            
        }

        public Microsoft.AspNetCore.Mvc.IViewComponentResult Invoke()
        {
            return View();
        }

    }

}
