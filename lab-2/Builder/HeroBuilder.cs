using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public class HeroBuilder : ICharacterBuilder
    {
        private Hero _hero = new Hero();

        public ICharacterBuilder SetHeight(int height)
        {
            _hero.Height = height;
            return this;
        }

        public ICharacterBuilder SetBuild(string build)
        {
            _hero.Build = build;
            return this;
        }

        public ICharacterBuilder SetHairColor(string hairColor)
        {
            _hero.HairColor = hairColor;
            return this;
        }

        public ICharacterBuilder SetEyeColor(string eyeColor)
        {
            _hero.EyeColor = eyeColor;
            return this;
        }

        public ICharacterBuilder SetClothing(string clothing)
        {
            _hero.Clothing = clothing;
            return this;
        }

        public ICharacterBuilder AddToInventory(string item)
        {
            _hero.Inventory.Add(item);
            return this;
        }

        public ICharacterBuilder AddDeed(string deed)
        {
            _hero.GoodDeeds.Add(deed);
            return this;
        }

        public object Build()
        {
            return _hero;
        }

    }
}
