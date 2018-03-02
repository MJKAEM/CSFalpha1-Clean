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
using CSFalpha1.Play.Level.NPC.Town;
using CSFalpha1.Play.Inventory;

namespace CSFalpha1.Play.Player
{
    public sealed class MainPlayer
    {
        private bool movingUp, movingDown, movingLeft, movingRight;
        private bool chatting, merchantChatting;
        private bool pickUpItem;
        private bool inventoryOpen;
        private int chatLine;
        private int x, y;
        private int curHealth, maxHealth;
        private int direction, tempDirection;
        private List<String> chat;
        private PlayerInventory inv;

        private Texture2D charSprite;
        private Texture2D invSprite;
        private SpriteFont chatFont;
        public MainPlayer()
        {
            x = 0;
            y = 0;
            direction = 0;
            tempDirection = 0;
            movingUp = false;
            movingDown = false;
            movingLeft = false;
            movingRight = false;
            inventoryOpen = false;
            pickUpItem = false;
            inv = new PlayerInventory();
            chat = new List<String>();
            maxHealth = 25;
            curHealth = maxHealth;
        }
        public void LoadContent()
        {
            charSprite = ContentLoader.CharSprite(0);
            chatFont = ContentLoader.Font(1);
            inv.LoadContent();
            invSprite = ContentLoader.InvSprite(2);
        }
        public void Show(SpriteBatch sb, MouseState mouseState)
        {
            switch (direction)
            {
                case 0:
                    sb.Draw(charSprite, new Rectangle(Game.Width / 2 - 16, Game.Height / 2 - 16, 32, 32), new Rectangle(0, 0, 32, 32), Color.White);
                    break;

                case 1:
                    sb.Draw(charSprite,
                        new Rectangle(Game.Width / 2 - 16, Game.Height / 2 - 16, 32, 32),
                        new Rectangle(32, 32, 32, 32),
                        Color.White);
                    break;

                case 2:
                    sb.Draw(charSprite,
                        new Rectangle(Game.Width / 2 - 16, Game.Height / 2 - 16, 32, 32),
                        new Rectangle(32, 0, 32, 32),
                        Color.White);
                    break;

                case 3:
                    sb.Draw(charSprite,
                        new Rectangle(Game.Width / 2 - 16, Game.Height / 2 - 16, 32, 32),
                        new Rectangle(0, 32, 32, 32),
                       Color.White);
                    break;
            }
            Move();
        }
        public void ShowMouseStorage(SpriteBatch sb, MouseState mouseState)
        {
            if (inv.MouseStorage != null)
            {
                inv.MouseStorage.Show(sb, mouseState);
            }
        }
        public void PickupPlayerInventoryItem(MouseState mouseState)
        {
            for (int i = 0; i < PInv.Item.Count(); i++)
            {
                if (PInv.Item.ElementAt(i).PickupItem(mouseState) != null && PInv.Item.ElementAt(i).PickupItem(mouseState) is Item.abstractItem)
                {
                    PInv.MouseStorage.Item = PInv.Item.ElementAt(i).PickupItem(mouseState);
                }
            }
        }
        public void PickupOtherInventoryItem(MouseState mouseState, Merchant npc)
        {
            for (int i = 0; i < npc.GetInventory.Item.Count(); i++)
            {
                if (npc.GetInventory.Item.ElementAt(i).PickupItem(mouseState) != null && npc.GetInventory.Item.ElementAt(i).PickupItem(mouseState) is Item.abstractItem)
                {
                    PInv.MouseStorage.Item = npc.GetInventory.Item.ElementAt(i).PickupItem(mouseState);
                }
            }
        }
        public void Move()
        {
            if (!chatting)
            {
                Turn();
                if (movingUp)
                {
                    y -= 2;
                    for (int i = 0; i < PlayState.Level.Count(); i++)
                    {
                        if (PlayState.Level.ElementAt(i).GetCollide(0))
                        {
                            y += 2;
                        }
                    }
                }
                if (movingDown)
                {
                    y += 2;
                    for (int i = 0; i < PlayState.Level.Count(); i++)
                    {
                        if (PlayState.Level.ElementAt(i).GetCollide(1))
                        {
                            y -= 2;
                        }
                    }
                }
                if (movingLeft)
                {
                    x -= 2;
                    for (int i = 0; i < PlayState.Level.Count(); i++)
                    {
                        if (PlayState.Level.ElementAt(i).GetCollide(2))
                        {
                            x += 2;
                        }
                    }
                }
                if (movingRight)
                {
                    x += 2;
                    for (int i = 0; i < PlayState.Level.Count(); i++)
                    {
                        if (PlayState.Level.ElementAt(i).GetCollide(3))
                        {
                            x -= 2;
                        }
                    }
                }
            }
        }
        public void Move(byte a)
        {
            switch (a)
            {
                case 0:
                    movingUp = true;
                    break;
                case 1:
                    movingDown = true;
                    break;
                case 2:
                    movingLeft = true;
                    break;
                case 3:
                    movingRight = true;
                    break;
                default:
                    Console.WriteLine("Error: Can only call Player.Move() with an argument: integer between 0-3.");
                    break;
            }
        }
        public void Stop(byte a)
        {
            switch (a)
            {
                case 0:
                    movingUp = false;
                    for (int i = 0; i < PlayState.Level.Count(); i++)
                    {
                        PlayState.Level.ElementAt(i).UnCollide(0);
                    }
                    if (tempDirection == a)
                    {
                        tempDirection = -1;
                    }
                    break;
                case 1:
                    movingDown = false;
                    for (int i = 0; i < PlayState.Level.Count(); i++)
                    {
                        PlayState.Level.ElementAt(i).UnCollide(1);
                    }
                    if (tempDirection == a)
                    {
                        tempDirection = -1;
                    }
                    break;
                case 2:
                    movingLeft = false;
                    for (int i = 0; i < PlayState.Level.Count(); i++)
                    {
                        PlayState.Level.ElementAt(i).UnCollide(2);
                    }
                    if (tempDirection == a)
                    {
                        tempDirection = -1;
                    }
                    break;
                case 3:
                    movingRight = false;
                    for (int i = 0; i < PlayState.Level.Count(); i++)
                    {
                        PlayState.Level.ElementAt(i).UnCollide(3);
                    }
                    if (tempDirection == a)
                    {
                        tempDirection = -1;
                    }
                    break;
                default:
                    Console.WriteLine("Error: Can only call Player.Stop() with an argument: integer between 0-3.");
                    break;
            }
        }
        public void Turn()
        {
            if (tempDirection == -1)
            {
                if (movingUp)
                {
                    tempDirection = 0;
                    direction = 0;
                }
                else if (movingDown)
                {
                    tempDirection = 1;
                    direction = 1;
                }
                if (movingLeft)
                {
                    tempDirection = 2;
                    direction = 2;
                }
                else if (movingRight)
                {
                    tempDirection = 3;
                    direction = 3;
                }
            }
        }
        public void DisplayChat(SpriteBatch sb)
        {
            if (chatting && chat.Count() > 0)
            {
                sb.DrawString(chatFont, chat.ElementAt(chatLine), new Vector2(20, Game.Height - 100), Color.White);
            }
        }
        public void Chat()
        {
            if (chatLine < chat.Count() - 1)
            {
                if (!merchantChatting)
                {
                    chatLine++;
                }
            }
            else if (!merchantChatting)
            {
                chatLine = 0;
                chatting = false;
                while (chat.Count() > 0)
                {
                    chat.RemoveAt(0);
                }
            }
        }
        public void Damage(int dmg)
        {

        }
        public void AddChatLine(String str) { chat.Add(str); }
        public bool Chatting { get { return chatting; } set { chatting = value; } }
        public bool MerchantChatting { get { return merchantChatting; } set { merchantChatting = value; } }
        public int PosX { get { return x; } }
        public int PosY { get { return y; } }
        public int Direction { get { return direction; } set { direction = value; } }
        public bool Inv { get { return inventoryOpen; } set { inventoryOpen = value; } }
        public PlayerInventory PInv { get { return inv; } }
        public Texture2D BeltSprite { get { return invSprite; } }
        public int RenderPosX { get { return x - Game.Width / 2; } }
        public int RenderPosY { get { return y - Game.Height / 2; } }
        public bool PickUpItem { get { return pickUpItem; } set { pickUpItem = value; } }
    }
}
