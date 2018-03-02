using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSFalpha1.Play.Item.Consumable.HealthPotion
{
    public sealed class HealthPot : HealthPotion
    {
        public HealthPot(int x, int y)
            : base(x, y)
        {
            healing = 5000;
        }
        public HealthPot(int x, int y, bool a)
            : base(x, y, a)
        {
            healing = 5000;
        }
        public override void LoadContent()
        {
            itemSprite = ContentLoader.ItemSprite(7);
        }
    }
}
