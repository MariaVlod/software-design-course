using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public class HeroBuilder
    {
        private Hero _hero = new Hero();

        public HeroBuilder SetHeight(int height)
        {
            _hero.Height = height;
            return this;
        }

        public HeroBuilder SetBuild(string build)
        {
            _hero.Build = build;
            return this;
        }

        public HeroBuilder SetHairColor(string hairColor)
        {
            _hero.HairColor = hairColor;
            return this;
        }

        public HeroBuilder SetEyeColor(string eyeColor)
        {
            _hero.EyeColor = eyeColor;
            return this;
        }

        public HeroBuilder SetClothing(string clothing)
        {
            _hero.Clothing = clothing;
            return this;
        }

        public HeroBuilder AddToInventory(string item)
        {
            _hero.Inventory.Add(item);
            return this;
        }

        public HeroBuilder AddGoodDeed(string deed)
        {
            _hero.GoodDeeds.Add(deed);
            return this;
        }

        public Hero Build()
        {
            return _hero;
        }
    }
}
