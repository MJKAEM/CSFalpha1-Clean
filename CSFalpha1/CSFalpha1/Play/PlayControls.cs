using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using CSFalpha1.Play.Level.NPC;
using CSFalpha1.Play.Level.NPC.Town;
using CSFalpha1.Play.Level;

namespace CSFalpha1.Play
{
    public static class PlayControls
    {
        private static KeyboardState oldKeyboardState = Keyboard.GetState();
        private static Keys moveUp = Keys.Up, moveDown = Keys.Down, moveLeft = Keys.Left, moveRight = Keys.Right;
        private static Keys chat = Keys.Z, openInventory = Keys.I;
        private static MouseState oldMouseState = Mouse.GetState();
        public static void NPCchat(KeyboardState keyboardState)
        {
            Merchant npc = null;
            if (keyboardState.IsKeyUp(chat) && oldKeyboardState.IsKeyDown(chat))
            {
                for (int i = 0; i < ((Town)PlayState.Level.ElementAt(0)).GetNPC.Count(); i++)
                {
                    if (((Town)PlayState.Level.ElementAt(0)).GetNPC.ElementAt(i) is Merchant)
                    {
                        if (((Merchant)((Town)PlayState.Level.ElementAt(0)).GetNPC.ElementAt(i)).IsTrading)
                        {
                            npc = ((Merchant)((Town)PlayState.Level.ElementAt(0)).GetNPC.ElementAt(i));
                        }
                    }
                }
                if (npc == null || !npc.IsTrading)
                {
                    if (PlayState.Player.Chatting)
                    {
                        PlayState.Player.Chat();
                    }
                    else
                    {
                        ((Town)PlayState.Level.ElementAt(0)).Chat();
                        if (PlayState.Player.Chatting)
                        {
                            PlayState.Player.Inv = false;
                        }
                    }
                }
            }
        }
        public static void Inventory(KeyboardState keyboardState)
        {
            if (keyboardState.IsKeyUp(openInventory) && oldKeyboardState.IsKeyDown(openInventory))
            {
                if (PlayState.Player.Inv)
                {
                    PlayState.Player.Inv = false;
                }
                else if (!PlayState.Player.Chatting)
                {
                    PlayState.Player.Inv = true;
                }
            }
        }
        public static void PlayerMove(KeyboardState keyboardState)
        {
            Merchant npc = null;
            for (int i = 0; i < ((Town)PlayState.Level.ElementAt(0)).GetNPC.Count(); i++)
            {
                if (((Town)PlayState.Level.ElementAt(0)).GetNPC.ElementAt(i) is Merchant)
                {
                    if (((Merchant)((Town)PlayState.Level.ElementAt(0)).GetNPC.ElementAt(i)).IsTrading)
                    {
                        npc = ((Merchant)((Town)PlayState.Level.ElementAt(0)).GetNPC.ElementAt(i));
                    }
                }
            }
            if (npc == null || !npc.IsTrading)
            {
                if (keyboardState.IsKeyDown(moveUp))
                {
                    PlayState.Player.Move(0);
                }
                if (keyboardState.IsKeyDown(moveDown))
                {
                    PlayState.Player.Move(1);
                }
                if (keyboardState.IsKeyDown(moveLeft))
                {
                    PlayState.Player.Move(2);
                }
                if (keyboardState.IsKeyDown(moveRight))
                {
                    PlayState.Player.Move(3);
                }
            }
        }
        public static void PlayerStop(KeyboardState keyboardState)
        {
            if (keyboardState.IsKeyUp(moveUp))
            {
                PlayState.Player.Stop(0);
            }
            if (keyboardState.IsKeyUp(moveDown))
            {
                PlayState.Player.Stop(1);
            }
            if (keyboardState.IsKeyUp(moveLeft))
            {
                PlayState.Player.Stop(2);
            }
            if (keyboardState.IsKeyUp(moveRight))
            {
                PlayState.Player.Stop(3);
            }
        }
        public static void PickUp(MouseState mouseState)
        {
            if (mouseState.LeftButton == ButtonState.Released && oldMouseState.LeftButton == ButtonState.Pressed)
            {
                PlayState.Player.PInv.MouseStorage.OldItem = PlayState.Player.PInv.MouseStorage.Nothing;
                if (PlayState.Player.PickUpItem)
                {
                    PlayState.Player.PInv.MouseStorage.DropItem(mouseState);
                }
                else
                {
                    if (PlayState.Player.Inv)
                    {
                        if (mouseState.X > Game.Width / 2)
                        {
                            PlayState.Player.PickupPlayerInventoryItem(mouseState);
                        }
                        else
                        {
                            for (int i = 0; i < ((Town)PlayState.Level.ElementAt(0)).GetNPC.Count(); i++)
                            {
                                if (((Town)PlayState.Level.ElementAt(0)).GetNPC.ElementAt(i) is Merchant)
                                {
                                    if (((Merchant)((Town)PlayState.Level.ElementAt(0)).GetNPC.ElementAt(i)).IsTrading)
                                    {
                                        PlayState.Player.PickupOtherInventoryItem(mouseState, (Merchant)((Town)PlayState.Level.ElementAt(0)).GetNPC.ElementAt(i));
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public static void ClosePlayerInventory(MouseState mouseState)
        {
            if (mouseState.LeftButton == ButtonState.Released && oldMouseState.LeftButton == ButtonState.Pressed)
            {
                PlayState.Player.PInv.CloseMenu(mouseState, null);
            }
        }
        public static void CloseMerchantInventory(MouseState mouseState)
        {
            if (mouseState.LeftButton == ButtonState.Released && oldMouseState.LeftButton == ButtonState.Pressed)
            {
                for (int i = 0; i < ((Town)PlayState.Level.ElementAt(0)).GetNPC.Count(); i++)
                {
                    if (((Town)PlayState.Level.ElementAt(0)).GetNPC.ElementAt(i) is Merchant)
                    {
                        if (((Merchant)((Town)PlayState.Level.ElementAt(0)).GetNPC.ElementAt(i)).IsTrading)
                        {
                            Merchant npc = ((Merchant)((Town)PlayState.Level.ElementAt(0)).GetNPC.ElementAt(i));
                            npc.GetInventory.CloseMenu(mouseState, npc);
                        }
                    }
                }
            }
        }
        public static void OldState(KeyboardState keyboardState, MouseState mouseState)
        {
            oldKeyboardState = keyboardState;
            oldMouseState = mouseState;
        }
        public static KeyboardState OldKeyboardState { get { return oldKeyboardState; } }
        public static MouseState OldMouseState { get { return oldMouseState; } }
    }
}
