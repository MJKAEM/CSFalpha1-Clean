#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using VideoDisplay;
using ContentLoader;
#endregion

namespace CSFalpha1.Menu
{
    public class MainMenu : AbstractMenu
    {
        public MainMenu()
        {
            selected = new Boolean[5];
            isShowing = true;
        }
        public override void LoadContent()
        {
            font = TheContentLoader.Font[0];
        }
        public override void Show(SpriteBatch sb, MouseState mouseState)
        {
            Simplify.DarkenCenterText(sb, font, selected[0], VideoVariables.ResolutionHeight / 3, "Single Player");
            Simplify.DarkenCenterText(sb, font, selected[1], VideoVariables.ResolutionHeight / 3 + 35, "Multiplayer");
            Simplify.DarkenCenterText(sb, font, selected[2], VideoVariables.ResolutionHeight / 3 + 70, "Options");
            Simplify.DarkenCenterText(sb, font, selected[3], VideoVariables.ResolutionHeight / 3 + 105, "Credits");
            Simplify.DarkenCenterText(sb, font, selected[4], VideoVariables.ResolutionHeight / 3 + 140, "Exit");
        }
        public override void SelectMenu(MouseState mouseState, MouseState oldState)
        {
            for (int i = selected.Length - 1; i >= 0; i--)
            {
                selected[i] = false;
            }
            if (isShowing)
            {
                if (Simplify.MouseSelect(font, mouseState, Simplify.GetCenterText(font, "Single Player"), VideoVariables.ResolutionHeight / 3, "Single Player"))
                {
                    selected[0] = true;
                }
                else if (Simplify.MouseSelect(font, mouseState, Simplify.GetCenterText(font, "Multiplayer"), VideoVariables.ResolutionHeight / 3 + 35, "Multiplayer"))
                {
                    selected[1] = true;
                }
                else if (Simplify.MouseSelect(font, mouseState, Simplify.GetCenterText(font, "Options"), VideoVariables.ResolutionHeight / 3 + 70, "Options"))
                {
                    selected[2] = true;
                }
                else if (Simplify.MouseSelect(font, mouseState, Simplify.GetCenterText(font, "Credits"), VideoVariables.ResolutionHeight / 3 + 105, "Credits"))
                {
                    selected[3] = true;
                }
                else if (Simplify.MouseSelect(font, mouseState, Simplify.GetCenterText(font, "Exit"), VideoVariables.ResolutionHeight / 3 + 140, "Exit"))
                {
                    selected[4] = true;
                }
            }
        }
        public override void ClickMenu(MouseState mouseState, MouseState oldState)
        {
            if (selected[0])
            {
                isShowing = false;
                MenuState.Menu.ElementAt(1).IsShowing = true;
                MenuState.Pressed = true;
                //Game.GameState = 1;
            }
            else if (selected[2])
            {
                isShowing = false;
                MenuState.Menu.ElementAt(5).IsShowing = true;
                MenuState.Pressed = true;
            }
        }
        public void ExitGame(MouseState mouseState, MouseState oldState, Game game)
        {
            if (isShowing)
            {
                if (Simplify.MouseSelect(font, mouseState, Simplify.GetCenterText(font, "Exit"), VideoVariables.ResolutionHeight / 3 + 140, "Exit"))
                {
                    if (mouseState.LeftButton == ButtonState.Released && oldState.LeftButton == ButtonState.Pressed)
                    {
                        game.Exit();
                    }
                }
            }
        }
    }
}
