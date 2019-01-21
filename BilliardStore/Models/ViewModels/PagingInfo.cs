//This is a view model class which is used to pass data between the ProductController controller and the List view in the Product folder
//Referenced by ProductController.cs, ProductsListViewModel.cs, PageLinkTagHelper.cs
//called by ProductController.cs
namespace BilliardStore.Models.ViewModels
{

    public class PagingInfo
    {
        //instance variables
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
                
        //since TotalPages value is determined by the value of other properties, no set is needed for it
        public int TotalPages
        {
            get
            {
                return (int)System.Math.Ceiling((decimal)TotalItems / ItemsPerPage);
            }
        }

        //empty constructor
        public PagingInfo()
        {

        }

    }

}