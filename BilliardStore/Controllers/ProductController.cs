//references IProductRepository.cs, ProductsListViewModel.cs, PagingInfo.cs, Product.cs
//calls EFProductRepository.cs, PagingInfo.cs, ProductsListViewModel.cs

using System.Linq;

namespace BilliardStore.Controllers
{

    public class ProductController : Microsoft.AspNetCore.Mvc.Controller
    {
        //instance variables
        private Models.IProductRepository repository;
        private readonly int PageSize = 2;

        //this is the constructor. 
        //'repo' which is an object of type IProductRepository is passed in as a parameter.
        //value of instance variable 'respository' object is set here
        public ProductController(Models.IProductRepository repo)
        {
            repository = repo;
        }

        //Returns an object of type ProductsListViewModel (my own class) from the ProductsListViewModel.cs view model class
        //This object is also a type ViewResult.  Info about which products, pagingInfo (made up of currentPage, ItemsPerPage, and TotalItems) and category are returned with this object.
        //The product category and the productPage are passed in as parameters
        //Startup.cs, Default.cshtml, List.cshtml all reference the List method
        public Microsoft.AspNetCore.Mvc.ViewResult List(string category, int productPage = 1)
        {

            //Products is a class of object type IQueryable<Models.Product>
            //Product is my class defined in the Product.cs file
            //LINQ is used (Where, OrderBy, Skip, Take) to return correct products
            //next line calls the Products method in the EFProductRepository.cs file                       
            System.Linq.IQueryable<Models.Product> products = repository.Products
                .Where(p => category == null || p.Category == category)
                .OrderBy(p => p.ProductID)
                .Skip((productPage - 1) * PageSize)
                .Take(PageSize);

            //pagingInfo is a class of object type Models.ViewModels.PagingInfo
            //PagingInfo is my class defined in Paging.Info.cs in the Models/ViewModels folder
            Models.ViewModels.PagingInfo pagingInfo = new Models.ViewModels.PagingInfo();
            pagingInfo.CurrentPage = productPage;
            pagingInfo.ItemsPerPage = PageSize;
            //next line calls the Products property in the EFProductRepository.cs file
            if (category == null)
            {
                pagingInfo.TotalItems = repository.Products.Count();
            }
            else
            {
                pagingInfo.TotalItems = repository.Products.Where(e => e.Category == category).Count();
            }
            //productsListViewModel is an object of my class ProductsListViewModel defined in the ProductsListViewModel.cs file in the Models/ViewModels class
            Models.ViewModels.ProductsListViewModel productsListViewModel = new Models.ViewModels.ProductsListViewModel();
            productsListViewModel.Products = products;
            productsListViewModel.PagingInfo = pagingInfo;
            productsListViewModel.CurrentCategory = category;

            return View(productsListViewModel);
            
        }
       
    }

}
