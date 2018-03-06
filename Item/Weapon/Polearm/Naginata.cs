using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ContentLoader;

namespace Item.Weapon.Polearm
{
    public class Naginata : AbstractPolearm
    {
        public Naginata(byte x, byte y)
            : base(x, y)
        {
            ItemSprite = TheContentLoader.WeapSprite[21];

            Name = "Naginata";
            ItemId = 21;
            SpaceX = 2;
            SpaceY = 4;
            MinDmg = 20;
            MaxDmg = 25;
            AttackSpeed = 7;
        }
    }
}
