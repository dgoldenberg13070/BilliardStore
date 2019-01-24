namespace BilliardStore.Models
{
    public class Product
    {
        
        // all properties need 'set' because below constructor doesn't set values for any fields     
        public int ProductID { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Please enter a product name")]
        public string Name { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Please enter a description")]
        public string Description { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive price")]
        [System.ComponentModel.DataAnnotations.Schema.Column(TypeName = "Money")]
        public decimal Price { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Please specify a category")]
        public string Category { get; set; }        
    //  public int ProductCategoryID { get; set; }
        public string ImageUrlMain { get; set; }
        public string ImageUrlSecondary { get; set; }
        public string ImageUrlOptional { get; set; }
       
        public Product()
        {
            
        }

    }
}
