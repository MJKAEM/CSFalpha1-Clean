using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ContentLoader;

namespace Item.Weapon.Mace
{
    public class WarHammer : AbstractMace
    {
        public WarHammer(byte x, byte y)
            : base(x, y)
        {
            ItemSprite = TheContentLoader.WeapSprite[33];

            Name = "War Hammer";
            ItemId = 33;
            SpaceX = 2;
            SpaceY = 3;
            MinDmg = 20;
            MaxDmg = 25;
            AttackSpeed = 7;
            TwoHand = true;
        }
    }
}
