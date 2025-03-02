using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public class EnemyBuilder
    {
        private Enemy _enemy = new Enemy();

        public EnemyBuilder SetHeight(int height)
        {
            _enemy.Height = height;
            return this;
        }

        public EnemyBuilder SetBuild(string build)
        {
            _enemy.Build = build;
            return this;
        }

        public EnemyBuilder SetHairColor(string hairColor)
        {
            _enemy.HairColor = hairColor;
            return this;
        }

        public EnemyBuilder SetEyeColor(string eyeColor)
        {
            _enemy.EyeColor = eyeColor;
            return this;
        }

        public EnemyBuilder SetClothing(string clothing)
        {
            _enemy.Clothing = clothing;
            return this;
        }

        public EnemyBuilder AddToInventory(string item)
        {
            _enemy.Inventory.Add(item);
            return this;
        }

        public EnemyBuilder AddEvilDeed(string deed)
        {
            _enemy.EvilDeeds.Add(deed);
            return this;
        }

        public Enemy Build()
        {
            return _enemy;
        }
    }
}
