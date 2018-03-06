using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ContentLoader;

namespace Item.Weapon.Mace
{
    public class Bin : AbstractMace
    {
        public Bin(byte x, byte y)
            : base(x, y)
        {
            ItemSprite = TheContentLoader.WeapSprite[31];

            Name = "Bin";
            ItemId = 31;
            SpaceX = 1;
            SpaceY = 3;
            MinDmg = 6;
            MaxDmg = 12;
            AttackSpeed = 6;
        }
    }
}
