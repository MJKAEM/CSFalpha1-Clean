#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ContentLoader;
#endregion

namespace Item.Consumable.HealthPotion
{
    public sealed class HealthGourd : HealthPotion
    {
        public HealthGourd(byte x, byte y)
            : base(x, y)
        {
            ItemSprite = TheContentLoader.ConsSprite[3];

            Name = "Health Gourd";
            Healing = 270;
        }
    }
}
