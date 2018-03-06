using System;
using System.Linq;
using System.Text;
using ContentLoader;

namespace Item.Weapon.Polearm
{
    public class GwaanDou : AbstractPolearm
    {
        public GwaanDou(byte x, byte y)
            : base(x, y)
        {
            ItemSprite = TheContentLoader.WeapSprite[22];

            Name = "Gwaan Dou";
            ItemId = 22;
            SpaceX = 2;
            SpaceY = 4;
            MinDmg = 20;
            MaxDmg = 32;
            AttackSpeed = 8;
        }
    }
}
