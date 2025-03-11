using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstract_Factory_Example.Interfaces;


namespace Abstract_Factory_Example.Devices.IProne
{
    public class IProneLaptop : ILaptop
    {
        public void DisplayInfo() => Console.WriteLine("IProne Laptop is successfully created");
    }
}
