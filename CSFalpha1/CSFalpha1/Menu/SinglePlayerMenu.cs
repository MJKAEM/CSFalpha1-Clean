using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace CSFalpha1.Menu
{
    public class SinglePlayerMenu : Menu
    {
        private int selectedCharacter;
        private bool[] highlightedCharacter;
        public SinglePlayerMenu()
            : base()
        {
            selected = new Boolean[5];
            selectedCharacter = 0;
            highlightedCharacter = new Boolean[7];
        }
        public override void LoadContent()
        {
            font = ContentLoader.Font(0);
        }
        public override void Show(SpriteBatch sb, MouseState mouseState)
        {
            Simplify.DarkenText(sb, font, selected[0], Game.Width - 75, Game.Height - 50, "OK");
            Simplify.DarkenText(sb, font, selected[1], 20, Game.Height - 50, "Back");
            Simplify.DarkenText(sb, font, selected[2], Game.Width / 2 - 250, Game.Height - 100, "New Character");
            Simplify.DarkenText(sb, font, selected[3], Game.Width / 2 + 50, Game.Height - 100, "Delete Character");
            for (int i = 0; i < highlightedCharacter.Length; i++)
            {
                if (i == selectedCharacter)
                {
                    sb.DrawString(font, "Character one", new Vector2(Game.Width / 8, (Game.Height / 4) + (35 * i)), Color.Beige);
                }
                else
                {
                    Simplify.DarkenText(sb, font, highlightedCharacter[i], Game.Width / 8, (Game.Height / 4) + (35 * i), "Character one");
                }
            }

        }
        public override void SelectMenu(MouseState mouseState, MouseState oldState)
        {
            for (int i = 0; i < selected.Length; i++)
            {
                selected[i] = false;
            }
            for (int i = 0; i < highlightedCharacter.Length; i++)
            {
                highlightedCharacter[i] = false;
            }
            if (isShowing)
            {
                if (Simplify.MouseSelect(font, mouseState, Game.Width - 75, Game.Height - 50, "OK"))
                {
                    selected[0] = true;
                }
                else if (Simplify.MouseSelect(font, mouseState, 20, Game.Height - 50, "Back"))
                {
                    selected[1] = true;
                }
                else if (Simplify.MouseSelect(font, mouseState, Game.Width / 2 - 250, Game.Height - 100, "New Character"))
                {
                    selected[2] = true;
                }
                else if (Simplify.MouseSelect(font, mouseState, Game.Width / 2 + 50, Game.Height - 100, "Delete Character"))
                {
                    selected[3] = true;
                }
                for (int i = 0; i < highlightedCharacter.Length; i++)
                {
                    if (Simplify.MouseSelect(font, mouseState, Game.Width / 8, (Game.Height / 4) + (35 * i), "Character one"))
                    {
                        highlightedCharacter[i] = true;
                    }
                }
            }
        }
        public override void ClickMenu(MouseState mouseState, MouseState oldState)
        {
            if (selected[0])
            {
                Game.GameState = 1;
            }
            else if (selected[1])
            {
                isShowing = false;
                MenuState.Menu.ElementAt(0).IsShowing = true;
                MenuState.Pressed = true;
            }
            for (int i = 0; i < highlightedCharacter.Length; i++)
            {
                if (highlightedCharacter[i])
                {
                    selectedCharacter = i;
                }
            }
        }
    }
}
