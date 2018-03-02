using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSFalpha1.Play.Item.Consumable.HealthPotion
{
    public sealed class HealthVial : HealthPotion
    {
        public HealthVial(int x, int y)
            : base(x, y)
        {
            healing = 45;
        }
        public HealthVial(int x, int y, bool a)
            : base(x, y, a)
        {
            healing = 45;
        }
        public override void LoadContent()
        {
            itemSprite = ContentLoader.ItemSprite(1);
        }
    }
}
