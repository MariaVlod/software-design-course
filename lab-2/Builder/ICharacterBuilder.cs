﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public interface ICharacterBuilder
    {
        ICharacterBuilder SetName(string name);
        ICharacterBuilder SetHeight(int height);
        ICharacterBuilder SetBuild(string build);
        ICharacterBuilder SetHairColor(string color);
        ICharacterBuilder SetEyeColor(string color);
        ICharacterBuilder SetClothing(string clothing);
        ICharacterBuilder AddToInventory(string item);
        ICharacterBuilder AddDeed(string deed);
        Character Build();
    }
}
