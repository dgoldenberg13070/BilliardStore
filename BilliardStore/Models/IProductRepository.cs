//referenced by NavigationMenuViewComponent.cs, ProductController.cs, Startup.cs, 

namespace BilliardStore.Models
{
    //defines an interface. This ends up being used in the EFProductRepository.cs file
    public interface IProductRepository
    {
        //Below is the only line. It is an auto implemented get property for the variable 'Products' which is of IQueryable<Product> type
        //The IQueryable<T> interface is derived from the IEnumerable<T> interface and represents a collection of objects that can be queried.
        //The IQueryable<T> interface allows me to use LINQ statements.
        System.Linq.IQueryable<Product> Products { get; }

        void SaveProduct(Product product);

        Product DeleteProduct(int productID);
    }
}
