#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using ContentLoader;
using CSFalpha1;
#endregion

namespace NPC.Town.MerchantStuff
{
    public class MerchantMenu
    {
        private SpriteFont chatFont;
        private bool[] selected;

        public MerchantMenu()
        {
            selected = new bool[3];
            chatFont = TheContentLoader.Font[2];
        }
        public void Show(SpriteBatch sb)
        {
            Simplify.DarkenCenterText(sb, chatFont, selected[0], 20, "Talk");
            Simplify.DarkenCenterText(sb, chatFont, selected[1], 40, "Buy/Sell");
            Simplify.DarkenCenterText(sb, chatFont, selected[2], 60, "Close");
        }
        public sbyte SelectMenu(MouseState mouseState, MouseState oldState)
        {
            for (int i = selected.Length - 1; i >= 0; i--)
            {
                selected[i] = false;
            }
            if (Simplify.MouseSelect(chatFont, mouseState, Simplify.GetCenterText(chatFont, "Talk"), 20, "Talk"))
            {
                selected[0] = true;
                if (mouseState.LeftButton == ButtonState.Released && oldState.LeftButton == ButtonState.Pressed)
                {
                    return 0;
                    //"For just a cup of coffee a day, you can experience some of my finest weapons."
                }
            }
            else if (Simplify.MouseSelect(chatFont, mouseState, Simplify.GetCenterText(chatFont, "Buy/Sell"), 40, "Buy/Sell"))
            {
                selected[1] = true;
                if (mouseState.LeftButton == ButtonState.Released && oldState.LeftButton == ButtonState.Pressed)
                {
                    return 1;
                }
            }
            else if (Simplify.MouseSelect(chatFont, mouseState, Simplify.GetCenterText(chatFont, "Close"), 60, "Close"))
            {
                selected[2] = true;
                if (mouseState.LeftButton == ButtonState.Released && oldState.LeftButton == ButtonState.Pressed)
                {
                    return 2;
                }
            }
            return -1;
        }
    }
}
