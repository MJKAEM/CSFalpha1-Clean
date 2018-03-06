using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ContentLoader;

namespace Item.Weapon.Mace
{
    public class Scepter : AbstractMace
    {
        public Scepter(byte x, byte y)
            : base(x, y)
        {
            ItemSprite = TheContentLoader.WeapSprite[30];

            Name = "Scepter";
            ItemId = 30;
            SpaceX = 1;
            SpaceY = 3;
            MinDmg = 5;
            MaxDmg = 8;
            AttackSpeed = 4;
        }
    }
}
