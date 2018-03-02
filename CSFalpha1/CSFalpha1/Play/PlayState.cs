using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using CSFalpha1.Play.Level;
using CSFalpha1.Play.Player;

namespace CSFalpha1.Play
{
    public static class PlayState
    {
        private static MainPlayer P = new MainPlayer();
        private static List<abstractLevel> L = new List<abstractLevel>();
        public static void Initialize()
        {
            L.Add(new Town());
        }
        public static void LoadContent()
        {
            for (int i = 0; i < L.Count(); i++)
            {
                L.ElementAt(i).LoadContent();
            }
            P.LoadContent();
        }
        public static void Draw(SpriteBatch sb, MouseState mouseState)
        {
            for (int i = 0; i < L.Count(); i++)
            {
                L.ElementAt(i).Show(sb);
            }
            
            P.Show(sb, mouseState);
            ((Town)L.ElementAt(0)).Merchant(sb, mouseState);
            P.ShowMouseStorage(sb, mouseState);
            P.DisplayChat(sb);
            
            for (int i = 0; i < L.Count(); i++)
            {
                L.ElementAt(i).AShow(sb);
            }
            if (P.Inv)
            {
                P.PInv.ShowInventory(sb, mouseState);
            }
            sb.Draw(P.BeltSprite, new Rectangle(Game.Width / 2 - 320, Game.Height - 40, 640, 40), new Color(200, 200, 200, 225));
            
        }
        public static void Update(KeyboardState keyboardState, MouseState mouseState)
        {
            KeyboardState oldKeyboardState = PlayControls.OldKeyboardState;
            MouseState oldMouseState = PlayControls.OldMouseState;
            for (int i = 0; i < L.Count(); i++)
            {
                L.ElementAt(i).Block();
                L.ElementAt(i).Move();
            }
            PlayControls.PlayerMove(keyboardState);
            PlayControls.PlayerStop(keyboardState);
            PlayControls.NPCchat(keyboardState);
            PlayControls.Inventory(keyboardState);
            PlayControls.PickUp(mouseState);
            PlayControls.ClosePlayerInventory(mouseState);
            ((Town)L.ElementAt(0)).MerchantSelectMenu(mouseState, oldMouseState);
            PlayControls.CloseMerchantInventory(mouseState);

            //Must be at the end
            PlayControls.OldState(keyboardState, mouseState);
        }
        public static MainPlayer Player { get { return P; } }
        public static List<abstractLevel> Level { get { return L; } }
    }
}
