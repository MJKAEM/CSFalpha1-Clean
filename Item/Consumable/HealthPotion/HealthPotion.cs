#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ContentLoader;
#endregion

namespace Item.Consumable.HealthPotion
{
    public class HealthPotion : AbstractConsumable
    {
        private int healing;

        public HealthPotion(byte x, byte y)
            : base(x, y)
        {
            healing = 480;
            ItemSprite = TheContentLoader.ConsSprite[4];

            Name = "Health Potion";
        }
        public override void UseItem()
        {
            throw new NotImplementedException();
        }
        /*public Item PickupItem(MouseState mouseState, Item newItem)
        {
            if (base.PickupItem(mouseState, newItem) is HealthPotion)
            {
                quantity++;
                Console.WriteLine("Hi");
                return null;
            }
            else
            {
                return base.PickupItem(mouseState, newItem);
            }

        }*/
        public int Healing { get { return healing; } set { healing = value; } }
    }
}
