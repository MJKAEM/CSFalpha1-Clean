#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using NPC.Town.MerchantStuff;
using Inventory;
using ContentLoader;
using VideoDisplay;
#endregion

namespace NPC.Town
{
    public abstract class Merchant : TownNPC
    {
        private MerchantInventory inv;
        private MerchantMenu merchantMenu;
        private bool isChatting;

        protected Merchant(int x, int y)
            : base(x, y)
        {
            inv = new MerchantInventory();
            merchantMenu = new MerchantMenu();
        }
        public void ShowInventory(SpriteBatch sb)
        {
            if (inv.InventoryOpen && !isChatting)
            {
                inv.ShowInventory(sb);
            }
        }
        public void ShowMenu(SpriteBatch sb)
        {
            if (!inv.InventoryOpen && isChatting)
            {
                merchantMenu.Show(sb);
            }
        }
        public void SelectMerchant(MouseState mouseState, MouseState oldState)
        {
            if (mouseState.X >= PosX - VideoVariables.RenderPosX - Width / 2 && mouseState.X <= PosX - VideoVariables.RenderPosX + Width / 2)
            {
                if (mouseState.Y >= PosY - VideoVariables.RenderPosY - Height / 2 && mouseState.Y <= PosY - VideoVariables.RenderPosY + Height / 2)
                {
                    if (mouseState.LeftButton == ButtonState.Released && oldState.LeftButton == ButtonState.Pressed)
                    {
                        isChatting = true;
                    }
                }
            }
        }
        public void SelectMenu(MouseState mouseState, MouseState oldState)
        {
            if (!inv.InventoryOpen)
            {
                sbyte temp = merchantMenu.SelectMenu(mouseState, oldState);
                switch (temp)
                {
                    case 0:
                        break;
                    case 1:
                        inv.InventoryOpen = true;
                        isChatting = false;
                        break;
                    case 2:
                        isChatting = false;
                        inv.InventoryOpen = false;
                        break;
                }
            }
        }
        #region Properties
        public bool IsTrading { get { return inv.InventoryOpen; } set { inv.InventoryOpen = value; } }
        public bool IsChatting { get { return isChatting; } set { isChatting = value; } }
        public MerchantMenu MerchantMenu { get { return merchantMenu; } }
        public MerchantInventory GetInventory { get { return inv; } }
        #endregion
    }
}
