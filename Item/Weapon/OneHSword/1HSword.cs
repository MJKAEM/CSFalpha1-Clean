using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ErrorDepartment;

namespace Item.Weapon.OneHSword
{
    public abstract class _1HSword : AbstractWeapon
    {
        protected _1HSword(byte x, byte y)
            : base(x, y)
        {
            OneHand = true;
        }
        public override void Woop()
        {
            base.Woop();

            if (!OneHand)
            {
                for (; ; )
                    ConsolePrinter.RedPrint(this + " is _1HSword!");
            }
        }
    }
}
