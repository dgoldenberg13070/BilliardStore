//references Product.cs, uses CartLine class defined in this file (the 2nd class), 
//called by SessionCart.cs, index.cshtml, Default.cshtml, OrderController
using System.Linq;

namespace BilliardStore.Models
{

    public class Cart
    {

        private System.Collections.Generic.List<CartLine> lineCollection = new System.Collections.Generic.List<CartLine>();

        //empty constructor
        public Cart()
        {

        }

        //called by CartController.cs
        //this method is overloaded
        public virtual void AddItem(Product product, int quantity)
        {

            System.Collections.Generic.IEnumerable<CartLine> cartLines = lineCollection.Where(p => p.Product.ProductID == product.ProductID);
            CartLine line = cartLines.FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }

        }

        //methods below are virtual in case you want to override them
        //this method is overloaded
        public virtual void RemoveLine(Product product)
        {
            lineCollection.RemoveAll(l => l.Product.ProductID == product.ProductID);
        }

        //called by Index.cshtml
        public virtual decimal ComputeTotalValue()
        {
           return lineCollection.Sum(e => e.Product.Price * e.Quantity);            
        }
        
        //this method is overloaded
        public virtual void Clear()
        {
            lineCollection.Clear();
        }

        //called by Default.cshtml, OrderController.cs
        public virtual System.Collections.Generic.IEnumerable<CartLine> Lines
        {
            get
            { 
                return lineCollection;
            }
        }

    }

    //2nd class in this file
    public class CartLine
    {
        public int CartLineID { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }

        //empty constructor
        public CartLine()
        {

        }

    }

}
