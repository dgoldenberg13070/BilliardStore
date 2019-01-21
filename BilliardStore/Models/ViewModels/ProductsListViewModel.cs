//This is a view model class which is used to pass data between the ProductController controller and the List view in the Product folder
//This class gets and sets Products, PagingInfo, and CurrentCategory
//referenced by ProductController.cs, PagingInfo.cs, Product.cs
//called by ProductController.cs
namespace BilliardStore.Models.ViewModels
{

    public class ProductsListViewModel
    {

        public System.Collections.Generic.IEnumerable<Models.Product> Products { get; set; }
        public Models.ViewModels.PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }

        //nothing to do in constructor as the get & set for the three properties are done above
        public ProductsListViewModel()
        {
            
        }

    }

}

