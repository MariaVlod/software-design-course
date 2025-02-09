using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseLibrary
{
    public class EUR : Money
    {
        public EUR(int euros, int cents) : base(euros, cents) { }
    }
}
