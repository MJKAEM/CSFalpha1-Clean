using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSFalpha1.Play.Item.Consumable
{
    public abstract class Consumable : abstractItem
    {
        public Consumable(int x, int y)
            : base(x, y)
        {
        }
        public Consumable(int x, int y, bool a)
            : base(x, y, a)
        {
        }
        public abstract void UseItem();
    }
}
