using Abstract_Factory_Example.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Factory_Example.Factories
{
    public class BalaxyFactory : IDeviceFactory
    {
        public Laptop CreateLaptop()
        {
            return new Laptop("Balaxy");
        }

        public Netbook CreateNetbook()
        {
            return new Netbook("Balaxy");
        }

        public EBook CreateEBook()
        {
            return new EBook("Balaxy");
        }

        public Smartphone CreateSmartphone()
        {
            return new Smartphone("Balaxy");
        }
    }
}
