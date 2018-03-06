using System;
using System.Linq;
using System.Text;
using ContentLoader;

namespace Item.Weapon.Polearm
{
    public class Cheong : AbstractPolearm
    {
        public Cheong(byte x, byte y)
            : base(x, y)
        {
            ItemSprite = TheContentLoader.WeapSprite[20];

            Name = "Cheong";
            ItemId = 20;
            SpaceX = 1;
            SpaceY = 4;
            MinDmg = 20;
            MaxDmg = 25;
            AttackSpeed = 7;
        }
        public override void Woop()
        {
            base.Woop();

            if (MinDmg != 20 || MaxDmg != 25)
            {
                MinDmg = 0;
                MaxDmg = 0;
            }
        }
    }
}
