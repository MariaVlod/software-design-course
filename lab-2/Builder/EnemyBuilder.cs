using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public class EnemyBuilder : ICharacterBuilder
    {
        private Enemy _enemy = new Enemy();

        public ICharacterBuilder SetHeight(int height)
        {
            _enemy.Height = height;
            return this;
        }

        public ICharacterBuilder SetBuild(string build)
        {
            _enemy.Build = build;
            return this;
        }

        public ICharacterBuilder SetHairColor(string hairColor)
        {
            _enemy.HairColor = hairColor;
            return this;
        }

        public ICharacterBuilder SetEyeColor(string eyeColor)
        {
            _enemy.EyeColor = eyeColor;
            return this;
        }

        public ICharacterBuilder SetClothing(string clothing)
        {
            _enemy.Clothing = clothing;
            return this;
        }

        public ICharacterBuilder AddToInventory(string item)
        {
            _enemy.Inventory.Add(item);
            return this;
        }

        public ICharacterBuilder AddDeed(string deed)
        {
            _enemy.EvilDeeds.Add(deed);
            return this;
        }

        public object Build()
        {
            return _enemy;
        }
    }
}
