using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseLibrary;

namespace WareHouseApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Testing Money Class ===");
            
            Money money = new Money(10, 150);
            Console.Write("Initial amount: ");
            money.Display(); 

            Console.WriteLine("\n=== Testing Product Class ===");
            
            Product product = new Product("Laptop", new Money(1000, 0));
            Console.Write("Initial product details: ");
            product.Display(); 

            Console.WriteLine("Reducing price by $100.50...");
            product.ReducePrice(100, 50);
            Console.Write("Updated product details: ");
            product.Display(); 

            Console.WriteLine("\n=== Testing Warehouse Class ===");
            
            Warehouse warehouseItem = new Warehouse("Laptop", "pcs", new Money(1000, 0), 10, DateTime.Now);
            Console.WriteLine("Warehouse item details:");
            warehouseItem.Display(); 

            Console.WriteLine("\n=== Testing Reporting Class ===");
            
            Reporting reporting = new Reporting();
            Console.WriteLine("Registering incoming item: Laptop...");
            reporting.RegisterIncoming(warehouseItem); 

            Console.WriteLine("Registering outgoing item: Laptop (quantity: 5)...");
            reporting.RegisterOutgoing("Laptop", 5); 

            Console.WriteLine("\nGenerating inventory report...");
            reporting.InventoryReport(); 
            Console.WriteLine("\n=== Testing Shopping Cart Functionality ===");
            
            ShoppingCart cart = new ShoppingCart();
            Console.WriteLine("Adding product to cart: Laptop...");
            cart.AddProduct(product);

            Console.WriteLine("\nDisplaying shopping cart contents:");
            cart.DisplayCart(); 

            Console.WriteLine("\n=== End of Tests ===");
        }
    }
}
