using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Item.Weapon.Polearm
{
    public abstract class AbstractPolearm : AbstractWeapon
    {
        protected AbstractPolearm(byte x, byte y)
            : base(x, y)
        {
            TwoHand = true;
        }
        public override void Woop()
        {
            base.Woop();

            if(SpaceY < 3)
            {
                Wimper.Spacemen(this);
            }
        }
    }
}
