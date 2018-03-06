using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Item.Consumable
{
    public abstract class AbstractConsumable : AbstractItem
    {
        protected AbstractConsumable(byte x, byte y)
            : base(x, y)
        {
        }
        public abstract void UseItem();
        public override void Woop()
        {
            
        }
    }
}
