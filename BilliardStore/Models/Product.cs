namespace BilliardStore.Models
{
    public class Product
    {
        // all properties need 'set' because below constructor doesn't set values for any fields     
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string ImageUrl { get; set; }

        public Product()
        {

        }

    }
}
