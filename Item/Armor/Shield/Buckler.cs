#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ContentLoader;
#endregion

namespace Item.Armor.Shield
{
    public class Buckler : AbstractShield
    {
        public Buckler(byte x, byte y)
            : base(x, y)
        {
            ItemSprite = TheContentLoader.ArmorSprite[20];

            Name = "Buckler";
            SpaceX = 2;
            SpaceY = 2;
            Defense = 5;
        }
    }
}
