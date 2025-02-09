using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseLibrary
{
    public class ShoppingCart
    {
        private List<Product> Products = new List<Product>();

        public void AddProduct(Product product)
        {
            Products.Add(product);
            Console.WriteLine($"Product added to cart: {product.Name}");
        }

        public void DisplayCart()
        {
            Console.WriteLine("Shopping Cart:");
            foreach (var product in Products)
            {
                product.Display();
            }
        }
    }
}
