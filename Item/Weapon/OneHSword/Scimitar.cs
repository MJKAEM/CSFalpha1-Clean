using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ContentLoader;

namespace Item.Weapon.OneHSword
{
    public class Scimitar : _1HSword
    {
        public Scimitar(byte x, byte y)
            : base(x, y)
        {
            ItemSprite = TheContentLoader.WeapSprite[0];

            Name = "Scimitar";
            ItemId = 0;
            SpaceX = 1;
            SpaceY = 3;
            MinDmg = 2;
            MaxDmg = 5;
            AttackSpeed = 3;
        }
    }
}
