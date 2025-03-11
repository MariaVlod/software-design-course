using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public class EnemyBuilder : ICharacterBuilder
    {
        private Character _character = new Character();

        public EnemyBuilder() => Reset();

        public void Reset() => _character = new Character();
        public ICharacterBuilder SetName(string name) { _character.Name = name; return this; }
        public ICharacterBuilder SetHeight(int height) { _character.Height = height; return this; }
        public ICharacterBuilder SetBuild(string build) { _character.Build = build; return this; }
        public ICharacterBuilder SetHairColor(string color) { _character.HairColor = color; return this; }
        public ICharacterBuilder SetEyeColor(string color) { _character.EyeColor = color; return this; }
        public ICharacterBuilder SetClothing(string clothing) { _character.Clothing = clothing; return this; }
        public ICharacterBuilder AddToInventory(string item) { _character.Inventory.Add(item); return this; }
        public ICharacterBuilder AddDeed(string deed) { _character.Deeds.Add(deed); return this; }

        public Character Build()
        {
            Character result = _character;
            Reset();
            return result;
        }
    }
}
