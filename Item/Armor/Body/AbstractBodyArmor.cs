using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Item.Armor.Body
{
    public abstract class AbstractBodyArmor : AbstractArmor
    {
        protected AbstractBodyArmor(byte x, byte y)
            : base(x, y)
        {
            SpaceX = 2;
            SpaceY = 3;
        }
    }
}
