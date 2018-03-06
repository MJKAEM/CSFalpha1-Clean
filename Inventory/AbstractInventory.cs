#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
//using CSFalpha1.Play.Level.NPC.Town;
using Item;
using VideoDisplay;
#endregion

namespace Inventory
{
    public abstract class AbstractInventory 
    {
        private List<AbstractItem> I = new List<AbstractItem>();
        private Texture2D inventorySprite;
        private bool inventoryOpen;

        public abstract void ShowInventory(SpriteBatch sb);
        public abstract void CloseMenu(MouseState mouseState);

        /*public AbstractItem GetItem(int x, int y, AbstractItem item)
        {
            for (int i = I.Count - 1; i >= 0; i--)
            {
                if (x == I.ElementAt(i).PosX && y == I.ElementAt(i).PosY)
                {
                    if (!I.ElementAt(i).Equals(item))
                    {
                        return I.ElementAt(i);
                    }
                }
            }
            return null;
        }*/
        public List<AbstractItem> Item { get { return I; } }
        public Texture2D InventorySprite { get { return inventorySprite; } set { inventorySprite = value; } }
        public bool InventoryOpen { get { return inventoryOpen; } set { inventoryOpen = value; } }
    }
}
