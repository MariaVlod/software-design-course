using Abstract_Factory_Example.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Factory_Example.Devices.IProne
{
    public class IProneSmartphone : ISmartPhone
    {
        public void DisplayInfo() => Console.WriteLine("IProne Smartphone is successfully created");
    }
}
