#region Using Statements
using System;
using System.Linq;
using System.Text;
using ContentLoader;
#endregion

namespace Item.Armor.Shield
{
    public class HeaterShield : AbstractShield
    {
        public HeaterShield(byte x, byte y)
            : base(x, y)
        {
            ItemSprite = TheContentLoader.ArmorSprite[22];

            Name = "Heater Shield";
            SpaceX = 2;
            SpaceY = 3;
            Defense = 15;
        }
    }
}
