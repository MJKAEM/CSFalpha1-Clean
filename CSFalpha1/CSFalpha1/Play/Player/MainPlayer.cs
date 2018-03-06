#region Using Statements
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
using Inventory;
using Item.Weapon;
using Item;
using Item.Armor;
using Item.Armor.Body;
using Item.Armor.Helmet;
using VideoDisplay;
using NPC.Town;
using NPC;
using System.Diagnostics.Contracts;
using ContentLoader;
#endregion

namespace CSFalpha1.Play.Player
{
    public sealed class MainPlayer
    {
        private const int WIDTH = 48, HEIGHT = 64;

        private const byte maxLevel = 100;

        private bool movingUp, movingDown, movingLeft, movingRight;
        private bool chatting;
        private bool pickUpItem;
        private int chatLine;
        private int x, y;
        private int curHealth, maxHealth;
        private int direction, tempDirection;
        private byte level;
        private int experience, levelUp;
        private PlayerInventory inv = new PlayerInventory();
        private string[] chat = new string[5];

        private Texture2D charSprite;
        private Texture2D invSprite;
        private Texture2D healthBar, healthBarBorder;
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
            pickUpItem = false;
            maxHealth = 25;
            curHealth = maxHealth;

            charSprite = TheContentLoader.CharSprite[0];
            chatFont = TheContentLoader.Font[3];
            invSprite = TheContentLoader.UITexture[2];
            healthBar = TheContentLoader.UITexture[3];
            healthBarBorder = TheContentLoader.UITexture[4];
        }
        #region Show Functions
        public void Show(SpriteBatch sb, MouseState mouseState)
        {
            try
            {
                switch (direction)
                {
                    case 0:
                        sb.Draw(charSprite,
                            new Rectangle(VideoVariables.ResolutionWidth / 2 - (WIDTH / 2), VideoVariables.ResolutionHeight / 2 - (HEIGHT / 2), WIDTH, HEIGHT),
                            new Rectangle(0, 0, 32, 32),
                            Color.White);
                        break;

                    case 1:
                        sb.Draw(charSprite,
                            new Rectangle(VideoVariables.ResolutionWidth / 2 - (WIDTH / 2), VideoVariables.ResolutionHeight / 2 - (HEIGHT / 2), WIDTH, HEIGHT),
                            new Rectangle(32, 32, 32, 32),
                            Color.White);
                        break;

                    case 2:
                        sb.Draw(charSprite,
                            new Rectangle(VideoVariables.ResolutionWidth / 2 - (WIDTH / 2), VideoVariables.ResolutionHeight / 2 - (HEIGHT / 2), WIDTH, HEIGHT),
                            new Rectangle(32, 0, 32, 32),
                            Color.White);
                        break;

                    case 3:
                        sb.Draw(charSprite,
                            new Rectangle(VideoVariables.ResolutionWidth / 2 - (WIDTH / 2), VideoVariables.ResolutionHeight / 2 - (HEIGHT / 2), WIDTH, HEIGHT),
                            new Rectangle(0, 32, 32, 32),
                           Color.White);
                        break;
                }
            }
            catch (ArgumentNullException)
            {
                charSprite = TheContentLoader.BackUp;
            }
        }
        public void ShowHealthBar(SpriteBatch sb)
        {
            sb.Draw(healthBar, new Rectangle(5, VideoVariables.ResolutionHeight - 80, (int)(((float)curHealth / maxHealth) * healthBar.Width), healthBar.Height), Color.White);
            sb.DrawString(TheContentLoader.Font[0], curHealth.ToString(), new Vector2(20, VideoVariables.ResolutionHeight - 78), Color.IndianRed);
            sb.Draw(healthBarBorder, new Vector2(3, VideoVariables.ResolutionHeight - 82), Color.White);
        }
        public void ShowMouseStorage(SpriteBatch sb, MouseState mouseState)
        {
            if (inv.MouseStorage != null)
            {
                inv.MouseStorage.Show(sb, mouseState);
            }
        }
        #endregion
        #region Pickup Item Functions
        public void PickupPlayerInventoryItem(MouseState mouseState)
        {
            for (int i = PInv.Item.Count - 1; i >= 0; --i)
            {
                if (inv.Item.ElementAt(i).PickupItem(mouseState) != null)
                {
                    inv.MouseStorage.Item = inv.Item.ElementAt(i);
                    inv.MouseStorage.Item.Equipped = 0;
                    pickUpItem = true;
                    return;
                }
                if (inv.RightHand != null)
                {
                    if (inv.RightHand.PickupItem(mouseState) != null)
                    {
                        inv.MouseStorage.Item = inv.RightHand;
                        pickUpItem = true;
                        inv.MouseStorage.Item.Equipped = 0;
                        inv.Item.Add(inv.MouseStorage.Item);
                        inv.RightHand = null;
                        return;
                    }
                }
                if (inv.LeftHand != null)
                {
                    if (inv.LeftHand.PickupItem(mouseState) != null)
                    {
                        inv.MouseStorage.Item = inv.LeftHand;
                        pickUpItem = true;
                        inv.MouseStorage.Item.Equipped = 0;
                        inv.Item.Add(inv.MouseStorage.Item);
                        inv.LeftHand = null;
                        return;
                    }
                }
                if (inv.Helmet != null)
                {
                    if (inv.Helmet.PickupItem(mouseState) != null)
                    {
                        inv.MouseStorage.Item = inv.Helmet;
                        pickUpItem = true;
                        inv.MouseStorage.Item.Equipped = 0;
                        inv.Item.Add(inv.MouseStorage.Item);
                        inv.Helmet = null;
                        return;
                    }
                }
            }
        }
        public void PickupOtherInventoryItem(MouseState mouseState, MerchantInventory merchantInv)
        {
            for (int i = merchantInv.Item.Count - 1; i >= 0; --i)
            {
                if (merchantInv.Item.ElementAt(i).PickupItemStash(mouseState) != null)
                {
                    inv.MouseStorage.Item = merchantInv.Item.ElementAt(i);
                    Console.WriteLine(merchantInv.Item.IndexOf(merchantInv.Item.ElementAt(i)));
                    Console.WriteLine(i);
                    merchantInv.Item.RemoveAt(i);
                    /*for (int j = merchantInv.Item.Count - 1; j >= 0; j--)
                    {
                        if (merchantInv.Item.ElementAt(j).Equals(inv.MouseStorage.Item))
                        {
                            merchantInv.Item.RemoveAt(j);
                        }
                    }*/
                    inv.MouseStorage.Item.Equipped = 0;
                    inv.Item.Add(inv.MouseStorage.Item);
                    pickUpItem = true;
                    Console.WriteLine(inv.MouseStorage.Item.Name);
                    Console.WriteLine(merchantInv.Item.Contains(inv.MouseStorage.Item) + "\n");
                    return;
                }
            }
        }
        #endregion
        public void Move()
        {
            if (!chatting)
            {
                Turn();
                if (movingUp)
                {
                    y -= 2;

                    if (TouchingNPCOnUp())
                    {
                        y += 2;
                    }
                }
                if (movingDown)
                {
                    y += 2;

                    if (TouchingNPCOnDown())
                    {
                        y -= 2;
                    }
                }
                if (movingLeft)
                {
                    x -= 2;

                    if (TouchingNPCOnLeft())
                    {
                        x += 2;
                    }
                }
                if (movingRight)
                {
                    x += 2;

                    if (TouchingNPCOnRight())
                    {
                        x -= 2;
                    }
                }
            }
        }
        public void Move(byte a)
        {
            Contract.Requires(a >= 0 && a <= 3, "Error: Can only call Player.Move() with an argument: integer between 0-3.");
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
                    throw new ArgumentException();
            }
        }
        public void Stop(byte a)
        {
            Contract.Requires(a >= 0 && a <= 3, "Error: Can only call Player.Stop() with an argument: integer between 0-3.");

            switch (a)
            {
                case 0:
                    movingUp = false;
                    break;
                case 1:
                    movingDown = false;
                    break;
                case 2:
                    movingLeft = false;
                    break;
                case 3:
                    movingRight = false;
                    break;
                default:
                    throw new ArgumentException();
            }
            if (tempDirection == a)
            {
                tempDirection = -1;
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
            if (chatting && chat.Length > 0)
            {
                sb.DrawString(chatFont, chat.ElementAt(chatLine), new Vector2(20, VideoVariables.ResolutionHeight - 100), Color.White);
            }
        }
        public void Chat()
        {

        }
        public void Damage(int dmg)
        {

        }
        public void Heal(int healPower)
        {
            if (curHealth + healPower < maxHealth)
            {
                curHealth += healPower;
            }
            else
            {
                curHealth = maxHealth;
            }
        }
        /// <summary>
        /// Precondition: The level is not null. I mean, it SHOULDN'T happen.
        /// Postcondition: NPC's are not modified after calling the code.
        /// 
        /// With collision off, this would be useless.
        /// </summary>
        /// <returns>The List of NPC's surrounding the player in the current level.</returns>
        public List<AbstractNPC> GetSurroundingNPC()
        {
            List<AbstractNPC> temp = new List<AbstractNPC>();
            if (Main.Collision == 0)
            {
                return temp;
            }
            if (PlayState.CurrentLevel != -1)
            {
                for (int i = 0; i < PlayState.Level[PlayState.CurrentLevel].GetNPC.Count; i++)
                {
                    //int hypoX = PlayState.Level[PlayState.CurrentLevel].GetNPC.ElementAt(i).PosX - x;
                    //int hypoY = PlayState.Level[PlayState.CurrentLevel].GetNPC.ElementAt(i).PosY - y;

                    //double hypo = Math.Sqrt(Math.Pow(PlayState.Level[PlayState.CurrentLevel].GetNPC.ElementAt(i).PosX - x, 2) + Math.Pow(PlayState.Level[PlayState.CurrentLevel].GetNPC.ElementAt(i).PosY - y, 2));

                    if (Math.Sqrt(Math.Pow(PlayState.Level[PlayState.CurrentLevel].GetNPC.ElementAt(i).PosX - x, 2) + Math.Pow(PlayState.Level[PlayState.CurrentLevel].GetNPC.ElementAt(i).PosY - y, 2)) < WIDTH / 2)
                    {
                        temp.Add(PlayState.Level[PlayState.CurrentLevel].GetNPC.ElementAt(i));
                    }
                }
            }
            else
            {
                for (int i = 0; i < PlayState.Town.GetNPC.Length; i++)
                {
                    //int hypoX = PlayState.Town.GetNPC.ElementAt(i).PosX - x;
                    //int hypoY = PlayState.Town.GetNPC.ElementAt(i).PosY - y;

                    //double hypo = Math.Sqrt(Math.Pow(PlayState.Town.GetNPC.ElementAt(i).PosX - x, 2) + Math.Pow(PlayState.Town.GetNPC.ElementAt(i).PosY - y, 2));

                    if (Math.Sqrt(Math.Pow(PlayState.Town.GetNPC.ElementAt(i).PosX - x, 2) + Math.Pow(PlayState.Town.GetNPC.ElementAt(i).PosY - y, 2)) < WIDTH / 2 + PlayState.Town.GetNPC.ElementAt(i).Width / 2)
                    {
                        temp.Add(PlayState.Town.GetNPC.ElementAt(i));
                    }
                }
                Console.WriteLine();
            }
            return temp;
        }
        #region TouchingNPCDirectionStuff
        public bool TouchingNPCOnLeft()
        {
            List<AbstractNPC> temp = GetSurroundingNPC();

            for (int i = temp.Count - 1; i >= 0; i--)
            {
                if (temp.ElementAt(i).PosX + temp.ElementAt(i).Width > x - WIDTH / 2)
                {
                    return true;
                }
            }
            return false;
        }
        public bool TouchingNPCOnRight()
        {
            List<AbstractNPC> temp = GetSurroundingNPC();

            for (int i = temp.Count - 1; i >= 0; i--)
            {
                if (temp.ElementAt(i).PosX - temp.ElementAt(i).Width < x + WIDTH / 2)
                {
                    return true;
                }
            }
            return false;
        }
        public bool TouchingNPCOnUp()
        {
            List<AbstractNPC> temp = GetSurroundingNPC();

            for (int i = temp.Count - 1; i >= 0; i--)
            {
                if (temp.ElementAt(i).PosY + temp.ElementAt(i).Width > y - WIDTH / 2)
                {
                    return true;
                }
            }
            return false;
        }
        public bool TouchingNPCOnDown()
        {
            List<AbstractNPC> temp = GetSurroundingNPC();

            for (int i = temp.Count - 1; i >= 0; i--)
            {
                if (temp.ElementAt(i).PosY - temp.ElementAt(i).Width < y + WIDTH / 2)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion
        #region Return Properties
        public bool Chatting { get { return chatting; } set { chatting = value; } }
        public int PosX { get { return x; } }
        public int PosY { get { return y; } }
        public int Direction { get { return direction; } set { direction = value; } }
        public PlayerInventory PInv { get { return inv; } }
        public Texture2D BeltSprite { get { return invSprite; } }
        public Texture2D HealthBar { get { return healthBar; } }
        public Texture2D HealthBarBorder { get { return healthBarBorder; } }
        public bool PickUpItem { get { return pickUpItem; } set { pickUpItem = value; } }
        public int Width { get { return WIDTH; } }
        public int Height { get { return HEIGHT; } }
        #endregion
    }
}
