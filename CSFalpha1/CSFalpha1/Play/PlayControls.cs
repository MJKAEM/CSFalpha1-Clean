#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using NPC;
using NPC.Town;
using CSFalpha1.Play.Level;
using CSFalpha1.Play.Player;
using VideoDisplay;
using Item.Armor.Shield;
using Item.Weapon;
using Item.Armor;
#endregion

namespace CSFalpha1.Play
{
    public static class PlayControls
    {
        private static KeyboardState oldKeyboardState = Keyboard.GetState();
        private static Keys moveUp = Keys.Up, moveDown = Keys.Down, moveLeft = Keys.Left, moveRight = Keys.Right;
        private static Keys chat = Keys.Z, openInventory = Keys.I;
        private static MouseState oldMouseState = Mouse.GetState();
        private static Merchant tradingMerchant;
        public static void NPCchat(KeyboardState keyboardState)
        {
            if (keyboardState.IsKeyUp(chat) && oldKeyboardState.IsKeyDown(chat))
            {
                if (tradingMerchant == null)
                {
                    if (PlayState.Player.Chatting)
                    {
                        PlayState.Player.Chat();
                    }
                    else
                    {
                        PlayState.Town.Chat();
                        if (PlayState.Player.Chatting)
                        {
                            PlayState.Player.PInv.InventoryOpen = false;
                        }
                    }
                }
            }
        }
        public static void Inventory(KeyboardState keyboardState)
        {
            if (keyboardState.IsKeyUp(openInventory) && oldKeyboardState.IsKeyDown(openInventory))
            {
                if (PlayState.Player.PInv.InventoryOpen)
                {
                    PlayState.Player.PInv.InventoryOpen = false;
                }
                else if (!PlayState.Player.Chatting)
                {
                    PlayState.Player.PInv.InventoryOpen = true;
                }
            }
        }
        public static void PlayerMove(KeyboardState keyboardState)
        {
            if (tradingMerchant == null)
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
                PlayState.Player.PInv.MouseStorage.OldItem = null;
                if (PlayState.Player.PInv.InventoryOpen)
                {
                    if (PlayState.Player.PickUpItem)
                    {
                        if (mouseState.X > VideoVariables.ResolutionWidth / 2)
                        {
                            PlayState.Player.PInv.MouseStorage.DropItemInventory(mouseState, PlayState.Player.PInv);
                            if (PlayState.Player.PInv.MouseStorage.Item is AbstractWeapon || PlayState.Player.PInv.MouseStorage.Item is AbstractShield)
                            {
                                if (mouseState.Y > VideoVariables.ResolutionHeight / 2 - 190 && mouseState.Y < VideoVariables.ResolutionHeight / 2 - 190 + 120)
                                {
                                    if (mouseState.X > (VideoVariables.ResolutionWidth - 320) + 15 && mouseState.X < (VideoVariables.ResolutionWidth - 320) + 15 + 60)
                                    {
                                        PlayState.Player.PInv.MouseStorage.DropItemEquipRightHand(PlayState.Player.PInv);
                                    }
                                    else if (mouseState.X > (VideoVariables.ResolutionWidth - 320) + 244 && mouseState.X < (VideoVariables.ResolutionWidth - 320) + 244 + 60)
                                    {
                                        PlayState.Player.PInv.MouseStorage.DropItemEquipLeftHand(PlayState.Player.PInv);
                                    }
                                }
                            }
                            else if (PlayState.Player.PInv.MouseStorage.Item is AbstractArmor /*already implied && !(PlayState.Player.PInv.MouseStorage.Item is AbstractShield)*/)
                            {
                                if (mouseState.X > (VideoVariables.ResolutionWidth - 320) + 129 && mouseState.X < (VideoVariables.ResolutionWidth - 320) + 129 + 60)
                                {
                                    if (mouseState.Y > VideoVariables.ResolutionHeight / 2 - 230 && mouseState.Y < VideoVariables.ResolutionHeight / 2 - 230 + 60)
                                    {
                                        PlayState.Player.PInv.MouseStorage.DropItemEquipHelmet(PlayState.Player.PInv);
                                        Console.WriteLine("Helmet");
                                    }
                                    else if (mouseState.Y > VideoVariables.ResolutionHeight / 2 - 160 && mouseState.Y < VideoVariables.ResolutionHeight / 2 - 160 + 90)
                                    {
                                        PlayState.Player.PInv.MouseStorage.DropItemEquipBodyArmor(PlayState.Player.PInv);
                                        Console.WriteLine("Body");
                                    }
                                    else if (mouseState.Y > VideoVariables.ResolutionHeight / 2 - 60 && mouseState.Y < VideoVariables.ResolutionHeight / 2 - 60 + 30)
                                    {
                                        PlayState.Player.PInv.MouseStorage.DropItemEquipBelt(PlayState.Player.PInv);
                                        Console.WriteLine("Belt");
                                    }
                                }
                                else if (mouseState.Y > VideoVariables.ResolutionHeight / 2 - 60 && mouseState.Y < VideoVariables.ResolutionHeight / 2 - 60 + 60)
                                {
                                    if (mouseState.X > (VideoVariables.ResolutionWidth - 320) + 15 && mouseState.X < (VideoVariables.ResolutionWidth - 320) + 15 + 60)
                                    {
                                        PlayState.Player.PInv.MouseStorage.DropItemEquipGloves(PlayState.Player.PInv);
                                        Console.WriteLine("Gloves");
                                    }
                                    else if (mouseState.X > (VideoVariables.ResolutionWidth - 320) + 244 && mouseState.X < (VideoVariables.ResolutionWidth - 320) + 244 + 60)
                                    {
                                        PlayState.Player.PInv.MouseStorage.DropItemEquipBoots(PlayState.Player.PInv);
                                        Console.WriteLine("Boots");
                                    }
                                }
                            }
                        }
                        else if (PlayState.CurrentLevel == -1)
                        {
                            if (tradingMerchant != null)
                            {
                                PlayState.Player.PInv.MouseStorage.DropItemInventory(mouseState, PlayState.Player.PInv, tradingMerchant.GetInventory);
                            }
                        }
                        if (PlayState.Player.PInv.MouseStorage.Item == null)
                        {
                            PlayState.Player.PickUpItem = false;
                        }
                        else
                        {
                            PlayState.Player.PickUpItem = true;
                        }
                        EpicTrapCard();
                    }
                    else
                    {
                        if (mouseState.X > VideoVariables.ResolutionWidth / 2)
                        {
                            PlayState.Player.PickupPlayerInventoryItem(mouseState);
                        }
                        else
                        {
                            if (tradingMerchant != null)
                            {
                                PlayState.Player.PickupOtherInventoryItem(mouseState, tradingMerchant.GetInventory);
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
                PlayState.Player.PInv.CloseMenu(mouseState);
            }
        }
        public static void CloseMerchantInventory(MouseState mouseState)
        {
            if (mouseState.LeftButton == ButtonState.Released && oldMouseState.LeftButton == ButtonState.Pressed)
            {
                if (tradingMerchant != null)
                {
                    tradingMerchant.GetInventory.CloseMenu(mouseState);
                    if (!tradingMerchant.GetInventory.InventoryOpen)
                    {
                        PlayState.Player.PInv.InventoryOpen = false;
                    }
                }
            }
        }
        public static void UseConsumableItem(MouseState mouseState)
        {
            if (mouseState.RightButton == ButtonState.Released && oldMouseState.RightButton == ButtonState.Pressed)
            {
                if (PlayState.Player.PInv.InventoryOpen)
                {
                    PlayState.Player.PInv.UseConsumableItem(mouseState);
                }
            }
        }
        private static void EpicTrapCard()
        {
            if (PlayState.Player.PInv.RightHand != null)
            {
                PlayState.Player.PInv.RightHand.Woop();
            }
            if (PlayState.Player.PInv.LeftHand != null)
            {
                PlayState.Player.PInv.LeftHand.Woop();
            }
            if (PlayState.Player.PInv.Helmet != null)
            {
                PlayState.Player.PInv.Helmet.Woop();
            }
            if (PlayState.Player.PInv.Body != null)
            {
                PlayState.Player.PInv.Body.Woop();
            }
            if (PlayState.Player.PInv.Gloves != null)
            {
                PlayState.Player.PInv.Gloves.Woop();
            }
            if (PlayState.Player.PInv.Boots != null)
            {
                PlayState.Player.PInv.Boots.Woop();
            }
            if (PlayState.Player.PInv.LeftHand is AbstractShield && PlayState.Player.PInv.RightHand is AbstractShield)
            {
                Main.Wop();
            }
        }
        public static void OldState(KeyboardState keyboardState, MouseState mouseState)
        {
            oldKeyboardState = keyboardState;
            oldMouseState = mouseState;
        }
        public static KeyboardState OldKeyboardState { get { return oldKeyboardState; } }
        public static MouseState OldMouseState { get { return oldMouseState; } }
        public static Merchant TradingMerchant { get { return tradingMerchant; } set { tradingMerchant = value; } }
    }
}
