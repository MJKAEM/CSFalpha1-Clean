using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace CSFalpha1.Menu
{
    public static class MenuState
    {
        private static List<Menu> menu = new List<Menu>();
        private static bool pressed = false;
        public static void Initialize()
        {
            menu.Add(new MainMenu());
            menu.Add(new SinglePlayerMenu());
            menu.Add(new NewCharacterMenu());
            menu.Add(new NewCharacterMenu());
            menu.Add(new NewCharacterMenu());
            menu.Add(new OptionsMenu());
        }
        public static void LoadContent()
        {
            foreach (Menu m in menu)
            {
                m.LoadContent();
            }
        }
        public static void Draw(SpriteBatch sb, MouseState mouseState)
        {
            Simplify.CenterText(sb, ContentLoader.Font(0), Game.Height / 5, "ECalpha1.1 - C#");
            foreach (Menu m in menu)
            {
                if (m.IsShowing)
                {
                    m.Show(sb, mouseState);
                }
            }
        }
        public static void Update(KeyboardState keyboardState, MouseState mouseState, Game game)
        {
            KeyboardState oldKeyboardState = MenuControls.OldKeyboardState;
            MouseState oldMouseState = MenuControls.OldMouseState;

            foreach (Menu m in menu)
            {
                if (m.IsShowing)
                {
                    m.SelectMenu(mouseState, oldMouseState);
                    if (mouseState.LeftButton == ButtonState.Released && oldMouseState.LeftButton == ButtonState.Pressed && !pressed)
                    {
                        m.ClickMenu(mouseState, oldMouseState);
                    }
                }
            }
            ((MainMenu)menu.ElementAt(0)).ExitGame(mouseState, oldMouseState, game);

            //Must be at the end
            MenuControls.OldState(keyboardState, mouseState);
        }
        public static List<Menu> Menu { get { return menu; } }
        public static bool Pressed { get { return pressed; } set { pressed = value; } }
    }
}
