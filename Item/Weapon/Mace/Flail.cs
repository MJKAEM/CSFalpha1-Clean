using System;
using System.Linq;
using System.Text;
using ContentLoader;

namespace Item.Weapon.Mace
{
    public class Flail : AbstractMace
    {
        public Flail(byte x, byte y)
            : base(x, y)
        {
            ItemSprite = TheContentLoader.WeapSprite[32];

            Name = "Flail";
            ItemId = 32;
            SpaceX = 2;
            SpaceY = 3;
            MinDmg = 3;
            MaxDmg = 15;
            AttackSpeed = 4;
        }
    }
}
