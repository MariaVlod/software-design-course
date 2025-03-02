using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public class Director
    {
        public Hero CreateLegolas(HeroBuilder builder)
        {
            return builder
                .SetHeight(180)
                .SetBuild("Slim")
                .SetHairColor("Blonde")
                .SetEyeColor("Blue")
                .SetClothing("Elven Armor made of mithril, adorned with leaf patterns")
                .AddToInventory("Bow of the Galadhrim")
                .AddToInventory("Quiver of endless arrows")
                .AddToInventory("Elven knife with engraved runes")
                .AddToInventory("Cloak of Lothlórien")
                .AddGoodDeed("Saved the village of Rohan from an orc invasion")
                .AddGoodDeed("Protected the Fellowship during their journey to Mordor")
                .AddGoodDeed("Defeated the Uruk-hai at Helm's Deep")
                .Build();
        }

        public Enemy CreateNegan(EnemyBuilder builder)
        {
            return builder
                .SetHeight(185)
                .SetBuild("Muscular")
                .SetHairColor("Black")
                .SetEyeColor("Brown")
                .SetClothing("Leather jacket with spikes, bloodstained jeans, and combat boots")
                .AddToInventory("Lucille (barbed wire-wrapped baseball bat)")
                .AddToInventory("Colt Python revolver")
                .AddToInventory("Knife with a skull handle")
                .AddEvilDeed("Killed Glenn Rhee in front of his friends")
                .AddEvilDeed("Enslaved multiple communities under his rule")
                .AddEvilDeed("Tortured Daryl Dixon to break his spirit")
                .Build();
        }
    }
}
