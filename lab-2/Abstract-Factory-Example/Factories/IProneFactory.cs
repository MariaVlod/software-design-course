using Abstract_Factory_Example.Devices;
using Abstract_Factory_Example.Devices.IProne;
using Abstract_Factory_Example.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Factory_Example.Factories
{
    public class IProneFactory : IDeviceFactory
    {
        public ILaptop CreateLaptop() => new IProneLaptop();
        public INetBook CreateNetbook() => new IProneNetbook();
        public IEBook CreateEBook() => new IProneEBook();
        public ISmartPhone CreateSmartphone() => new IProneSmartphone();
    }
}
