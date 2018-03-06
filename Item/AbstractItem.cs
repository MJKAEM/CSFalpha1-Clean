#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Item.Weapon;
using VideoDisplay;
#endregion

namespace Item
{
    public abstract class AbstractItem
    {
        private const byte INVENTORY = 0, HELMET = 1, RIGHT_HAND = 2, BODY = 3, LEFT_HAND = 4, GLOVES = 5,
            BELT = 6, BOOTS = 7, AMULET = 8, RING1 = 9, RING2 = 10;
        private ushort itemId;
        private byte x, y, spaceX, spaceY;
        private Texture2D itemSprite;
        private byte equipped;
        private bool pickedUp;
        private string name;

        /// <summary>
        /// The base class for all the items in the game.
        /// </summary>
        /// <param name="x">Position on the X grid of the inventory.</param>
        /// <param name="y">Position on the Y grid of the inventory.</param>
        protected AbstractItem(byte x, byte y)
        {
            name = "Gimme a name.";
            this.x = x;
            this.y = y;
            spaceX = 1;
            spaceY = 1;
            itemId = 0;
        }

        /// <summary>
        /// Show an item that is in the player's inventory.
        /// </summary>
        /// <param name="sb"></param>
        public void Show(SpriteBatch sb)
        {
            sb.Draw(itemSprite, new Vector2(x * 30 + (VideoVariables.ResolutionWidth - 320) + 10, y * 30 + VideoVariables.ResolutionHeight / 2 + 10), Color.White);
        }

        /// <summary>
        /// Show an item on the left side of the inventory.  Used for the stash or merchant NPC.
        /// </summary>
        /// <param name="sb"></param>
        public void ElseShow(SpriteBatch sb)
        {
            sb.Draw(itemSprite, new Vector2(x * 30 + 10, y * 30 + (VideoVariables.ResolutionHeight / 2 - 230)), Color.White);
        }

        /// <summary>
        /// Show an item that a player has equipped. Uses the actual x and y location on the screen.
        /// Unless you are adding an extra equipment slot (like a watch), do not use this.
        /// </summary>
        /// <param name="sb">SpriteBatch</param>
        /// <param name="x">Protip: VideoVariables.ResolutionWidth - 320.</param>
        /// <param name="y"></param>
        public void EquipShow(SpriteBatch sb, int x, int y)
        {
            sb.Draw(itemSprite, new Vector2(x, y), Color.White);
        }
        /// <summary>
        /// If mouse position is within the area of the item, it will return itself.
        /// </summary>
        /// <param name="mouseState">MouseState</param>
        /// <returns>This item or null.</returns>
        public AbstractItem UseItem(MouseState mouseState)
        {
            if (mouseState.X >= x * 30 + (VideoVariables.ResolutionWidth - 320) + 10 && mouseState.X <= x * 30 + (VideoVariables.ResolutionWidth - 320) + 10 + (spaceX * 30))
            {
                if (mouseState.Y >= y * 30 + VideoVariables.ResolutionHeight / 2 + 10 && mouseState.Y <= y * 30 + VideoVariables.ResolutionHeight / 2 + 10 + (spaceY * 30))
                {
                    return this;
                }
            }
            return null;
        }

