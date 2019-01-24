//This is a class that implements the IProductRepository interface and gets its data using Entity Framework Core.
//It exists in the Models folder.
//referenced by Startup.cs
//calls ApplicationDbContext.cs

using System.Linq;

namespace BilliardStore.Models
{
    //inherits the IProductRepository.cs interface
    public class EFProductRepository : IProductRepository
    {
        //instance variable
        private ApplicationDbContext context;

        //this is the class constructor
        //a parameter called ctx of type ApplicationDbContext is passed into the constructor
        //the class instance variable 'context' is set to this parameter
        //the context instance variable is set in this constructor thus no 'set' is needed
        public EFProductRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        //the below must be implemented per the interface definition
        //It is an auto implemented get property that returns an object of IQueryable<Product> type
        //get is done here thus no auto implemented 'get' is used.
        //it calls the contructor for ApplicationDbContext in the ApplicationDbContext.cs file
        public System.Linq.IQueryable<Product> Products
        {
            get
            {
                return context.Products;
            }
        }

        public void SaveProduct(Product product)
        {
            if (product.ProductID == 0)
            {
                context.Products.Add(product);
            }
            else
            {
                Product dbEntry = context.Products.FirstOrDefault(p => p.ProductID == product.ProductID);
                if (dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = product.Price;
                    dbEntry.Category = product.Category;
                    dbEntry.ImageUrlMain = product.ImageUrlMain;
                    dbEntry.ImageUrlSecondary = product.ImageUrlSecondary;
                    dbEntry.ImageUrlOptional = product.ImageUrlOptional;
                }
            }
            context.SaveChanges();
        }

        public Product DeleteProduct(int productID)
        {
            Product dbEntry = context.Products.FirstOrDefault(p => p.ProductID == productID);
            if (dbEntry != null)
            {
                context.Products.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

    }

}
