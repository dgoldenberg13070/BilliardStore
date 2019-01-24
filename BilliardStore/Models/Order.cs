namespace BilliardStore.Models
{

    public class Order
    {
        public Order()
        {
            //this.CartLines = new System.Collections.Generic.HashSet<CartLine>();
        }
           
        [Microsoft.AspNetCore.Mvc.ModelBinding.BindNever]
        public int OrderID { get; set; }

        [Microsoft.AspNetCore.Mvc.ModelBinding.BindNever]
        public System.Collections.Generic.ICollection<CartLine> Lines { get; set; }

        [Microsoft.AspNetCore.Mvc.ModelBinding.BindNever]
        public bool Shipped { get; set; }

        public string TrackingNumber { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Please enter your email address")]
        public string Email { get; set; }

        public System.DateTime PlacementDate { get; set; }
        public System.DateTime? ShipDate { get; set; }
        public System.DateTime? DeliveryDate { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.Column(TypeName = "Money")]
        public decimal SubTotal { get; set; }
        [System.ComponentModel.DataAnnotations.Schema.Column(TypeName = "Money")]
        public decimal Tax { get; set; }
        [System.ComponentModel.DataAnnotations.Schema.Column(TypeName = "Money")]
        public decimal Shipping { get; set; }
        [System.ComponentModel.DataAnnotations.Schema.Column(TypeName = "Money")]
        public decimal Total { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Please enter your phone number")]
        public string Phone { get; set; }       

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Please enter the first address line")]
        public string Street1 { get; set; }

        public string Street2 { get; set; }
        
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Please enter a city name")]
        public string City { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Please enter a state name")]
        public string State { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Please enter a zip code")]
        public string PostalCode { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Invalid or incomplete credit card information")]
        public string BraintreeNonce { get; set; }
       
    }

}
