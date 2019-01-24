using System.Linq;

namespace BilliardStore.Controllers
{

    public class AdminController : Microsoft.AspNetCore.Mvc.Controller
    {
        private BilliardStore.Models.IProductRepository repository;

        public AdminController(BilliardStore.Models.IProductRepository repo)
        {
            repository = repo;
        }

        public Microsoft.AspNetCore.Mvc.ViewResult Index() => View(repository.Products);

        public Microsoft.AspNetCore.Mvc.ViewResult Edit(int productId) => View(repository.Products.FirstOrDefault(p => p.ProductID == productId));

        [Microsoft.AspNetCore.Mvc.HttpPost]
        public Microsoft.AspNetCore.Mvc.IActionResult Edit(BilliardStore.Models.Product product)
        {
            if (ModelState.IsValid)
            {
                repository.SaveProduct(product);
                TempData["message"] = $"{product.Name} has been saved";
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values
                return View(product);
            }
        }

        public Microsoft.AspNetCore.Mvc.ViewResult Create() => View("Edit", new BilliardStore.Models.Product());

        [Microsoft.AspNetCore.Mvc.HttpPost]
        public Microsoft.AspNetCore.Mvc.IActionResult Delete(int productId)
        {
            BilliardStore.Models.Product deletedProduct = repository.DeleteProduct(productId);
            if (deletedProduct != null)
            {
                TempData["message"] = $"{deletedProduct.Name} was deleted";
            }
            return RedirectToAction("Index");
        }
    }
}