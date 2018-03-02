using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSFalpha1.Play.Item.Consumable.HealthPotion
{
    public sealed class HealthFlask : HealthPotion
    {
        public HealthFlask(int x, int y)
            : base(x, y)
        {
            healing = 150;
        }
        public HealthFlask(int x, int y, bool a)
            : base(x, y, a)
        {
            healing = 150;
        }
        public override void LoadContent()
        {
            itemSprite = ContentLoader.ItemSprite(3);
        }
    }
}
