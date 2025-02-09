using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseLibrary
{
    public class Warehouse
    {
        public string Name { get; set; }
        public string Unit { get; set; }
        public Money UnitPrice { get; set; }
        public int Quantity { get; set; }
        public DateTime LastDeliveryDate { get; set; }

        public Warehouse(string name, string unit, Money unitPrice, int quantity, DateTime lastDeliveryDate)
        {
            Name = name;
            Unit = unit;
            UnitPrice = unitPrice;
            Quantity = quantity;
            LastDeliveryDate = lastDeliveryDate;
        }

        public void Display()
        {
            Console.WriteLine($"Warehouse Item: {Name}, Unit: {Unit}, Unit Price: ");
            UnitPrice.Display();
            Console.WriteLine($"Quantity: {Quantity}, Last Delivery Date: {LastDeliveryDate.ToShortDateString()}");
        }
    }
}
