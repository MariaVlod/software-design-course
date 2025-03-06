using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public class Director
    {
        private ICharacterBuilder _builder;

        public Director(ICharacterBuilder builder)
        {
            _builder = builder;
        }

        public void ChangeBuilder(ICharacterBuilder builder)
        {
            _builder = builder;
        }

        public object CreateCharacter()
        {
            return _builder
                .SetHeight(180)
                .SetBuild("Slim")
                .SetHairColor("Blonde")
                .SetEyeColor("Blue")
                .SetClothing("Elven Armor made of mithril, adorned with leaf patterns")
                .AddToInventory("Bow of the Galadhrim")
                .AddToInventory("Quiver of endless arrows")
                .AddToInventory("Elven knife with engraved runes")
                .AddToInventory("Cloak of Lothlórien")
                .AddDeed("Saved the village of Rohan from an orc invasion")
                .AddDeed("Protected the Fellowship during their journey to Mordor")
                .AddDeed("Defeated the Uruk-hai at Helm's Deep")
                .Build();
        }

        public object CreateEvilCharacter()
        {
            return _builder
                .SetHeight(185)
                .SetBuild("Muscular")
                .SetHairColor("Black")
                .SetEyeColor("Brown")
                .SetClothing("Leather jacket with spikes, bloodstained jeans, and combat boots")
                .AddToInventory("Lucille (barbed wire-wrapped baseball bat)")
                .AddToInventory("Colt Python revolver")
                .AddToInventory("Knife with a skull handle")
                .AddDeed("Killed Glenn Rhee in front of his friends")
                .AddDeed("Enslaved multiple communities under his rule")
                .AddDeed("Tortured Daryl Dixon to break his spirit")
                .Build();
        }
    }
}
