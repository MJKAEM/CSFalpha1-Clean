using System;
using System.Linq;
using System.Text;
using ContentLoader;

namespace Item.Weapon.OneHSword
{
    public class ShortSword : _1HSword
    {
        public ShortSword(byte x, byte y)
            : base(x, y)
        {
            ItemSprite = TheContentLoader.WeapSprite[1];

            Name = "Short Sword";
            ItemId = 1;
            SpaceX = 1;
            SpaceY = 3;
            MinDmg = 7;
            MaxDmg = 10;
            AttackSpeed = -3;
            MaxDurability = 25;
            Durability = 25;
        }
        public override void Woop()
        {
            base.Woop();

            switch (WeaponStat)
            {
                case 000:
                    if (MinDmg != 7 || MaxDmg != 10)
                    {
                        MinDmg = 0;
                        MaxDmg = 0;
                    }
                    break;

                case 001:
                    if (MinDmg != 12 || MaxDmg != 15)
                    {
                        MinDmg = 0;
                        MaxDmg = 0;
                    }
                    break;

                case 010:
                    if (MinDmg != 7 || MaxDmg != 10)
                    {
                        MinDmg = 0;
                        MaxDmg = 0;
                    }
                    break;

                case 011:
                    if (MinDmg != 7 || MaxDmg != 10)
                    {
                        MinDmg = 0;
                        MaxDmg = 0;
                    }
                    break;
            }
        }
    }
}
