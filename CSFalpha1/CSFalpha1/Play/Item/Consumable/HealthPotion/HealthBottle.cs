using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSFalpha1.Play.Item.Consumable.HealthPotion
{
    public sealed class HealthBottle : HealthPotion
    {
        public HealthBottle(int x, int y)
            : base(x, y)
        {
            healing = 90;
        }
        public HealthBottle(int x, int y, bool a)
            : base(x, y, a)
        {
            healing = 90;
        }
        public override void LoadContent()
        {
            itemSprite = ContentLoader.ItemSprite(2);
        }
    }
}
