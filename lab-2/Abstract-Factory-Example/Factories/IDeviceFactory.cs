using Abstract_Factory_Example.Devices;
using Abstract_Factory_Example.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Factory_Example.Factories
{
    public interface IDeviceFactory
    {
        ILaptop CreateLaptop();
        INetBook CreateNetbook();
        IEBook CreateEBook();
        ISmartPhone CreateSmartphone();
    }
}
