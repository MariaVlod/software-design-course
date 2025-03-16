using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.Heroes
{
    public class Mage : IHero
    {
        public string GetDescription() => "Mage";
        public int GetPower() => 80;
    }
}
