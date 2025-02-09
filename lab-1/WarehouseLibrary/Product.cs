using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseLibrary
{
    public enum ProductCategory
    {
        Electronics,
        Grocery,
        Clothing,
        Furniture
    }
    public class Product
    {
        public string Name { get; set; }
        public Money Price { get; set; }

        public Product(string name, Money price)
        {
            Name = name;
            Price = price;
        }

        public void ReducePrice(int dollars, int cents)
        {
            Money reduction = new Money(dollars, cents);
            Price.SetAmount(Price.Dollars - reduction.Dollars, Price.Cents - reduction.Cents);
        }

        public void Display()
        {
            Console.WriteLine($"Product: {Name}, Price: ");
            Price.Display();
        }
    }
}
