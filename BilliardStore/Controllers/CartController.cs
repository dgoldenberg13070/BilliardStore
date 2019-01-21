//references IProductRepository.cs, Product.cs, Cart.cs, CartIndexViewViewModel.cs, index.cshtml
//calls EFProductRepository.cs, Cart.cs, SessionExtensions.cs, CartIndexViewViewModel.cs, SessionCart.cs
//referenced by index.cshtml in the Views/Cart folder
using BilliardStore.Infrastructure;
using System.Linq;

namespace BilliardStore.Controllers
{

    public class CartController : Microsoft.AspNetCore.Mvc.Controller
    {
        
		//instance variables
        private Models.IProductRepository repository;
        private Models.Cart cart;

        public CartController(Models.IProductRepository repo, Models.Cart cartService)
        {
            repository = repo;
            cart = cartService;
        }

        //the below method 'Index' returns an object of type ViewResult        
        public Microsoft.AspNetCore.Mvc.ViewResult Index(string returnUrl)
        {
            return View(new Models.ViewModels.CartIndexViewModel
                {
                    Cart = cart,
                    ReturnUrl = returnUrl
                }
            );
        }
               
        //The productId and returnUrl are passed in as parameters        
        public Microsoft.AspNetCore.Mvc.RedirectToActionResult AddToCart(int productId, string returnUrl)
        {            
            //Product is my class defined in the Product.cs file
            //LINQ is used to return the first matching product (by productID)            
            Models.Product product = repository.Products.FirstOrDefault(p => p.ProductID == productId);

            if (product != null)
            {
               //calls AddItem method in SessionCart.cs
               cart.AddItem(product, 1);              
            }

            return RedirectToAction("Index", new {returnUrl});

        }

        public Microsoft.AspNetCore.Mvc.RedirectToActionResult RemoveFromCart(int productId, string returnUrl)
        {

            Models.Product product = repository.Products.FirstOrDefault(p => p.ProductID == productId);

            if (product != null)
            {
                  cart.RemoveLine(product);
            }

            return RedirectToAction("Index", new { returnUrl });

        }

    }
	
}