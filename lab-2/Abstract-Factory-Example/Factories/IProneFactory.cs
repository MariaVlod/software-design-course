using Abstract_Factory_Example.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Factory_Example.Factories
{
    public class IProneFactory : IDeviceFactory
    {
        public Laptop CreateLaptop()
        {
            return new Laptop("IProne");
        }

        public Netbook CreateNetbook()
        {
            return new Netbook("IProne");
        }

        public EBook CreateEBook()
        {
            return new EBook("IProne");
        }

        public Smartphone CreateSmartphone()
        {
            return new Smartphone("IProne");
        }
    }
}
