using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace CSFalpha1.Menu
{
    public sealed class OptionsMenu : Menu
    {
        public OptionsMenu()
            : base()
        {
            selected = new Boolean[5];
        }
        public override void LoadContent()
        {
            font = ContentLoader.Font(0);
        }
        public override void Show(SpriteBatch sb, MouseState mouseState)
        {
            Simplify.DarkenCenterText(sb, font, selected[0], Game.Height / 3, "Video");
            Simplify.DarkenCenterText(sb, font, selected[1], Game.Height / 3 + 35, "Audio");
            Simplify.DarkenCenterText(sb, font, selected[2], Game.Height / 3 + 70, "Exit");
        }
        public override void SelectMenu(MouseState mouseState, MouseState oldState)
        {
            for (int i = 0; i < selected.Length; i++)
            {
                selected[i] = false;
            }
            if (isShowing)
            {
                if (Simplify.MouseSelect(font, mouseState, Simplify.GetCenterText(font, "Video"), Game.Height / 3, "Video"))
                {
                    selected[0] = true;
                }
                else if (Simplify.MouseSelect(font, mouseState, Simplify.GetCenterText(font, "Audio"), Game.Height / 3 + 35, "Audio"))
                {
                    selected[1] = true;
                }
                else if (Simplify.MouseSelect(font, mouseState, Simplify.GetCenterText(font, "Exit"), Game.Height / 3 + 70, "Exit"))
                {
                    selected[2] = true;
                }
            }
        }
        public override void ClickMenu(MouseState mouseState, MouseState oldState)
        {
            if (selected[0])
            {
            }
            else if (selected[1])
            {
            }
            else if (selected[2])
            {
                isShowing = false;
                MenuState.Menu.ElementAt(0).IsShowing = true;
                MenuState.Pressed = true;
            }
        }
    }
}
