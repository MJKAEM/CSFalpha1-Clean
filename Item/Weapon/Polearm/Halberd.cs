using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ContentLoader;

namespace Item.Weapon.Polearm
{
    public class Halberd : AbstractPolearm
    {
        public Halberd(byte x, byte y)
            : base(x, y)
        {
            ItemSprite = TheContentLoader.WeapSprite[23];

            Name = "Halberd";
            ItemId = 23;
            SpaceX = 2;
            SpaceY = 4;
            MinDmg = 10;
            MaxDmg = 35;
            AttackSpeed = 7;
        }
    }
}
