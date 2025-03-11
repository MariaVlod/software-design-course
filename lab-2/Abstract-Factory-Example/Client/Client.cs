using Abstract_Factory_Example.Factories;
using Abstract_Factory_Example.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Factory_Example.Client
{
    public class Client
    {
        private readonly ILaptop _laptop;
        private readonly INetBook _netbook;
        private readonly IEBook _ebook;
        private readonly ISmartPhone _smartphone;

        public Client(IDeviceFactory factory)
        {
            _laptop = factory.CreateLaptop();
            _netbook = factory.CreateNetbook();
            _ebook = factory.CreateEBook();
            _smartphone = factory.CreateSmartphone();
        }

        public void Run()
        {
            _laptop.DisplayInfo();
            _netbook.DisplayInfo();
            _ebook.DisplayInfo();
            _smartphone.DisplayInfo();
        }
    }
}
