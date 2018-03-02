using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSFalpha1.Play.Item.Consumable.HealthPotion
{
    public sealed class HealthJar : HealthPotion
    {
        public HealthJar(int x, int y)
            : base(x, y)
        {
            healing = 750;
        }
        public HealthJar(int x, int y, bool a)
            : base(x, y, a)
        {
            healing = 750;
        }
        public override void LoadContent()
        {
            itemSprite = ContentLoader.ItemSprite(6);
        }
    }
}
