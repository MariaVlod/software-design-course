using Abstract_Factory_Example.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Factory_Example.Factories
{
    public class KiaomiFactory : IDeviceFactory
    {
        public Laptop CreateLaptop()
        {
            return new Laptop("Kiaomi");
        }

        public Netbook CreateNetbook()
        {
            return new Netbook("Kiaomi");
        }

        public EBook CreateEBook()
        {
            return new EBook("Kiaomi");
        }

        public Smartphone CreateSmartphone()
        {
            return new Smartphone("Kiaomi");
        }
    }
}
