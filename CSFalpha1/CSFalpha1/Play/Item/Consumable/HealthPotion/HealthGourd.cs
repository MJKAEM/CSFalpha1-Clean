using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSFalpha1.Play.Item.Consumable.HealthPotion
{
    public sealed class HealthGourd : HealthPotion
    {
        public HealthGourd(int x, int y)
            : base(x, y)
        {
            healing = 270;
        }
        public HealthGourd(int x, int y, bool a)
            : base(x, y, a)
        {
            healing = 270;
        }
        public override void LoadContent()
        {
            itemSprite = ContentLoader.ItemSprite(4);
        }
    }
}
