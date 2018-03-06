using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Item.Armor.Belt
{
    public abstract class AbstractBelt : AbstractArmor
    {
        protected AbstractBelt(byte x, byte y)
            : base(x, y)
        {
            SpaceX = 2;
            SpaceY = 1;
        }
        public override void Woop()
        {
            base.Woop();

            if (SpaceX < 1 || SpaceY < 0)
            {

            }
        }
    }
}
