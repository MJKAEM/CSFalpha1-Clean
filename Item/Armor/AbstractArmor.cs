#region Using Statements
using System;
using System.Linq;
using System.Text;
#endregion

namespace Item.Armor
{
    public abstract class AbstractArmor : AbstractEquipment
    {
        private ushort defense;

        protected AbstractArmor(byte x, byte y)
            : base(x, y)
        {
        }

        public ushort Defense { get { return defense; } set { defense = value; } }
    }
}
