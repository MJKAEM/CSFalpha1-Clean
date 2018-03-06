using System;
using System.Linq;
using System.Text;

namespace Item.Armor.Boots
{
    public abstract class AbstractBoots : AbstractArmor
    {
        protected AbstractBoots(byte x, byte y)
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
