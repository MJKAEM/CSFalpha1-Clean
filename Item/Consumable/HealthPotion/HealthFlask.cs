#region Using Statements
using System;
using System.Linq;
using System.Text;
using ContentLoader;
#endregion

namespace Item.Consumable.HealthPotion
{
    public sealed class HealthFlask : HealthPotion
    {
        public HealthFlask(byte x, byte y)
            : base(x, y)
        {
            ItemSprite = TheContentLoader.ConsSprite[2];

            Name = "Health Flask";
            Healing = 150;
        }
    }
}
