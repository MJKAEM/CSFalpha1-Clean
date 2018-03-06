#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using VideoDisplay;
using ContentLoader;
#endregion

namespace CSFalpha1.Menu
{
    public sealed class OptionsMenu : AbstractMenu
    {
        public OptionsMenu()
            : base()
        {
            selected = new Boolean[5];
        }
        public override void LoadContent()
        {
            font = TheContentLoader.Font[0];
        }
        public override void Show(SpriteBatch sb, MouseState mouseState)
        {
            Simplify.DarkenCenterText(sb, font, selected[0], VideoVariables.ResolutionHeight / 3, "Video");
            Simplify.DarkenCenterText(sb, font, selected[1], VideoVariables.ResolutionHeight / 3 + 35, "Audio");
            Simplify.DarkenCenterText(sb, font, selected[2], VideoVariables.ResolutionHeight / 3 + 70, "Exit");
        }
        public override void SelectMenu(MouseState mouseState, MouseState oldState)
        {
            for (int i = selected.Length - 1; i >= 0; i--)
            {
                selected[i] = false;
            }
            if (isShowing)
            {
                if (Simplify.MouseSelect(font, mouseState, Simplify.GetCenterText(font, "Video"), VideoVariables.ResolutionHeight / 3, "Video"))
                {
                    selected[0] = true;
                }
                else if (Simplify.MouseSelect(font, mouseState, Simplify.GetCenterText(font, "Audio"), VideoVariables.ResolutionHeight / 3 + 35, "Audio"))
                {
                    selected[1] = true;
                }
                else if (Simplify.MouseSelect(font, mouseState, Simplify.GetCenterText(font, "Exit"), VideoVariables.ResolutionHeight / 3 + 70, "Exit"))
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
