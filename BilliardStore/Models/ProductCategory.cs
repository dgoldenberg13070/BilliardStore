namespace BilliardStore.Models
{
    public class ProductCategory
    {
        // all properties need 'set' because below constructor doesn't set values for any fields     
        public int ProductCategoryID { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public System.Collections.Generic.ICollection<Product> Products { get; set; }

        public ProductCategory()
        {
            this.Products = new System.Collections.Generic.HashSet<Product>();
        }

    }
}
