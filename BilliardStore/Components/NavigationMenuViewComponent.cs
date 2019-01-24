//component for the sidebar
//this component is used in the _Layout.cshtml view to display the navigation sidebar
//reference IProductRepository.cs, Product.cs
//called by _Layout.cshtml
using System.Linq;

namespace BilliardStore.Components
{
    public class NavigationMenuViewComponent : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        //instance variable 'repository'
        private Models.IProductRepository repository;

        //constructor where an object of my IProductRepository class is passed in and set to the 'repository' instance variable 
        public NavigationMenuViewComponent(Models.IProductRepository repo)
        {
            repository = repo;
        }
        //Below method is called in the _Layout.cshtml view. It returns an IQueryable<string> object that via LINQ displays the products for the selected category in sorted order
        //It returns products that match a particular category
        public Microsoft.AspNetCore.Mvc.IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];

            System.Linq.IQueryable<string> vs = repository.Products
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);
                       
            return View(vs);
        }
    }
}
