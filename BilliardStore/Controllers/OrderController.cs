//Calls Cart.cs

using System.Linq;

namespace BilliardStore.Controllers
{

    public class OrderController : Microsoft.AspNetCore.Mvc.Controller
    {

        private Models.IOrderRepository repository;
        private Models.Cart cart;

        public OrderController(Models.IOrderRepository repoService, Models.Cart cartService)
        {
            repository = repoService;
            cart = cartService;
        }

        public Microsoft.AspNetCore.Mvc.ViewResult Checkout()
        {
            return View(new Models.Order());
        }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        public Microsoft.AspNetCore.Mvc.IActionResult Checkout(Models.Order order)
        {

            //next line calls the Lines method in Cart.cs
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Your shopping cart is empty!");
            }

            if (ModelState.IsValid)
            {
                order.Lines = cart.Lines.ToArray();
                repository.SaveOrder(order);
                return RedirectToAction(nameof(Completed));
            }
            else
            {
                return View(order);
            }

        }

        public Microsoft.AspNetCore.Mvc.ViewResult Completed()
        {
            cart.Clear();
            return View();
        }

    }

}
