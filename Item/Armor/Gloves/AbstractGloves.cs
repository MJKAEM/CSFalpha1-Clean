using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Item.Armor.Gloves
{
    public abstract class AbstractGloves : AbstractArmor
    {
        protected AbstractGloves(byte x, byte y)
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
