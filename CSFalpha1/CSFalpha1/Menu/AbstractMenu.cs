using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CSFalpha1.Menu
{
    public abstract class AbstractMenu
    {
        protected bool[] selected;
        protected SpriteFont font;
        protected bool isShowing;
        protected AbstractMenu()
        {
            isShowing = false;
        }
        public abstract void LoadContent();
        public abstract void Show(SpriteBatch sb, MouseState mouseState);
        public abstract void SelectMenu(MouseState mouseState, MouseState oldState);
        public abstract void ClickMenu(MouseState mouseState, MouseState oldState);
        public bool IsShowing { get { return isShowing; } set { isShowing = value; } }
    }
}
