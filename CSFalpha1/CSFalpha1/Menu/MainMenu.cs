using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace CSFalpha1.Menu
{
    public class MainMenu : Menu
    {
        public MainMenu()
        {
            selected = new Boolean[5];
            isShowing = true;
        }
        public override void LoadContent()
        {
            font = ContentLoader.Font(0);
        }
        public override void Show(SpriteBatch sb, MouseState mouseState)
        {
            Simplify.DarkenCenterText(sb, font, selected[0], Game.Height / 3, "Single Player");
            Simplify.DarkenCenterText(sb, font, selected[1], Game.Height / 3 + 35, "Multiplayer");
            Simplify.DarkenCenterText(sb, font, selected[2], Game.Height / 3 + 70, "Options");
            Simplify.DarkenCenterText(sb, font, selected[3], Game.Height / 3 + 105, "Credits");
            Simplify.DarkenCenterText(sb, font, selected[4], Game.Height / 3 + 140, "Exit");
        }
        public override void SelectMenu(MouseState mouseState, MouseState oldState)
        {
            for (int i = 0; i < selected.Length; i++)
            {
                selected[i] = false;
            }
            if (isShowing)
            {
                if (Simplify.MouseSelect(font, mouseState, Simplify.GetCenterText(font, "Single Player"), Game.Height / 3, "Single Player"))
                {
                    selected[0] = true;
                }
                else if (Simplify.MouseSelect(font, mouseState, Simplify.GetCenterText(font, "Multiplayer"), Game.Height / 3 + 35, "Multiplayer"))
                {
                    selected[1] = true;
                }
                else if (Simplify.MouseSelect(font, mouseState, Simplify.GetCenterText(font, "Options"), Game.Height / 3 + 70, "Options"))
                {
                    selected[2] = true;
                }
                else if (Simplify.MouseSelect(font, mouseState, Simplify.GetCenterText(font, "Credits"), Game.Height / 3 + 105, "Credits"))
                {
                    selected[3] = true;
                }
                else if (Simplify.MouseSelect(font, mouseState, Simplify.GetCenterText(font, "Exit"), Game.Height / 3 + 140, "Exit"))
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
                if (Simplify.MouseSelect(font, mouseState, Simplify.GetCenterText(font, "Exit"), Game.Height / 3 + 140, "Exit"))
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
