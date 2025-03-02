using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Factory_Example.Devices
{
    public class Smartphone : IDevice
    {
        private readonly string _brand;

        public Smartphone(string brand)
        {
            _brand = brand;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"{_brand} Smartphone");
        }
    }
}
