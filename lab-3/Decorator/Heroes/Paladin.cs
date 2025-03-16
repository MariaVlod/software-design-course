using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.Heroes
{
    public class Paladin : IHero
    {
        public string GetDescription() => "Paladin";
        public int GetPower() => 90;
    }
}
