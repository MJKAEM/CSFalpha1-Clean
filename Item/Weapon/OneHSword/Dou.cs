using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ContentLoader;

namespace Item.Weapon.OneHSword
{
    public class Dou : _1HSword
    {
        public Dou(byte x, byte y)
            : base(x, y)
        {
            ItemSprite = TheContentLoader.WeapSprite[3];

            Name = "Dou";
            ItemId = 3;
            SpaceX = 1;
            SpaceY = 3;
            MinDmg = 5;
            MaxDmg = 12;
            AttackSpeed = 6;
        }
    }
}
