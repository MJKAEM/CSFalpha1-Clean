using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace CSFalpha1.Menu
{
    public static class MenuControls
    {
        private static KeyboardState oldKeyboardState = Keyboard.GetState();
        private static MouseState oldMouseState = Mouse.GetState();
        public static void OldState(KeyboardState keyboardState, MouseState mouseState)
        {
            if (mouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released)
            {
                MenuState.Pressed = false;
            }
            oldKeyboardState = keyboardState;
            oldMouseState = mouseState;
        }
        public static KeyboardState OldKeyboardState { get { return oldKeyboardState; } }
        public static MouseState OldMouseState { get { return oldMouseState; } }
    }
}
