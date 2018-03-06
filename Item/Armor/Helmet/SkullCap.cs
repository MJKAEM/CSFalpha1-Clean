#region Using Statement
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ContentLoader;
#endregion

namespace Item.Armor.Helmet
{
    public class SkullCap : AbstractHelmet
    {
        public SkullCap(byte x, byte y)
            : base(x, y)
        {
            ItemSprite = TheContentLoader.ArmorSprite[2];

            Name = "Skull Cap";
            SpaceX = 2;
            SpaceY = 2;
        }
    }
}
