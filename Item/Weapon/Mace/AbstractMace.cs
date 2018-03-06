using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Item.Weapon.Mace
{
    public abstract class AbstractMace : AbstractWeapon
    {
        protected AbstractMace(byte x, byte y)
            : base(x, y)
        {
            OneHand = true;
        }
        public override void Woop()
        {
            base.Woop();

            if (WeaponStat == 001 || WeaponStat == 011 || WeaponStat == 111)
            {
                MinDmg = 0;
                MaxDmg = 0;
            }
        }
    }
}
