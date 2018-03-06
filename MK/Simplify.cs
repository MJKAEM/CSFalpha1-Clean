#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using VideoDisplay;
#endregion

namespace CSFalpha1
{
    public static class Simplify
    {
        public static void CenterText(SpriteBatch sb, SpriteFont sf, float y, string text)
        {
            sb.DrawString(sf, text, new Vector2((int)GetCenterText(sf, text), (int)y), Color.White);
        }
        public static void CenterText(SpriteBatch sb, SpriteFont sf, float y, string text, Color col)
        {
            sb.DrawString(sf, text, new Vector2((int)GetCenterText(sf, text), (int)y), col);
        }
        public static void DarkenText(SpriteBatch sb, SpriteFont sf, bool condition, float x, float y, string text)
        {
            byte tempColor = 150;

            if (condition)
            {
                tempColor = 255;
            }
            sb.DrawString(sf, text, new Vector2((int)x, (int)y), new Color(tempColor, tempColor, tempColor));
        }
        public static void DarkenCenterText(SpriteBatch sb, SpriteFont sf, bool condition, float y, string text)
        {
            byte tempColor = 150;

            if (condition)
            {
                tempColor = 255;
            }
            sb.DrawString(sf, text, new Vector2((int)GetCenterText(sf, text), (int)y), new Color(tempColor, tempColor, tempColor));
        }
        public static void DarkenCenterText(SpriteBatch sb, SpriteFont sf, bool condition, float y, string text, Color col)
        {
            byte tempColor = 50;

            if (condition)
            {
                tempColor = 0;
            }
            sb.DrawString(sf, text, new Vector2((int)GetCenterText(sf, text), (int)y), new Color(col.R - tempColor, col.G - tempColor, col.B - tempColor));
        }
        public static bool MouseSelect(SpriteFont sf, MouseState mouseState, float x, float y, string text)
        {
            Vector2 ct = sf.MeasureString(text);
            if ((mouseState.X >= x - 5 && mouseState.X <= x + ct.X + 5) && (mouseState.Y >= y && mouseState.Y <= y + ct.Y))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static float GetCenterText(SpriteFont sf, string text)
        {
            Vector2 ct = sf.MeasureString(text);
            return (VideoVariables.ResolutionWidth / 2) - (ct.X / 2);
        }
        public static void OptionText(SpriteBatch sb, SpriteFont sf, float x, float y, string text, Color col1, Color col2, bool condition)
        {
            if (condition)
            {
                sb.DrawString(sf, text, new Vector2((int)x, (int)y), col2);
            }
            else
            {
                sb.DrawString(sf, text, new Vector2((int)x, (int)y), col1);
            }
        }
    }
}
