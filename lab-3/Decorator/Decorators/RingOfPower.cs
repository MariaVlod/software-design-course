using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.Decorators
{
    public class RingOfPower : HeroDecorator
    {
        public RingOfPower(IHero hero) : base(hero) { }

        public override string GetDescription() => _hero.GetDescription() + " with Ring of Power";
        public override int GetPower() => _hero.GetPower() + 50;
    }
}
