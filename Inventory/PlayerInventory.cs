#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
//using CSFalpha1.Play.Level.NPC.Town;
using Item.Consumable.HealthPotion;
using Item.Weapon.Polearm;
using Item.Weapon.OneHSword;
using Item.Consumable;
using Item;
using Item.Weapon;
using Item.Armor.Shield;
using VideoDisplay;
using Item.Armor.Helmet;
using Item.Armor.Body;
using Item.Armor;
using Item.Armor.Gloves;
using Item.Armor.Belt;
using Item.Armor.Boots;
using ContentLoader;
using Item.Consumable.Food;
#endregion

namespace Inventory
{
    public sealed class PlayerInventory : AbstractInventory
    {
        private MouseStorage mouseStorage;
        private AbstractEquipment rightHand, leftHand;
        private AbstractHelmet helmet;
        private AbstractBodyArmor body;
        private AbstractBelt belt;
        private AbstractGloves gloves;
        private AbstractBoots boots;

        /// <summary>
        /// Creates a new inventory for the player to store items.
        /// The part is stored because of the List, but this provides
        /// the functions and Visual graphics.
        /// </summary>
        public PlayerInventory()
        {
            Item.Capacity = 51;
            Item.Add(new Cheong(0, 0));
            //Item.Add(new Scimitar(1, 0));
            Item.Add(new HeaterShield(1, 0));
            Item.Add(new Buckler(3, 0));
            //Item.Add(new ShortSword(4, 0));
            //Item.Add(new HonGim(5, 0));
            //Item.Add(new GwaanDou(6, 0));
            Item.Add(new SkullCap(6, 0));
            Item.Add(new Dou(3, 1));
            Item.Add(new HonGim(4, 1));
            Item.Add(new Naginata(8, 0));
            Item.Add(new HealthVial(0, 4));
            Item.Add(new HealthBottle(1, 4));
            Item.Add(new HealthFlask(2, 4));
            Item.Add(new HealthGourd(3, 4));
            Item.Add(new HealthPotion(4, 4));
            Item.Add(new HealthJar(5, 4));
            Item.Add(new Dragonfruit(6, 4));
            mouseStorage = new MouseStorage();

            InventorySprite = TheContentLoader.UITexture[0];
        }
        /// <summary>
        /// Uses a consumable item by checking if it is consumable,
        /// then remvoing it from the inventory.
        /// </summary>
        /// <param name="mouseState">MouseState</param>
        public void UseConsumableItem(MouseState mouseState)
        {
            for (int i = Item.Count - 1; i >= 0; i--)
            {
                AbstractConsumable temp = Item.ElementAt(i) as AbstractConsumable;
                if (temp != null)
                {
                    if (temp.UseItem(mouseState) != null)
                    {
                        if (mouseStorage.Item == null)
                        {
                            temp.UseItem();
                            Item.RemoveAt(i);
                            //Ends the unnecessary loops.
                            return;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Displays the graphics for the player's inventory.
        /// </summary>
        /// <param name="sb">SpriteBatch</param>
        public override void ShowInventory(SpriteBatch sb)
        {
            sb.Draw(InventorySprite, new Rectangle(VideoVariables.ResolutionWidth - 320, (VideoVariables.ResolutionHeight - 480) / 2, 320, 440), new Color(200, 200, 200, 225));
            for (int i = Item.Count - 1; i >= 0; i--)
            {
                if (Item.ElementAt(i) != null)
                {
                    try
                    {
                        if (!Item.ElementAt(i).Equals(mouseStorage.Item))
                        {
                            Item.ElementAt(i).Show(sb);
                        }
                    }
                    catch (ArgumentNullException)
                    {
                        Item.ElementAt(i).ItemSprite = TheContentLoader.BackUp;
                    }
                }
            }
        }
        /// <summary>
        /// Closes the inventory screen.
        /// </summary>
        /// <param name="mouseState">MouseState</param>
        public override void CloseMenu(MouseState mouseState)
        {
            if (mouseState.X >= (VideoVariables.ResolutionWidth - 320) + 10 && mouseState.X <= (VideoVariables.ResolutionWidth - 320) + 10 + 30)
            {
                if (mouseState.Y >= VideoVariables.ResolutionHeight / 2 + 165 && mouseState.Y <= VideoVariables.ResolutionHeight / 2 + 165 + 30)
                {
                    InventoryOpen = false;
                }
            }
        }
        #region Properties
        public MouseStorage MouseStorage { get { return mouseStorage; } set { mouseStorage = value; } }
        public AbstractEquipment RightHand { get { return rightHand; } set { rightHand = value; } }
        public AbstractEquipment LeftHand { get { return leftHand; } set { leftHand = value; } }
        public AbstractHelmet Helmet { get { return helmet; } set { helmet = value; } }
        public AbstractBodyArmor Body { get { return body; } set { body = value; } }
        public AbstractBelt Belt { get { return belt; } set { belt = value; } }
        public AbstractGloves Gloves { get { return gloves; } set { gloves = value; } }
        public AbstractBoots Boots { get { return boots; } set { boots = value; } }
        #endregion
    }
}
