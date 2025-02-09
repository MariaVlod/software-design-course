using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseLibrary
{
    public class USD : Money
    {
        public USD(int dollars, int cents) : base(dollars, cents) { }
    }
}
