using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace CSFalpha1.Play.Level.NPC.Town.MerchantStuff
{
    public class MerchantMenu
    {
        private SpriteFont chatFont;
        private bool[] selected;
        private bool isTrading;

        public MerchantMenu()
        {
            selected = new Boolean[3];
            isTrading = false;
        }
        public void Show(SpriteBatch sb)
        {
            if (!isTrading)
            {
                Simplify.DarkenCenterText(sb, chatFont, selected[0], 20, "Talk");
                Simplify.DarkenCenterText(sb, chatFont, selected[1], 40, "Buy/Sell");
                Simplify.DarkenCenterText(sb, chatFont, selected[2], 60, "Close");
            }
        }
        public void SelectMenu(MouseState mouseState, MouseState oldState)
        {
            for (int i = 0; i < selected.Length; i++)
            {
                selected[i] = false;
            }
            if (Simplify.MouseSelect(chatFont, mouseState, Simplify.GetCenterText(chatFont, "Talk"), 20, "Talk"))
            {
                selected[0] = true;
                if (mouseState.LeftButton == ButtonState.Released && oldState.LeftButton == ButtonState.Pressed)
                {
                    PlayState.Player.MerchantChatting = false;
                    PlayState.Player.AddChatLine("For just a cup of coffee a day, you can experience some of my finest weapons.");
                    PlayState.Player.Chat();
                }
            }
            else if (Simplify.MouseSelect(chatFont, mouseState, Simplify.GetCenterText(chatFont, "Buy/Sell"), 40, "Buy/Sell"))
            {
                selected[1] = true;
                if (mouseState.LeftButton == ButtonState.Released && oldState.LeftButton == ButtonState.Pressed)
                {
                    PlayState.Player.MerchantChatting = false;
                    PlayState.Player.Chat();
                    isTrading = true;
                }
            }
            else if (Simplify.MouseSelect(chatFont, mouseState, Simplify.GetCenterText(chatFont, "Close"), 60, "Close"))
            {
                selected[2] = true;
                if (mouseState.LeftButton == ButtonState.Released && oldState.LeftButton == ButtonState.Pressed)
                {
                    PlayState.Player.MerchantChatting = false;
                    PlayState.Player.Chat();
                }
            }
        }
        public void LoadContent()
        {
            chatFont = ContentLoader.Font(2);
        }
        public bool IsTrading { get { return isTrading; } set { isTrading = value; } }
    }
}
