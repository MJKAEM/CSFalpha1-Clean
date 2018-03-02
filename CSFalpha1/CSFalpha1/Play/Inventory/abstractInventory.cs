using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using CSFalpha1.Play.Level.NPC.Town;
using CSFalpha1.Play.Item;

namespace CSFalpha1.Play.Inventory
{
    public abstract class abstractInventory 
    {
        protected List<abstractItem> I;
        protected Texture2D inventorySprite;

        public abstractInventory()
        {
            I = new List<abstractItem>();
        }
        public virtual void LoadContent()
        {
            for (int i = 0; i < I.Count(); i++)
            {
                I.ElementAt(i).LoadContent();
            }
        }
        public virtual void ShowInventory(SpriteBatch sb, MouseState mouseState)
        {
            sb.Draw(inventorySprite, new Rectangle(0, (Game.Height - 480) / 2, 320, 480), new Color(200, 200, 200, 225));
            for (int i = 0; i < I.Count(); i++)
            {
                I.ElementAt(i).Show(sb);
            }
        }
        public abstract void CloseMenu(MouseState mouseState, Merchant npc);

        public abstractItem GetItem(int x, int y, abstractItem item)
        {
            for (int i = 0; i < I.Count(); i++)
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
        }
        public List<abstractItem> Item { get { return I; } }
    }
}
