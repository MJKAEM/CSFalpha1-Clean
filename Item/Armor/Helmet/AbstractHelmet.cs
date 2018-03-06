#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion

namespace Item.Armor.Helmet
{
    public abstract class AbstractHelmet : AbstractArmor
    {
        protected AbstractHelmet(byte x, byte y)
            : base(x, y)
        {
            SpaceX = 2;
            SpaceY = 2;
        }
        public override void Woop()
        {
            base.Woop();

            if (SpaceX < 1 || SpaceY < 1)
            {
                Wimper.Spacemen(this);
            }
        }
    }
}
