#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ContentLoader;
#endregion

namespace Item.Consumable.HealthPotion
{
    public sealed class HealthJar : HealthPotion
    {
        public HealthJar(byte x, byte y)
            : base(x, y)
        {
            ItemSprite = TheContentLoader.ConsSprite[5];

            Name = "Health Jar";
            Healing = 750;
        }
    }
}
