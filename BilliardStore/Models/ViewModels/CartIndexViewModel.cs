//This is a view model class which is used to pass data between the CartController controller and the Cart view
//This class gets and sets Cart and ReturnUrl
//referenced by CartController.cs, Cart.cs
//called by CartController.cs, index.cshtml

namespace BilliardStore.Models.ViewModels
{

    public class CartIndexViewModel
    {

        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }

        public CartIndexViewModel()
        {

        }

    }

}

