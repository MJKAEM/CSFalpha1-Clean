#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ContentLoader;
#endregion

namespace Item.Consumable.HealthPotion
{
    public sealed class HealthPot : HealthPotion
    {
        public HealthPot(byte x, byte y)
            : base(x, y)
        {
            ItemSprite = TheContentLoader.ConsSprite[6];

            Name = "Health Pot";
            Healing = 5000;
        }
    }
}
