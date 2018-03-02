using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace CSFalpha1
{
    public static class Simplify
    {
        public static void CenterText(SpriteBatch sb, SpriteFont sf, float y, String text)
        {
            sb.DrawString(sf, text, new Vector2(GetCenterText(sf, text), y), Color.White);
        }
        public static void CenterText(SpriteBatch sb, SpriteFont sf, float y, String text, Color col)
        {
            sb.DrawString(sf, text, new Vector2(GetCenterText(sf, text), y), col);
        }
        public static void DarkenText(SpriteBatch sb, SpriteFont sf, bool condition, float x, float y, String text)
        {
            byte tempColor = 150;

            if (condition)
            {
                tempColor = 255;
            }
            sb.DrawString(sf, text, new Vector2(x, y), new Color(tempColor, tempColor, tempColor));
        }
        public static void DarkenCenterText(SpriteBatch sb, SpriteFont sf, bool condition, float y, String text)
        {
            byte tempColor = 150;

            if (condition)
            {
                tempColor = 255;
            }
            sb.DrawString(sf, text, new Vector2(GetCenterText(sf, text), y), new Color(tempColor, tempColor, tempColor));
        }
        public static void DarkenCenterText(SpriteBatch sb, SpriteFont sf, bool condition, float y, String text, Color col)
        {
            byte tempColor = 50;

            if (condition)
            {
                tempColor = 0;
            }
            sb.DrawString(sf, text, new Vector2(GetCenterText(sf, text), y), new Color(col.R - tempColor, col.G - tempColor, col.B - tempColor));
        }
        public static bool MouseSelect(SpriteFont sf, MouseState mouseState, float x, float y, String text)
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
        public static float GetCenterText(SpriteFont sf, String text)
        {
            Vector2 ct = sf.MeasureString(text);
            return (Game.Width / 2) - (ct.X / 2);
        }
        public static void OptionText(SpriteBatch sb, SpriteFont sf, float x, float y, String text, Color col1, Color col2, bool condition)
        {
            if (condition)
            {
                sb.DrawString(sf, text, new Vector2(x, y), col2);
            }
            else
            {
                sb.DrawString(sf, text, new Vector2(x, y), col1);
            }
        }
    }
}
