namespace BilliardStore.Models
{

    public class Order
    {
        public Order()
        {
            //this.CartLines = new System.Collections.Generic.HashSet<CartLine>();
        }

       // public System.Collections.Generic.ICollection<CartLine> CartLines { get; set; }

        [Microsoft.AspNetCore.Mvc.ModelBinding.BindNever]
        public int OrderID { get; set; }

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

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Please enter the credit card number")]
        public string CardNumber {get; set;}

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Please enter the credit cart CVV code")]
        public string CVV { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Please enter the credit cart expiration date")]
        public System.DateTime? ExpirationDate { get; set; }

    }

}
