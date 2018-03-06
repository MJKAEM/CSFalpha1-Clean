#region Using Statements
using System;
using System.Linq;
using System.Text;
using ContentLoader;
#endregion

namespace Item.Consumable.HealthPotion
{
    public sealed class HealthVial : HealthPotion
    {
        public HealthVial(byte x, byte y)
            : base(x, y)
        {
            ItemSprite = TheContentLoader.ConsSprite[0];

            Name = "Health Vial";
            Healing = 45;
        }
    }
}
