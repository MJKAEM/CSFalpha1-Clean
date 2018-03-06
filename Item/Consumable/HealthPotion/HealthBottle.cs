using System;
using System.Linq;
using System.Text;
using ContentLoader;

namespace Item.Consumable.HealthPotion
{
    public sealed class HealthBottle : HealthPotion
    {
        public HealthBottle(byte x, byte y)
            : base(x, y)
        {
            ItemSprite = TheContentLoader.ConsSprite[1];

            Name = "Health Bottle";
            Healing = 90;
        }
    }
}
