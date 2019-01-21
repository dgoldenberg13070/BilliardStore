namespace BilliardStore.Models
{

    public class Order
    {

        public Order()
        {

        }

        [Microsoft.AspNetCore.Mvc.ModelBinding.BindNever]
        public int OrderID { get; set; }

        [Microsoft.AspNetCore.Mvc.ModelBinding.BindNever]
        public System.Collections.Generic.ICollection<CartLine> Lines { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Please enter the first address line")]
        public string Line1 { get; set; }

        public string Line2 { get; set; }
        public string Line3 { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Please enter a city name")]
        public string City { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Please enter a state name")]
        public string State { get; set; }

        public string Zip { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Please enter a country name")]
        public string Country { get; set; }

    }

}
