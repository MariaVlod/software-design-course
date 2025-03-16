using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.Decorators
{
    public class WitcherPotion : HeroDecorator
    {
        public WitcherPotion(IHero hero) : base(hero) { }

        public override string GetDescription() => _hero.GetDescription() + " with Witcher Potion";
        public override int GetPower() => _hero.GetPower() + 40;
    }
}
