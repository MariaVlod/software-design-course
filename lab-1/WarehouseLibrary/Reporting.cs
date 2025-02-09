using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseLibrary
{
    public class Reporting
    {
        private List<Warehouse> WarehouseItems = new List<Warehouse>();

        public void RegisterIncoming(Warehouse item)
        {
            WarehouseItems.Add(item);
            Console.WriteLine($"Incoming registered: {item.Name}");
        }

        public void RegisterOutgoing(string name, int quantity)
        {
            var item = WarehouseItems.Find(i => i.Name == name);
            if (item != null && item.Quantity >= quantity)
            {
                item.Quantity -= quantity;
                Console.WriteLine($"Outgoing registered: {name}, Quantity: {quantity}");
            }
            else
            {
                Console.WriteLine($"Not enough quantity for {name}");
            }
        }

        public void InventoryReport()
        {
            Console.WriteLine("Inventory Report:");
            foreach (var item in WarehouseItems)
            {
                item.Display();
            }
        }
    }
}
