﻿using Abstract_Factory_Example.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Factory_Example.Devices.Kiaomi
{
    public class KiaomiNetbook : INetBook
    {
        public void DisplayInfo() => Console.WriteLine("Kiaomi NetBook is successfully created");
    }
}
