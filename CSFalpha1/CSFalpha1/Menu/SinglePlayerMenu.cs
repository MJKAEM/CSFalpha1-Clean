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
    public class SinglePlayerMenu : AbstractMenu
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
            font = TheContentLoader.Font[0];
        }
        public override void Show(SpriteBatch sb, MouseState mouseState)
        {
            Simplify.DarkenText(sb, font, selected[0], VideoVariables.ResolutionWidth - 75, VideoVariables.ResolutionHeight - 50, "OK");
            Simplify.DarkenText(sb, font, selected[1], 20, VideoVariables.ResolutionHeight - 50, "Back");
            Simplify.DarkenText(sb, font, selected[2], VideoVariables.ResolutionWidth / 2 - 250, VideoVariables.ResolutionHeight - 100, "New Character");
            Simplify.DarkenText(sb, font, selected[3], VideoVariables.ResolutionWidth / 2 + 50, VideoVariables.ResolutionHeight - 100, "Delete Character");
            for (int i = highlightedCharacter.Length - 1; i >= 0; i--)
            {
                if (i == selectedCharacter)
                {
                    sb.DrawString(font, "Character one", new Vector2(VideoVariables.ResolutionWidth / 8, (VideoVariables.ResolutionHeight / 4) + (35 * i)), Color.Beige);
                }
                else
                {
                    Simplify.DarkenText(sb, font, highlightedCharacter[i], VideoVariables.ResolutionWidth / 8, (VideoVariables.ResolutionHeight / 4) + (35 * i), "Character one");
                }
            }

        }
        public override void SelectMenu(MouseState mouseState, MouseState oldState)
        {
            for (int i = selected.Length - 1; i >= 0; i--)
            {
                selected[i] = false;
            }
            for (int i = selected.Length - 1; i >= 0; i--)
            {
                highlightedCharacter[i] = false;
            }
            if (isShowing)
            {
                if (Simplify.MouseSelect(font, mouseState, VideoVariables.ResolutionWidth - 75, VideoVariables.ResolutionHeight - 50, "OK"))
                {
                    selected[0] = true;
                }
                else if (Simplify.MouseSelect(font, mouseState, 20, VideoVariables.ResolutionHeight - 50, "Back"))
                {
                    selected[1] = true;
                }
                else if (Simplify.MouseSelect(font, mouseState, VideoVariables.ResolutionWidth / 2 - 250, VideoVariables.ResolutionHeight - 100, "New Character"))
                {
                    selected[2] = true;
                }
                else if (Simplify.MouseSelect(font, mouseState, VideoVariables.ResolutionWidth / 2 + 50, VideoVariables.ResolutionHeight - 100, "Delete Character"))
                {
                    selected[3] = true;
                }
                for (int i = highlightedCharacter.Length; i >= 0; i--)
                {
                    if (Simplify.MouseSelect(font, mouseState, VideoVariables.ResolutionWidth / 8, (VideoVariables.ResolutionHeight / 4) + (35 * i), "Character one"))
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
                Main.GameState = 1;
            }
            else if (selected[1])
            {
                isShowing = false;
                MenuState.Menu.ElementAt(0).IsShowing = true;
                MenuState.Pressed = true;
            }
            for (int i = highlightedCharacter.Length - 1; i >= 0; i--)
            {
                if (highlightedCharacter[i])
                {
                    selectedCharacter = i;
                }
            }
        }
    }
}
