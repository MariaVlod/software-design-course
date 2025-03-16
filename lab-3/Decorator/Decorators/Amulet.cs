using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.Decorators
{
    public class Amulet : HeroDecorator
    {
        public Amulet(IHero hero) : base(hero) { }

        public override string GetDescription() => _hero.GetDescription() + " with Amulet";
        public override int GetPower() => _hero.GetPower() + 15;
    }
}
