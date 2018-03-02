using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using CSFalpha1.Play.Level.NPC.Town.MerchantStuff;

namespace CSFalpha1.Play.Level.NPC.Town
{
    public abstract class Merchant : TownNPC
    {
        protected MerchantInventory inv;
        protected MerchantMenu mM;
        protected bool isChatting, isTrading;

        public Merchant(int x, int y)
            : base(x, y)
        {
            inv = new MerchantInventory();
            mM = new MerchantMenu();
            isTrading = false;
        }
        public override void LoadContent()
        {
            mM.LoadContent();
            inv.LoadContent();
        }
        public virtual void Inventory(SpriteBatch sb, MouseState mouseState)
        {
            if (isTrading)
            {
                if (!PlayState.Player.Inv)
                {
                    PlayState.Player.PInv.ShowInventory(sb, mouseState);
                    PlayState.Player.Inv = true;
                }
                inv.ShowInventory(sb, mouseState);
            }
        }
        public void ShowMenu(SpriteBatch sb)
        {
            if (PlayState.Player.Chatting)
            {
                leftFactorX = (PlayState.Player.PosX - 16  >= x + 32 - 2 && PlayState.Player.PosX - 15 <= x + 32 );
                rightFactorX = (PlayState.Player.PosX + 16  >= x && PlayState.Player.PosX + 16  <= x + 2);
                upFactorY = (PlayState.Player.PosY - 16  >= y + 30 - 2 && PlayState.Player.PosY - 16  <= y + 32 );
                downFactorY = (PlayState.Player.PosY + 16  >= y && PlayState.Player.PosY + 16  <= y + 2);
                if (PlayState.Player.PosX - 16  <= x + 32 && PlayState.Player.PosX + 16  >= x)
                {
                    if (upFactorY || downFactorY)
                    {
                        mM.Show(sb);
                        PlayState.Player.MerchantChatting = true;
                    }
                    else if (PlayState.Player.PosY - 16  <= y + 32 && PlayState.Player.PosY + 16  >= y)
                    {
                        if (leftFactorX || rightFactorX)
                        {
                            mM.Show(sb);
                            PlayState.Player.MerchantChatting = true;
                        }
                    }
                }
                
            }
        }
        public void Function(MouseState mouseState, MouseState oldState)
        {
            if (!isTrading)
            {
                mM.SelectMenu(mouseState, oldState);
                isTrading = mM.IsTrading;
            }
        }
        public bool IsTrading { get { return isTrading; } set { isTrading = value; } }
        public MerchantMenu MerchantMenu { get { return mM; } }
        public MerchantInventory GetInventory { get { return inv; } }
    }
}
