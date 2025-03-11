using Abstract_Factory_Example.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Factory_Example.Devices.Balaxy
{
    public class BalaxyNetbook : INetBook
    {
        public void DisplayInfo() => Console.WriteLine("Balaxy Netbook is successfully created");
    }
}
