//cart component
//called by _Layout.cshtml

namespace BilliardStore.Components
{

    public class CartSummaryViewComponent : Microsoft.AspNetCore.Mvc.ViewComponent
    {

        private readonly Models.Cart cart;

        public CartSummaryViewComponent(Models.Cart cartService)
        {
            cart = cartService;
        }

        public Microsoft.AspNetCore.Mvc.IViewComponentResult Invoke()
        {
            return View(cart);
        }

    }

}
