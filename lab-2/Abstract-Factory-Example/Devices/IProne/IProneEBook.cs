using Abstract_Factory_Example.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Factory_Example.Devices.IProne
{
    public class IProneEBook : IEBook
    {
        public void DisplayInfo() => Console.WriteLine("IProne EBook is successfully created");
    }
}
