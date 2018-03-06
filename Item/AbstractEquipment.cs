#region Using Statements
using System;
using System.Linq;
using System.Text;
#endregion

namespace Item
{
    public abstract class AbstractEquipment : AbstractItem
    {
        private byte durability, maxDurability;

        protected AbstractEquipment(byte x, byte y)
            : base(x, y)
        {
            maxDurability = 25;
        }

        public override void Woop()
        {
            base.Woop();

            if (durability > maxDurability)
            {
                Wimper.Varnish(this);
            }
            if (durability > 125)
            {
                Wimper.Varnish(this);
            }
        }
        public void Repair()
        {
            durability = maxDurability;
            Woop();
        }
        public byte Durability { get { return durability; } set { durability = value; } }
        public byte MaxDurability { get { return maxDurability; } set { maxDurability = value; } }
    }
}
