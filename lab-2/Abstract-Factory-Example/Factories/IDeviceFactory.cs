using Abstract_Factory_Example.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Factory_Example.Factories
{
    public interface IDeviceFactory
    {
        Laptop CreateLaptop();
        Netbook CreateNetbook();
        EBook CreateEBook();
        Smartphone CreateSmartphone();
    }
}