        public AbstractItem PickupItem(MouseState mouseState)
        {
            switch (equipped)
            {
                case INVENTORY:
                    if (mouseState.X >= x * 30 + (VideoVariables.ResolutionWidth - 320) + 10 && mouseState.X <= x * 30 + (VideoVariables.ResolutionWidth - 320) + 10 + (spaceX * 30))
                    {
                        if (mouseState.Y >= y * 30 + VideoVariables.ResolutionHeight / 2 + 10 && mouseState.Y <= y * 30 + VideoVariables.ResolutionHeight / 2 + 10 + (spaceY * 30))
                        {
                            return this;
                        }
                    }
                    break;

                #region Helmet Unequip
                case HELMET:
                    if (mouseState.X >= (VideoVariables.ResolutionWidth - 320) + 129 && mouseState.X <= (VideoVariables.ResolutionWidth - 320) + 129 + 60)
                    {
                        if (mouseState.Y >= VideoVariables.ResolutionHeight / 2 - 230 && mouseState.Y <= VideoVariables.ResolutionHeight / 2 - 230 + 60)
                        {
                            return this;
                        }
                    }

                    break;
                #endregion

                #region Right Hand Unequip
                case RIGHT_HAND:
                    if (mouseState.X > (VideoVariables.ResolutionWidth - 320) + 15 && mouseState.X < (VideoVariables.ResolutionWidth - 320) + 15 + 60)
                    {
                        if (mouseState.Y > VideoVariables.ResolutionHeight / 2 - 190 && mouseState.Y < VideoVariables.ResolutionHeight / 2 - 190 + 120)
                        {
                            return this;
                        }
                    }
                    break;
                #endregion

                #region Body Unequip
                case BODY:
                    if (mouseState.X > (VideoVariables.ResolutionWidth - 320) + 129 && mouseState.X < (VideoVariables.ResolutionWidth - 320) + 129 + 60)
                    {
                        if (mouseState.Y > VideoVariables.ResolutionHeight / 2 - 160 && mouseState.Y < VideoVariables.ResolutionHeight / 2 - 160 + 90)
                        {
                            return this;
                        }
                    }
                    break;
                #endregion

                #region Left Hand Unequip
                case LEFT_HAND:
                    if (mouseState.X > (VideoVariables.ResolutionWidth - 320) + 244 && mouseState.X < (VideoVariables.ResolutionWidth - 320) + 244 + 60)
                    {
                        if (mouseState.Y > VideoVariables.ResolutionHeight / 2 - 190 && mouseState.Y < VideoVariables.ResolutionHeight / 2 - 190 + 120)
                        {
                            return this;
                        }
                    }
                    break;
                #endregion

                #region Gloves Unequip
                case GLOVES:
                    if (mouseState.Y > VideoVariables.ResolutionHeight / 2 - 60 && mouseState.Y < VideoVariables.ResolutionHeight / 2 - 60 + 60)
                    {
                        if (mouseState.X > (VideoVariables.ResolutionWidth - 320) + 15 && mouseState.X < (VideoVariables.ResolutionWidth - 320) + 15 + 60)
                        {
                            return this;
                        }
                    }
                    break;
                #endregion

                #region Belt Unequip
                case BELT:
                    if (mouseState.X > (VideoVariables.ResolutionWidth - 320) + 129 && mouseState.X < (VideoVariables.ResolutionWidth - 320) + 129 + 60)
                    {
                        if (mouseState.Y > VideoVariables.ResolutionHeight / 2 - 60 && mouseState.Y < VideoVariables.ResolutionHeight / 2 - 60 + 30)
                        {
                            return this;
                        }
                    }
                    break;
                #endregion

                #region Boots Enequip
                case BOOTS:
                    if (mouseState.Y > VideoVariables.ResolutionHeight / 2 - 60 && mouseState.Y < VideoVariables.ResolutionHeight / 2 - 60 + 60)
                    {
                        if (mouseState.X > (VideoVariables.ResolutionWidth - 320) + 244 && mouseState.X < (VideoVariables.ResolutionWidth - 320) + 244 + 60)
                        {
                            return this;
                        }
                    }
                    break;
                #endregion
            }
            return null;
        }
        public AbstractItem PickupItemStash(MouseState mouseState)
        {
            if (mouseState.X >= x * 30 + 10 && mouseState.X <= x * 30 + 10 + (spaceX * 30))
            {
                if (mouseState.Y >= y * 30 + (VideoVariables.ResolutionHeight / 2 - 230) && mouseState.Y <= y * 30 + (VideoVariables.ResolutionHeight / 2 - 230) + (spaceY * 30))
                {
                    return this;
                }
            }
            return null;
        }
        public AbstractItem PickupItem(MouseState mouseState, AbstractItem newItem)
        {
            if (mouseState.X > VideoVariables.ResolutionWidth / 2)
            {
                bool FactorX = false, FactorY = false;

                switch (newItem.SpaceX)
                {
                    case 0:
                        FactorX = mouseState.X >= x * 30 + (VideoVariables.ResolutionWidth - 320) + 10 && mouseState.X <= x * 30 + (VideoVariables.ResolutionWidth - 320) + 10 + (spaceX * 30);
                        break;
                    case 1:
                        FactorX = mouseState.X - 15 >= x * 30 + (VideoVariables.ResolutionWidth - 320) + 10 && mouseState.X - 15 <= x * 30 + (VideoVariables.ResolutionWidth - 320) + 10 + (spaceX * 30);
                        if (!FactorX)
                        {
                            FactorX = mouseState.X + 15 >= x * 30 + (VideoVariables.ResolutionWidth - 320) + 10 && mouseState.X + 15 <= x * 30 + (VideoVariables.ResolutionWidth - 320) + 10 + (spaceX * 30);
                        }
                        if (!FactorX && x == 1)
                        {
                            FactorX = mouseState.X >= (VideoVariables.ResolutionWidth - 320) + 10 && mouseState.X <= (VideoVariables.ResolutionWidth - 320) + 10 + 30 + (spaceX * 30);
                        }
                        if (!FactorX && x >= 7)
                        {
                            FactorX = mouseState.X >= (x * 30) + (VideoVariables.ResolutionWidth - 320) + 10 + 15 && mouseState.X <= (x * 30) + (VideoVariables.ResolutionWidth - 320) + 10 + 30 + (spaceX * 30);
                        }
                        break;
                }
                switch (newItem.SpaceY)
                {
                    case 0:
                        FactorY = mouseState.Y >= y * 30 + VideoVariables.ResolutionHeight / 2 + 10 && mouseState.Y <= y * 30 + VideoVariables.ResolutionHeight / 2 + 10 + (spaceY * 30);
                        break;
                    case 1:
                        FactorY = mouseState.Y - 15 >= y * 30 + VideoVariables.ResolutionHeight / 2 + 10 && mouseState.Y - 15 <= y * 30 + VideoVariables.ResolutionHeight / 2 + 10 + (spaceY * 30);
                        if (!FactorY)
                        {
                            FactorY = mouseState.Y + 15 >= y * 30 + VideoVariables.ResolutionHeight / 2 + 10 && mouseState.Y + 15 <= y * 30 + VideoVariables.ResolutionHeight / 2 + 10 + (spaceY * 30);
                        }
                        if (!FactorY && y == 1)
                        {
                            FactorY = mouseState.Y >= VideoVariables.ResolutionHeight / 2 + 10 && mouseState.Y <= VideoVariables.ResolutionHeight / 2 + 10 + 30 + (newItem.SpaceY * 30);
                        }
                        if (!FactorY && y >= 3)
                        {
                            FactorY = mouseState.Y >= y * 30 + VideoVariables.ResolutionHeight / 2 + 10 + 15 && mouseState.Y <= y * 30 + VideoVariables.ResolutionHeight / 2 + 10 + 30 + (newItem.SpaceY * 30);
                        }
                        break;
                    case 2:
                        FactorY = mouseState.Y >= y * 30 + VideoVariables.ResolutionHeight / 2 + 10 && mouseState.Y <= y * 30 + VideoVariables.ResolutionHeight / 2 + 10 + (spaceY * 30);
                        if (!FactorY)
                        {
                            FactorY = mouseState.Y - 30 >= y * 30 + VideoVariables.ResolutionHeight / 2 + 10 && mouseState.Y - 30 <= y * 30 + VideoVariables.ResolutionHeight / 2 + 10 + (spaceY * 30);
                        }
                        if (!FactorY)
                        {
                            FactorY = mouseState.Y + 30 >= y * 30 + VideoVariables.ResolutionHeight / 2 + 10 && mouseState.Y + 30 <= y * 30 + VideoVariables.ResolutionHeight / 2 + 10 + (spaceY * 30);
                        }
                        if (!FactorY && y == 2)
                        {
                            FactorY = mouseState.Y >= VideoVariables.ResolutionHeight / 2 + 10 && mouseState.Y <= VideoVariables.ResolutionHeight / 2 + 10 + 30 + (newItem.SpaceY * 30);
                        }
                        if (!FactorY && y >= 2)
                        {
                            FactorY = mouseState.Y >= y * 30 + VideoVariables.ResolutionHeight / 2 + 10 + 15 && mouseState.Y <= y * 30 + VideoVariables.ResolutionHeight / 2 + 10 + 30 + 90;
                        }
                        if ((!FactorY && y >= 1 && spaceY == 2) || (!FactorY && spaceY == 3))
                        {
                            FactorY = mouseState.Y >= VideoVariables.ResolutionHeight / 2 + 10 + 120 && mouseState.Y <= VideoVariables.ResolutionHeight / 2 + 10 + 30 + 120;
                        }
                        break;
                    case 3:
                        FactorY = mouseState.Y - 45 >= y * 30 + VideoVariables.ResolutionHeight / 2 + 10 && mouseState.Y - 45 <= y * 30 + VideoVariables.ResolutionHeight / 2 + 10 + (spaceY * 30);
                        if (!FactorY)
                        {
                            FactorY = mouseState.Y - 15 >= y * 30 + VideoVariables.ResolutionHeight / 2 + 10 && mouseState.Y - 15 <= y * 30 + VideoVariables.ResolutionHeight / 2 + 10 + (spaceY * 30);
                        }
                        if (!FactorY)
                        {
                            FactorY = mouseState.Y + 15 >= y * 30 + VideoVariables.ResolutionHeight / 2 + 10 && mouseState.Y + 15 <= y * 30 + VideoVariables.ResolutionHeight / 2 + 10 + (spaceY * 30);
                        }
                        if (!FactorY)
                        {
                            FactorY = mouseState.Y + 45 >= y * 30 + VideoVariables.ResolutionHeight / 2 + 10 && mouseState.Y + 45 <= y * 30 + VideoVariables.ResolutionHeight / 2 + 10 + (spaceY * 30);
                        }
                        if (!FactorY && y <= 3 && y > 0)
                        {
                            FactorY = mouseState.Y >= VideoVariables.ResolutionHeight / 2 + 10 && mouseState.Y <= VideoVariables.ResolutionHeight / 2 + 10 + 30 + (newItem.SpaceY * 30);
                        }
                        if (!FactorY && y >= 1)
                        {
                            FactorY = mouseState.Y >= y * 30 + VideoVariables.ResolutionHeight / 2 + 10 + 15 && mouseState.Y <= y * 30 + VideoVariables.ResolutionHeight / 2 + 10 + 30 + 90;
                        }
                        if (!FactorY && y == 0 && spaceY > 1)
                        {
                            FactorY = mouseState.Y >= VideoVariables.ResolutionHeight / 2 + 10 + 15 + 30 && mouseState.Y <= 30 + VideoVariables.ResolutionHeight / 2 + 10 + 15 + 30 + 90;
                        }
                        break;
                    case 4: //Good for mods adding new items, though not complete
                        FactorY = mouseState.Y - 75 >= y * 30 + VideoVariables.ResolutionHeight / 2 + 10 && mouseState.Y - 75 <= y * 30 + VideoVariables.ResolutionHeight / 2 + 10 + (spaceY * 30);
                        if (!FactorY)
                        {
                            FactorY = mouseState.Y - 45 >= y * 30 + VideoVariables.ResolutionHeight / 2 + 10 && mouseState.Y - 45 <= y * 30 + VideoVariables.ResolutionHeight / 2 + 10 + (spaceY * 30);
                        }
                        if (!FactorY)
                        {
                            FactorY = mouseState.Y - 15 >= y * 30 + VideoVariables.ResolutionHeight / 2 + 10 && mouseState.Y - 15 <= y * 30 + VideoVariables.ResolutionHeight / 2 + 10 + (spaceY * 30);
                        }
                        if (!FactorY)
                        {
                            FactorY = mouseState.Y + 25 >= y * 30 + VideoVariables.ResolutionHeight / 2 + 10 && mouseState.Y + 25 <= y * 30 + VideoVariables.ResolutionHeight / 2 + 10 + (spaceY * 30);
                        }
                        if (!FactorY)
                        {
                            FactorY = mouseState.Y + 55 >= y * 30 + VideoVariables.ResolutionHeight / 2 + 10 && mouseState.Y + 55 <= y * 30 + VideoVariables.ResolutionHeight / 2 + 10 + (spaceY * 30);
                        }
                        if (!FactorY && y == 4)
                        {
                            FactorY = mouseState.Y >= VideoVariables.ResolutionHeight / 2 + 10 && mouseState.Y <= y * 30 + VideoVariables.ResolutionHeight / 2 + 10 + 30 + (newItem.SpaceY * 30);
                        }
                        break;
                }
                if (FactorX)
                {
                    if (FactorY)
                    {
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
                        FactorY = mouseState.Y >= y * 30 + (VideoVariables.ResolutionHeight / 2 - 230) && mouseState.Y <= y * 30 + (VideoVariables.ResolutionHeight / 2 - 230) + (spaceY * 30);
                        break;
                    case 1:
                        FactorY = mouseState.Y - 15 >= y * 30 + (VideoVariables.ResolutionHeight / 2 - 230) && mouseState.Y - 15 <= y * 30 + (VideoVariables.ResolutionHeight / 2 - 230) + (spaceY * 30);
                        if (!FactorY)
                        {
                            FactorY = mouseState.Y + 15 >= y * 30 + (VideoVariables.ResolutionHeight / 2 - 230) && mouseState.Y + 15 <= y * 30 + (VideoVariables.ResolutionHeight / 2 - 230) + (spaceY * 30);
                        }
                        break;
                    case 2:
                        FactorY = mouseState.Y >= y * 30 + (VideoVariables.ResolutionHeight / 2 - 230) && mouseState.Y <= y * 30 + (VideoVariables.ResolutionHeight / 2 - 230) + (spaceY * 30);
                        if (!FactorY)
                        {
                            FactorY = mouseState.Y - 30 >= y * 30 + (VideoVariables.ResolutionHeight / 2 - 230) && mouseState.Y - 30 <= y * 30 + (VideoVariables.ResolutionHeight / 2 - 230) + (spaceY * 30);
                        }
                        if (!FactorY)
                        {
                            FactorY = mouseState.Y + 30 >= y * 30 + (VideoVariables.ResolutionHeight / 2 - 230) && mouseState.Y + 30 <= y * 30 + (VideoVariables.ResolutionHeight / 2 - 230) + (spaceY * 30);
                        }
                        break;
                    case 3:
                        FactorY = mouseState.Y - 45 >= y * 30 + (VideoVariables.ResolutionHeight / 2 - 230) && mouseState.Y - 45 <= y * 30 + (VideoVariables.ResolutionHeight / 2 - 230) + (spaceY * 30);
                        if (!FactorY)
                        {
                            FactorY = mouseState.Y - 15 >= y * 30 + (VideoVariables.ResolutionHeight / 2 - 230) && mouseState.Y - 15 <= y * 30 + (VideoVariables.ResolutionHeight / 2 - 230) + (spaceY * 30);
                        }
                        if (!FactorY)
                        {
                            FactorY = mouseState.Y + 15 >= y * 30 + (VideoVariables.ResolutionHeight / 2 - 230) && mouseState.Y + 15 <= y * 30 + (VideoVariables.ResolutionHeight / 2 - 230) + (spaceY * 30);
                        }
                        if (!FactorY)
                        {
                            FactorY = mouseState.Y + 45 >= y * 30 + (VideoVariables.ResolutionHeight / 2 - 230) && mouseState.Y + 45 <= y * 30 + (VideoVariables.ResolutionHeight / 2 - 230) + (spaceY * 30);
                        }
                        break;
                    case 4:
                        FactorY = mouseState.Y - 75 >= y * 30 + (VideoVariables.ResolutionHeight / 2 - 230) && mouseState.Y - 75 <= y * 30 + (VideoVariables.ResolutionHeight / 2 - 230) + (spaceY * 30);
                        if (!FactorY)
                        {
                            FactorY = mouseState.Y - 45 >= y * 30 + (VideoVariables.ResolutionHeight / 2 - 230) && mouseState.Y - 45 <= y * 30 + (VideoVariables.ResolutionHeight / 2 - 230) + (spaceY * 30);
                        }
                        if (!FactorY)
                        {
                            FactorY = mouseState.Y - 15 >= y * 30 + (VideoVariables.ResolutionHeight / 2 - 230) && mouseState.Y - 15 <= y * 30 + (VideoVariables.ResolutionHeight / 2 - 230) + (spaceY * 30);
                        }
                        if (!FactorY)
                        {
                            FactorY = mouseState.Y + 25 >= y * 30 + (VideoVariables.ResolutionHeight / 2 - 230) && mouseState.Y + 25 <= y * 30 + (VideoVariables.ResolutionHeight / 2 - 230) + (spaceY * 30);
                        }
                        if (!FactorY)
                        {
                            FactorY = mouseState.Y + 55 >= y * 30 + (VideoVariables.ResolutionHeight / 2 - 230) && mouseState.Y + 55 <= y * 30 + (VideoVariables.ResolutionHeight / 2 - 230) + (spaceY * 30);
                        }
                        break;
                }
                if (FactorX)
                {
                    if (FactorY)
                    {
                        return this;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Woop woop. If you cheat, pay the price.
        /// </summary>
        public virtual void Woop()
        {
        }
        public bool PickedUp { get { return pickedUp; } set { pickedUp = value; } }
        public Texture2D ItemSprite { get { return itemSprite; } set { itemSprite = value; } }

        /// <summary>
        /// Returns the X position of the item in the inventory grid. Is zero-based.
        /// </summary>
        public byte PosX { get { return x; } set { x = value; } }

        /// <summary>
        /// Returns the Y position of the item in the inventory grid. Is zero-based.
        /// </summary>
        public byte PosY { get { return y; } set { y = value; } }

        /// <summary>
        /// Returns the space taken by the item in the X direction. Is zero-based for the accessor.
        /// </summary>
        public byte SpaceX { get { return (byte)(spaceX - 1); } set { spaceX = value; } }

        /// <summary>
        /// Returns the space taken by the item in the Y direction. Is zero-based for the accessor.
        /// </summary>
        public byte SpaceY { get { return (byte)(spaceY - 1); } set { spaceY = value; } }

        /// <summary>
        /// Returns true or false if the item is equipped.
        /// </summary>
        public byte Equipped { get { return equipped; } set { equipped = value; } }

        /// <summary>
        /// Returns the item's name.
        /// </summary>
        public string Name { get { return name; } set { name = value; } }

        /// <summary>
        /// Return the item's Id.
        /// </summary>
        public ushort ItemId { get { return itemId; } set { itemId = value; } }
    }
}
