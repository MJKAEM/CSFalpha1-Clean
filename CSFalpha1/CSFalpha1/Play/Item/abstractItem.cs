using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace CSFalpha1.Play.Item
{
    public abstract class abstractItem
    {
        protected int x, y, spaceX, spaceY;
        protected Texture2D itemSprite;
        protected bool playerItem;
        protected bool pickedUp;

        public abstractItem() { if (!(this is Nothing)) { Console.WriteLine("Do not use the default constructor!"); } }
        public abstractItem(int x, int y)
        {
            itemSprite = null;
            pickedUp = false;
            this.x = x;
            this.y = y;
            spaceX = 1;
            spaceY = 1;
        }
        public abstractItem(int x, int y, bool a)
        {
            itemSprite = null;
            pickedUp = false;
            this.x = x;
            this.y = y;
            spaceX = 1;
            spaceY = 1;
            playerItem = a;
        }
        public abstract void LoadContent();
        public void Show(SpriteBatch sb)
        {
            if (PlayState.Player.PInv.MouseStorage.Item != null)
            {
                if (!PlayState.Player.PInv.MouseStorage.Item.Equals(this))
                {
                    if (playerItem)
                    {
                        sb.Draw(itemSprite, new Rectangle(x * 30 + (Game.Width - 320) + 10, y * 30 + Game.Height / 2 + 10, itemSprite.Width, itemSprite.Height), Color.White);
                    }
                    else
                    {
                        sb.Draw(itemSprite, new Rectangle(x * 30 + 10, y * 30 + (Game.Height / 2 - 230), itemSprite.Width, itemSprite.Height), Color.White);
                    }
                }
            }
        }
        public abstractItem PickupItem(MouseState mouseState)
        {
            if (playerItem)
            {
                if (mouseState.X >= x * 30 + (Game.Width - 320) + 10 && mouseState.X <= x * 30 + (Game.Width - 320) + 10 + (spaceX * 30))
                {
                    if (mouseState.Y >= y * 30 + Game.Height / 2 + 10 && mouseState.Y <= y * 30 + Game.Height / 2 + 10 + (spaceY * 30))
                    {
                        PlayState.Player.PickUpItem = true;
                        return this;
                    }
                }
            }
            else
            {
                if (mouseState.X >= x * 30 + 10 && mouseState.X <= x * 30 + 10 + (spaceX * 30))
                {
                    if (mouseState.Y >= y * 30 + (Game.Height / 2 - 230) && mouseState.Y <= y * 30 + (Game.Height / 2 - 230) + (spaceY * 30))
                    {
                        PlayState.Player.PickUpItem = true;
                        return this;
                    }
                }
            }
            return null;
        }
        public abstractItem PickupItem(MouseState mouseState, abstractItem newItem)
        {
            if (mouseState.X > Game.Width / 2)
            {
                bool FactorX = false, FactorY = false;
                switch (newItem.SpaceX)
                {
                    case 0:
                        FactorX = mouseState.X >= x * 30 + (Game.Width - 320) + 10 && mouseState.X <= x * 30 + (Game.Width - 320) + 10 + (spaceX * 30);
                        break;
                    case 1:
                        FactorX = mouseState.X - 15 >= x * 30 + (Game.Width - 320) + 10 && mouseState.X - 15 <= x * 30 + (Game.Width - 320) + 10 + (spaceX * 30);
                        if (!FactorX)
                        {
                            FactorX = mouseState.X + 15 >= x * 30 + (Game.Width - 320) + 10 && mouseState.X + 15 <= x * 30 + (Game.Width - 320) + 10 + (spaceX * 30);
                        }
                        break;
                }
                switch (newItem.SpaceY)
                {
                    case 0:
                        FactorY = mouseState.Y >= y * 30 + Game.Height / 2 + 10 && mouseState.Y <= y * 30 + Game.Height / 2 + 10 + (spaceY * 30);
                        break;
                    case 1:
                        FactorY = mouseState.Y - 15 >= y * 30 + Game.Height / 2 + 10 && mouseState.Y - 15 <= y * 30 + Game.Height / 2 + 10 + (spaceY * 30);
                        if (!FactorY)
                        {
                            FactorY = mouseState.Y + 15 >= y * 30 + Game.Height / 2 + 10 && mouseState.Y + 15 <= y * 30 + Game.Height / 2 + 10 + (spaceY * 30);
                        }
                        break;
                    case 2:
                        FactorY = mouseState.Y >= y * 30 + Game.Height / 2 + 10 && mouseState.Y <= y * 30 + Game.Height / 2 + 10 + (spaceY * 30);
                        if (!FactorY)
                        {
                            FactorY = mouseState.Y - 30 >= y * 30 + Game.Height / 2 + 10 && mouseState.Y - 30 <= y * 30 + Game.Height / 2 + 10 + (spaceY * 30);
                        }
                        if (!FactorY)
                        {
                            FactorY = mouseState.Y + 30 >= y * 30 + Game.Height / 2 + 10 && mouseState.Y + 30 <= y * 30 + Game.Height / 2 + 10 + (spaceY * 30);
                        }
                        break;
                    case 3:
                        FactorY = mouseState.Y - 45 >= y * 30 + Game.Height / 2 + 10 && mouseState.Y - 45 <= y * 30 + Game.Height / 2 + 10 + (spaceY * 30);
                        if (!FactorY)
                        {
                            FactorY = mouseState.Y - 15 >= y * 30 + Game.Height / 2 + 10 && mouseState.Y - 15 <= y * 30 + Game.Height / 2 + 10 + (spaceY * 30);
                        }
                        if (!FactorY)
                        {
                            FactorY = mouseState.Y + 15 >= y * 30 + Game.Height / 2 + 10 && mouseState.Y + 15 <= y * 30 + Game.Height / 2 + 10 + (spaceY * 30);
                        }
                        if (!FactorY)
                        {
                            FactorY = mouseState.Y + 45 >= y * 30 + Game.Height / 2 + 10 && mouseState.Y + 45 <= y * 30 + Game.Height / 2 + 10 + (spaceY * 30);
                        }
                        break;
                    case 4:
                        FactorY = mouseState.Y - 75 >= y * 30 + Game.Height / 2 + 10 && mouseState.Y - 75 <= y * 30 + Game.Height / 2 + 10 + (spaceY * 30);
                        if (!FactorY)
                        {
                            FactorY = mouseState.Y - 45 >= y * 30 + Game.Height / 2 + 10 && mouseState.Y - 45 <= y * 30 + Game.Height / 2 + 10 + (spaceY * 30);
                        }
                        if (!FactorY)
                        {
                            FactorY = mouseState.Y - 15 >= y * 30 + Game.Height / 2 + 10 && mouseState.Y - 15 <= y * 30 + Game.Height / 2 + 10 + (spaceY * 30);
                        }
                        if (!FactorY)
                        {
                            FactorY = mouseState.Y + 25 >= y * 30 + Game.Height / 2 + 10 && mouseState.Y + 25 <= y * 30 + Game.Height / 2 + 10 + (spaceY * 30);
                        }
                        if (!FactorY)
                        {
                            FactorY = mouseState.Y + 55 >= y * 30 + Game.Height / 2 + 10 && mouseState.Y + 55 <= y * 30 + Game.Height / 2 + 10 + (spaceY * 30);
                        }
                        break;
                }
                if (FactorX)
                {
                    if (FactorY)
                    {
                        PlayState.Player.PickUpItem = true;
                        return this;
                    }
                }
                return null;
            }
            else
            {
                bool FactorX = false, FactorY = false;
                switch (newItem.SpaceX)
                {
                    case 0:
                        FactorX = mouseState.X >= x * 30 + 10 && mouseState.X <= x * 30 + 10 + (spaceX * 30);
                        break;
                    case 1:
                        FactorX = mouseState.X - 15 >= x * 30 + 10 && mouseState.X - 15 <= x * 30 + 10 + (spaceX * 30);
                        if (!FactorX)
                        {
                            FactorX = mouseState.X + 15 >= x * 30 + 10 && mouseState.X + 15 <= x * 30 + 10 + (spaceX * 30);
                        }
                        break;
                }
                switch (newItem.SpaceY)
                {
                    case 0:
                        FactorY = mouseState.Y >= y * 30 + (Game.Height / 2 - 230) && mouseState.Y <= y * 30 + (Game.Height / 2 - 230) + (spaceY * 30);
                        break;
                    case 1:
                        FactorY = mouseState.Y - 15 >= y * 30 + (Game.Height / 2 - 230) && mouseState.Y - 15 <= y * 30 + (Game.Height / 2 - 230) + (spaceY * 30);
                        if (!FactorY)
                        {
                            FactorY = mouseState.Y + 15 >= y * 30 + (Game.Height / 2 - 230) && mouseState.Y + 15 <= y * 30 + (Game.Height / 2 - 230) + (spaceY * 30);
                        }
                        break;
                    case 2:
                        FactorY = mouseState.Y >= y * 30 + (Game.Height / 2 - 230) && mouseState.Y <= y * 30 + (Game.Height / 2 - 230) + (spaceY * 30);
                        if (!FactorY)
                        {
                            FactorY = mouseState.Y - 30 >= y * 30 + (Game.Height / 2 - 230) && mouseState.Y - 30 <= y * 30 + (Game.Height / 2 - 230) + (spaceY * 30);
                        }
                        if (!FactorY)
                        {
                            FactorY = mouseState.Y + 30 >= y * 30 + (Game.Height / 2 - 230) && mouseState.Y + 30 <= y * 30 + (Game.Height / 2 - 230) + (spaceY * 30);
                        }
                        break;
                    case 3:
                        FactorY = mouseState.Y - 45 >= y * 30 + (Game.Height / 2 - 230) && mouseState.Y - 45 <= y * 30 + (Game.Height / 2 - 230) + (spaceY * 30);
                        if (!FactorY)
                        {
                            FactorY = mouseState.Y - 15 >= y * 30 + (Game.Height / 2 - 230) && mouseState.Y - 15 <= y * 30 + (Game.Height / 2 - 230) + (spaceY * 30);
                        }
                        if (!FactorY)
                        {
                            FactorY = mouseState.Y + 15 >= y * 30 + (Game.Height / 2 - 230) && mouseState.Y + 15 <= y * 30 + (Game.Height / 2 - 230) + (spaceY * 30);
                        }
                        if (!FactorY)
                        {
                            FactorY = mouseState.Y + 45 >= y * 30 + (Game.Height / 2 - 230) && mouseState.Y + 45 <= y * 30 + (Game.Height / 2 - 230) + (spaceY * 30);
                        }
                        break;
                    case 4:
                        FactorY = mouseState.Y - 75 >= y * 30 + (Game.Height / 2 - 230) && mouseState.Y - 75 <= y * 30 + (Game.Height / 2 - 230) + (spaceY * 30);
                        if (!FactorY)
                        {
                            FactorY = mouseState.Y - 45 >= y * 30 + (Game.Height / 2 - 230) && mouseState.Y - 45 <= y * 30 + (Game.Height / 2 - 230) + (spaceY * 30);
                        }
                        if (!FactorY)
                        {
                            FactorY = mouseState.Y - 15 >= y * 30 + (Game.Height / 2 - 230) && mouseState.Y - 15 <= y * 30 + (Game.Height / 2 - 230) + (spaceY * 30);
                        }
                        if (!FactorY)
                        {
                            FactorY = mouseState.Y + 25 >= y * 30 + (Game.Height / 2 - 230) && mouseState.Y + 25 <= y * 30 + (Game.Height / 2 - 230) + (spaceY * 30);
                        }
                        if (!FactorY)
                        {
                            FactorY = mouseState.Y + 55 >= y * 30 + (Game.Height / 2 - 230) && mouseState.Y + 55 <= y * 30 + (Game.Height / 2 - 230) + (spaceY * 30);
                        }
                        break;
                }
                if (FactorX)
                {
                    if (FactorY)
                    {
                        PlayState.Player.PickUpItem = true;
                        return this;
                    }
                }
            }
            return null;
        }
        public void ItemSprite2(SpriteBatch sb, GraphicsDevice gd, ContentManager cm, String a)
        {
            itemSprite = cm.Load<Texture2D>(a);
        }
        public bool PickedUp { get { return pickedUp; } set { pickedUp = value; } }
        public bool PlayerItem { get { return playerItem; } set { playerItem = value; } }
        public Texture2D ItemSprite { get { return itemSprite; } }
        public int PosX { get { return x; } set { x = value; } }
        public int PosY { get { return y; } set { y = value; } }
        public int SpaceX { get { return spaceX - 1; } }
        public int SpaceY { get { return spaceY - 1; } }
    }
}
