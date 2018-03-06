using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Item.Armor.Shield
{
    public abstract class AbstractShield : AbstractArmor
    {
        protected AbstractShield(byte x, byte y)
            : base(x, y)
        {

        }
    }
}
