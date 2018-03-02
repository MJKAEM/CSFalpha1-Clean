using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace CSFalpha1.Play.Item.Consumable.HealthPotion
{
    public class HealthPotion : Consumable
    {
        protected int healing;

        public HealthPotion(int x, int y)
            : base(x, y)
        {
            healing = 480;
        }
        public HealthPotion(int x, int y, bool a)
            : base(x, y, a)
        {
            healing = 480;
        }
        public override void LoadContent()
        {
            itemSprite = ContentLoader.ItemSprite(5);
        }
        public override void UseItem()
        {

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
    }
}
