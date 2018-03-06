using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ContentLoader;

namespace Item.Weapon.OneHSword
{
    public class HonGim : _1HSword
    {
        public HonGim(byte x, byte y)
            : base(x, y)
        {
            ItemSprite = TheContentLoader.WeapSprite[2];

            Name = "Hon Gim";
            ItemId = 2;
            SpaceX = 1;
            SpaceY = 3;
            MinDmg = 8;
            MaxDmg = 15;
            AttackSpeed = 5;
        }
    }
}
