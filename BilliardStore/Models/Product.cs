namespace BilliardStore.Models
{
    public class Product
    {
        
        // all properties need 'set' because below constructor doesn't set values for any fields     
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [System.ComponentModel.DataAnnotations.Schema.Column(TypeName = "Money")]
        public decimal Price { get; set; }
        public string Category { get; set; }        
        public int ProductCategoryID { get; set; }
        public string ImageUrlMain { get; set; }
        public string ImageUrlSecondary { get; set; }
        public string ImageUrlOptional { get; set; }
       
        public Product()
        {
            
        }

    }
}
