#region Using Statements
using System;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
//using CSFalpha1.Play.Level.NPC.Town;
//using CSFalpha1.Play.Level;
using Item;
using Item.Weapon;
using Item.Armor.Shield;
using Item.Armor;
using VideoDisplay;
using Item.Armor.Helmet;
using Item.Armor.Body;
using Item.Armor.Gloves;
using Item.Armor.Belt;
using Item.Armor.Boots;
#endregion

namespace Inventory
{
    //This one class has to handle all of the item transfering.
    //I think it was one of the hardest to write.
    public sealed class MouseStorage
    {
        private AbstractItem oldItem, newItem;
        private const byte INVENTORY = 0, HELMET = 1, RIGHT_HAND = 2, BODY = 3, LEFT_HAND = 4, GLOVES = 5,
            BELT = 6, BOOTS = 7, AMULET = 8, RING1 = 9, RING2 = 10;


        public MouseStorage()
        {
            oldItem = null;
            newItem = null;
        }
        public void Show(SpriteBatch sb, MouseState mouseState)
        {
            if (newItem != null)
            {
                sb.Draw(newItem.ItemSprite,
                    new Vector2((int)mouseState.X - (30 * (newItem.SpaceX + 1) / 2),
                        (int)mouseState.Y - (30 * (newItem.SpaceY + 1) / 2)),
                        Color.White);
            }
        }
        public void DropItemInventory(MouseState mouseState, PlayerInventory playerInv)
        {
            bool factorX = false, factorY = false;

            for (int i = 0; i < 10; i++)
            {
                factorX = mouseState.X > (VideoVariables.ResolutionWidth - 320) + 10 && mouseState.X < (VideoVariables.ResolutionWidth - 320) + 10 + 30;

                if (!factorX)
                {
                    if (newItem == null)
                    {
                        factorX = true;
                    }
                    else
                    {
                        switch (newItem.SpaceX)
                        {
                            case 0:
                                factorX = mouseState.X > i * 30 + (VideoVariables.ResolutionWidth - 320) + 10 && mouseState.X < i * 30 + (VideoVariables.ResolutionWidth - 320) + 10 + 30;

                                if (!factorX && i == 9)
                                {
                                    factorX = mouseState.X > (i * 30) + (VideoVariables.ResolutionWidth - 320) + 10 + 15 && mouseState.X < (i * 30) + (VideoVariables.ResolutionWidth - 320) + 10 + 30;
                                }

                                break;

                            case 1:
                                factorX = mouseState.X > i * 30 + (VideoVariables.ResolutionWidth - 320) + 10 + 15 && mouseState.X < i * 30 + (VideoVariables.ResolutionWidth - 320) + 10 + 30 + 15;

                                if (!factorX && i == 8)
                                {
                                    factorX = mouseState.X > (i * 30) + (VideoVariables.ResolutionWidth - 320) + 10 + 15 && mouseState.X < (i * 30) + (VideoVariables.ResolutionWidth - 320) + 10 + 30 + 30;
                                }

                                break;
                        }
                    }
                }
                for (int j = 0; j < 5; j++)
                {
                    factorY = mouseState.Y > VideoVariables.ResolutionHeight / 2 + 10 && mouseState.Y < VideoVariables.ResolutionHeight / 2 + 10 + 30;

                    if (!factorY)
                    {
                        if (newItem == null)
                        {
                            factorY = true;
                        }
                        else
                        {
                            switch (newItem.SpaceY)
                            {
                                case 0:
                                    factorY = mouseState.Y > j * 30 + VideoVariables.ResolutionHeight / 2 + 10 && mouseState.Y < j * 30 + VideoVariables.ResolutionHeight / 2 + 10 + 30;
                                    break;

                                case 1:
                                    factorY = mouseState.Y > j * 30 + VideoVariables.ResolutionHeight / 2 + 10 + 15 && mouseState.Y < j * 30 + VideoVariables.ResolutionHeight / 2 + 10 + 30 + 15;

                                    if (!factorY && j == 3)
                                    {
                                        factorY = mouseState.Y > j * 30 + VideoVariables.ResolutionHeight / 2 + 10 && mouseState.Y < j * 30 + VideoVariables.ResolutionHeight / 2 + 10 + 30 + 30;
                                    }

                                    break;
                                case 2:
                                    factorY = mouseState.Y > j * 30 + VideoVariables.ResolutionHeight / 2 + 10 + 30 && mouseState.Y < j * 30 + VideoVariables.ResolutionHeight / 2 + 10 + 30 + 30;

                                    if (!factorY && j == 2)
                                    {
                                        factorY = mouseState.Y > j * 30 + VideoVariables.ResolutionHeight / 2 + 10 && mouseState.Y < j * 30 + VideoVariables.ResolutionHeight / 2 + 10 + 30 + 60;
                                    }

                                    break;
                                case 3:
                                    factorY = mouseState.Y > j * 30 + VideoVariables.ResolutionHeight / 2 + 10 + 45 && mouseState.Y < j * 30 + VideoVariables.ResolutionHeight / 2 + 10 + 30 + 45;

                                    if (!factorY && j == 1)
                                    {
                                        factorY = mouseState.Y > j * 30 + VideoVariables.ResolutionHeight / 2 + 10 + 45 && mouseState.Y < j * 30 + VideoVariables.ResolutionHeight / 2 + 10 + 30 + 45 + 90;
                                    }

                                    break;
                            }
                        }
                    }
                    if (factorX)
                    {
                        if (factorY)
                        {
                            if (newItem != null)
                            {
                                int jack;
                                if (newItem == null)
                                {
                                    jack = i;
                                }
                                else
                                {
                                    jack = i + newItem.SpaceX;
                                }
                                if (jack < 10)
                                {
                                    int jake;
                                    if (newItem == null)
                                    {
                                        jake = j;
                                    }
                                    else
                                    {
                                        jake = j + newItem.SpaceY;
                                    }
                                    if (jake < 5)
                                    {
                                        /*for (int z = playerInv.Item.Count - 1; z >= 0; z--)
                                        {
                                            if (playerInv.Item.ElementAt(z).Equals(newItem))
                                            {*/
                                        AbstractItem[] temp = CheckItem(mouseState, playerInv);

                                        if (temp[1] == null)
                                        {
                                            //playerInv.Item.ElementAt(z).PosX = i;
                                            //playerInv.Item.ElementAt(z).PosY = j;

                                            newItem.PosX = (byte)i;
                                            newItem.PosY = (byte)j;

                                            if (temp[0] == null)
                                            {
                                                oldItem = newItem;
                                                newItem = null;
                                            }
                                            else
                                            {
                                                //if (oldItem == null || !oldItem.Equals(temp[0]))
                                                //{
                                                oldItem = newItem;
                                                newItem = temp[0];
                                                //}
                                            }
                                            return;
                                            //}
                                            //}
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public void DropItemInventory(MouseState mouseState, PlayerInventory playerInv, MerchantInventory merchantInv)
        {
            bool factorX = false, factorY = false;

            for (int i = 0; i < 10; i++)
            {
                if (newItem == null)
                {
                    factorX = true;
                }
                else
                {
                    switch (newItem.SpaceX)
                    {
                        case 0:
                            factorX = mouseState.X > i * 30 + 10 && mouseState.X < i * 30 + 10 + 30;
                            break;
                        case 1:
                            factorX = mouseState.X > i * 30 + 10 + 15 && mouseState.X < i * 30 + 10 + 30 + 15;
                            break;
                    }
                }
                for (int j = 0; j < 13; j++)
                {
                    if (newItem == null)
                    {
                        factorY = true;
                    }
                    else
                    {
                        switch (newItem.SpaceY)
                        {
                            case 0:
                                factorY = mouseState.Y > j * 30 + (VideoVariables.ResolutionHeight / 2 - 230) && mouseState.Y < j * 30 + (VideoVariables.ResolutionHeight / 2 - 230) + 30;
                                break;
                            case 1:
                                factorY = mouseState.Y > j * 30 + (VideoVariables.ResolutionHeight / 2 - 230) + 15 && mouseState.Y < j * 30 + (VideoVariables.ResolutionHeight / 2 - 230) + 30 + 15;
                                break;
                            case 2:
                                factorY = mouseState.Y > j * 30 + (VideoVariables.ResolutionHeight / 2 - 230) + 30 && mouseState.Y < j * 30 + (VideoVariables.ResolutionHeight / 2 - 230) + 30 + 30;
                                break;
                            case 3:
                                factorY = mouseState.Y > j * 30 + (VideoVariables.ResolutionHeight / 2 - 230) + 45 && mouseState.Y < j * 30 + (VideoVariables.ResolutionHeight / 2 - 230) + 30 + 45;
                                break;
                        }
                    }
                    if (factorX)
                    {
                        if (factorY)
                        {
                            if (newItem != null)
                            {
                                int jack;
                                if (newItem == null)
                                {
                                    jack = i;
                                }
                                else
                                {
                                    jack = i + newItem.SpaceX;
                                }
                                if (jack < 10)
                                {
                                    int jake;
                                    if (newItem == null)
                                    {
                                        jake = j;
                                    }
                                    else
                                    {
                                        jake = j + newItem.SpaceY;
                                    }
                                    if (jake < 13)
                                    {
                                        AbstractItem[] temp = CheckItem(mouseState, merchantInv);

                                        if (temp[1] == null)
                                        {
                                            for (int giraffe = playerInv.Item.Count - 1; giraffe >= 0; giraffe--)
                                            {
                                                if (playerInv.Item.ElementAt(giraffe).Equals(newItem))
                                                {
                                                    playerInv.Item.RemoveAt(giraffe);
                                                    break;
                                                }
                                            }

                                            newItem.PosX = (byte)i;
                                            newItem.PosY = (byte)j;

                                            merchantInv.Item.Add(newItem);

                                            //Console.WriteLine("\nI am ready.\n");

                                            if (temp[0] == null)
                                            {
                                                //Console.WriteLine("\nDr. Aochider was called.\n");
                                                oldItem = newItem;
                                                newItem = null;
                                            }
                                            else
                                            {
                                                //if (oldItem == null || !oldItem.Equals(temp[0]))
                                                //{
                                                oldItem = newItem;
                                                //Console.WriteLine("Replaced " + newItem.Name + " with " + temp[0].Name);
                                                newItem = temp[0];

                                                for (int giraffe = merchantInv.Item.Count - 1; giraffe >= 0; giraffe--)
                                                {
                                                    if (merchantInv.Item.ElementAt(giraffe).Equals(temp[0]))
                                                    {
                                                        //Console.WriteLine("Removed " + merchantInv.Item.ElementAt(giraffe).Name + "\n");
                                                        merchantInv.Item.RemoveAt(giraffe);
                                                        break;
                                                    }
                                                }
                                                //}
                                            }
                                            return;

                                            #region Debugging Stuff
                                            /*
                                            Console.WriteLine("oldItem: " + oldItem.Name);
                                            Console.WriteLine(merchantInv.Item.Contains(oldItem));
                                            Console.WriteLine();
                                            if (newItem != null)
                                            {
                                                Console.WriteLine("newItem: " + newItem.Name);
                                            }
                                            else
                                            {
                                                Console.WriteLine("newItem: " + null);
                                            }
                                            Console.WriteLine(merchantInv.Item.Contains(newItem));
                                            Console.WriteLine("\n********\n");
                                            //*/
                                            #endregion
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        #region Equip Function
        public void DropItemEquipRightHand(PlayerInventory playerInv)
        {
            #region Right Hand Equip

            #region Right Hand Empty
            if (playerInv.RightHand == null)
            {
                #region Left Hand Not Empty
                if (playerInv.LeftHand != null)
                {
                    AbstractWeapon detOpt = newItem as AbstractWeapon, detOpt2 = playerInv.LeftHand as AbstractWeapon;

                    //if (detOpt == null)
                    //{
                    //detOpt = playerInv.LeftHand as AbstractWeapon;
                    //}

                    if ((detOpt != null && detOpt.TwoHand && !detOpt.OneHand) || (detOpt2 != null && detOpt2.TwoHand && !detOpt2.OneHand))
                    {
                        oldItem = newItem;
                        AbstractEquipment temp = playerInv.LeftHand;

                        playerInv.RightHand = newItem as AbstractEquipment;
                        #region Unused
                        /*
                        AbstractWeapon opt = newItem as AbstractWeapon;

                        if (opt != null)
                        {
                            playerInv.RightHand = opt;
                        }
                        else
                        {
                            playerInv.RightHand = newItem as AbstractShield;
                        }
                        */
                        #endregion

                        playerInv.RightHand.Equipped = RIGHT_HAND;
                        playerInv.LeftHand = null;
                        newItem = temp;
                        newItem.Equipped = INVENTORY;
                        playerInv.Item.Add(newItem);
                    }
                    else if (newItem is AbstractShield && playerInv.LeftHand is AbstractShield)
                    {
                        oldItem = newItem;
                        AbstractEquipment temp = playerInv.LeftHand;
                        playerInv.RightHand = newItem as AbstractShield;
                        playerInv.RightHand.Equipped = RIGHT_HAND;
                        playerInv.LeftHand = null;
                        newItem = temp;
                        newItem.Equipped = INVENTORY;
                        playerInv.Item.Add(newItem);
                    }
                    else
                    {
                        oldItem = newItem;

                        playerInv.RightHand = newItem as AbstractEquipment;
                        #region Unused
                        /*
                        AbstractWeapon opt = newItem as AbstractWeapon;

                        if (opt != null)
                        {
                            playerInv.RightHand = opt;
                        }
                        else
                        {
                            playerInv.RightHand = newItem as AbstractShield;
                        }
                        */
                        #endregion

                        playerInv.RightHand.Equipped = RIGHT_HAND;
                        newItem = null;
                    }
                }
                #endregion
                #region Left Hand Empty
                else
                {
                    oldItem = newItem;

                    AbstractWeapon opt = newItem as AbstractWeapon;

                    if (opt != null)
                    {
                        playerInv.RightHand = opt;
                    }
                    else
                    {
                        playerInv.RightHand = newItem as AbstractShield;
                    }
                    playerInv.RightHand.Equipped = RIGHT_HAND;
                    newItem = null;
                }
                #endregion

                #region Unused
                /*for (int i = playerInv.Item.Count - 1; i >= 0; i--)
                {
                    if (playerInv.Item.ElementAt(i).Equals(oldItem))
                    {
                        playerInv.Item.RemoveAt(i);
                        break;
                    }
                }*/
                #endregion
            }
            #endregion

            #region Right Hand Not Empty
            else
            {
                if (playerInv.LeftHand == null)
                {
                    oldItem = newItem;
                    AbstractEquipment temp = playerInv.RightHand;

                    playerInv.RightHand = newItem as AbstractEquipment;
                    #region Unused
                    /*
                    if (newItem is AbstractWeapon)
                    {
                        playerInv.RightHand = newItem as AbstractWeapon;
                    }
                    else
                    {
                        playerInv.RightHand = newItem as AbstractShield;
                    }
                    */
                    #endregion

                    playerInv.RightHand.Equipped = RIGHT_HAND;
                    newItem = temp;
                    newItem.Equipped = INVENTORY;
                    playerInv.Item.Add(newItem);
                }
                else
                {
                    AbstractWeapon opt = newItem as AbstractWeapon;
                    if (opt != null)
                    {
                        if (opt.TwoHand && !opt.OneHand)
                        {
                            return;
                        }
                        oldItem = newItem;
                        AbstractEquipment temp = playerInv.RightHand;
                        playerInv.RightHand = opt;
                        playerInv.RightHand.Equipped = RIGHT_HAND;
                        newItem = temp;
                        newItem.Equipped = 0;
                        playerInv.Item.Add(newItem);
                    }
                    else
                    {
                        if (playerInv.RightHand is AbstractShield)
                        {
                            oldItem = newItem;
                            AbstractEquipment temp = playerInv.RightHand;
                            playerInv.RightHand = newItem as AbstractShield;
                            playerInv.RightHand.Equipped = RIGHT_HAND;
                            newItem = temp;
                            newItem.Equipped = INVENTORY;
                            playerInv.Item.Add(newItem);
                        }
                        else
                        {
                            opt = playerInv.RightHand as AbstractWeapon;
                            if (opt.TwoHand && !opt.OneHand)
                            {
                                return;
                            }
                            if (playerInv.LeftHand is AbstractShield)
                            {
                                return;
                            }
                            oldItem = newItem;
                            AbstractEquipment temp = playerInv.RightHand;
                            playerInv.RightHand = newItem as AbstractShield;
                            playerInv.RightHand.Equipped = RIGHT_HAND;
                            newItem = temp;
                            newItem.Equipped = INVENTORY;
                            playerInv.Item.Add(newItem);
                        }
                    }
                }
            }
            #endregion

            for (int i = playerInv.Item.Count - 1; i >= 0; i--)
            {
                if (playerInv.Item.ElementAt(i).Equals(oldItem))
                {
                    playerInv.Item.RemoveAt(i);
                    break;
                }
            }
            #endregion
            TheEpicTrapCard();
        }
        public void DropItemEquipLeftHand(PlayerInventory playerInv)
        {
            #region Left Hand Equip
            if (playerInv.LeftHand == null)
            {
                #region Right Hand Not Empty
                if (playerInv.RightHand != null)
                {
                    AbstractWeapon detOpt = newItem as AbstractWeapon, detOpt2 = playerInv.RightHand as AbstractWeapon;

                    if ((detOpt != null && detOpt.TwoHand && !detOpt.OneHand) || (detOpt2 != null && detOpt2.TwoHand && !detOpt2.OneHand))
                    {
                        oldItem = newItem;
                        AbstractItem temp = playerInv.RightHand;

                        playerInv.LeftHand = newItem as AbstractEquipment;
                        #region Unused
                        /*
                        AbstractWeapon opt = newItem as AbstractWeapon;

                        if (opt != null)
                        {
                            playerInv.LeftHand = opt;
                        }
                        else
                        {
                            playerInv.LeftHand = newItem as AbstractShield;
                        }
                        */
                        #endregion

                        playerInv.LeftHand.Equipped = LEFT_HAND;
                        playerInv.RightHand = null;
                        newItem = temp;
                        newItem.Equipped = INVENTORY;
                        playerInv.Item.Add(newItem);
                    }
                    else if (newItem is AbstractShield && playerInv.RightHand is AbstractShield)
                    {
                        oldItem = newItem;
                        AbstractItem temp = playerInv.RightHand;
                        playerInv.LeftHand = newItem as AbstractShield;
                        playerInv.LeftHand.Equipped = LEFT_HAND;
                        playerInv.RightHand = null;
                        newItem = temp;
                        newItem.Equipped = INVENTORY;
                        playerInv.Item.Add(newItem);
                    }
                    else
                    {
                        oldItem = newItem;

                        playerInv.LeftHand = newItem as AbstractEquipment;
                        #region Unused
                        /*
                        AbstractWeapon opt = newItem as AbstractWeapon;

                        if (opt != null)
                        {
                            playerInv.LeftHand = opt;
                        }
                        else
                        {
                            playerInv.LeftHand = newItem as AbstractShield;
                        }
                        */
                        #endregion

                        playerInv.LeftHand.Equipped = LEFT_HAND;
                        newItem = null;
                    }
                }
                #endregion
                #region Right Hand Empty
                else
                {
                    oldItem = newItem;

                    playerInv.LeftHand = newItem as AbstractEquipment;
                    #region Unused
                    /*
                    AbstractWeapon opt = newItem as AbstractWeapon;

                    if (opt != null)
                    {
                        playerInv.LeftHand = opt;
                    }
                    else
                    {
                        playerInv.LeftHand = newItem as AbstractShield;
                    }
                    */
                    #endregion

                    playerInv.LeftHand.Equipped = LEFT_HAND;
                    newItem = null;
                }
                #endregion
                //playerInv.Item.RemoveAt(playerInv.Item.Count - 1);
            }
            else
            {
                if (playerInv.RightHand == null)
                {
                    oldItem = newItem;
                    AbstractItem temp = playerInv.LeftHand;

                    playerInv.LeftHand = newItem as AbstractEquipment;
                    #region Unused
                    /*
                    AbstractWeapon opt = newItem as AbstractWeapon;

                    if (opt != null)
                    {
                        playerInv.LeftHand = opt;
                    }
                    else
                    {
                        playerInv.LeftHand = newItem as AbstractShield;
                    }
                    */
                    #endregion
                    playerInv.LeftHand.Equipped = LEFT_HAND;
                    newItem = temp;
                    newItem.Equipped = INVENTORY;
                    playerInv.Item.Add(newItem);
                }
                else
                {
                    AbstractWeapon opt = newItem as AbstractWeapon;
                    if (opt != null)
                    {
                        if (opt.TwoHand && !opt.OneHand)
                        {
                            return;
                        }
                        oldItem = newItem;
                        AbstractItem temp = playerInv.LeftHand;
                        playerInv.LeftHand = opt;
                        playerInv.LeftHand.Equipped = LEFT_HAND;
                        newItem = temp;
                        newItem.Equipped = INVENTORY;
                        playerInv.Item.Add(newItem);
                    }
                    else
                    {
                        if (playerInv.LeftHand is AbstractShield)
                        {
                            oldItem = newItem;
                            AbstractItem temp = playerInv.LeftHand;
                            playerInv.LeftHand = newItem as AbstractShield;
                            playerInv.LeftHand.Equipped = LEFT_HAND;
                            newItem = temp;
                            newItem.Equipped = INVENTORY;
                            playerInv.Item.Add(newItem);
                        }
                        else
                        {
                            opt = playerInv.LeftHand as AbstractWeapon;
                            if (opt.TwoHand && !opt.OneHand)
                            {
                                return;
                            }
                            if (playerInv.RightHand is AbstractShield)
                            {
                                return;
                            }
                            oldItem = newItem;
                            AbstractItem temp = playerInv.LeftHand;
                            playerInv.LeftHand = newItem as AbstractShield;
                            playerInv.LeftHand.Equipped = LEFT_HAND;
                            newItem = temp;
                            newItem.Equipped = INVENTORY;
                            playerInv.Item.Add(newItem);
                        }
                    }
                }
            }
            for (int i = playerInv.Item.Count - 1; i >= 0; i--)
            {
                if (playerInv.Item.ElementAt(i).Equals(oldItem))
                {
                    playerInv.Item.RemoveAt(i);
                }
            }
            #endregion
            TheEpicTrapCard();
        }

        public void DropItemEquipHelmet(PlayerInventory playerInv)
        {
            #region Helmet
            AbstractHelmet opt = newItem as AbstractHelmet;
            if (opt != null)
            {
                if (playerInv.Helmet == null)
                {
                    oldItem = newItem;
                    playerInv.Helmet = opt;
                    playerInv.Helmet.Equipped = HELMET;
                    newItem = null;
                }
                else
                {
                    oldItem = newItem;
                    AbstractItem temp = playerInv.Helmet;
                    playerInv.Helmet = opt;
                    playerInv.Helmet.Equipped = HELMET;
                    newItem = temp;
                }

                for (int i = playerInv.Item.Count - 1; i >= 0; i--)
                {
                    if (playerInv.Item.ElementAt(i).Equals(oldItem))
                    {
                        playerInv.Item.RemoveAt(i);
                        break;
                    }
                }
            }
            #endregion
            TheEpicTrapCard();
        }
        public void DropItemEquipBodyArmor(PlayerInventory playerInv)
        {
            #region Body Armor
            AbstractBodyArmor opt = newItem as AbstractBodyArmor;
            if (opt != null)
            {
                if (playerInv.Body == null)
                {
                    oldItem = newItem;
                    playerInv.Body = opt;
                    playerInv.Body.Equipped = BODY;
                    newItem = null;
                }
                else
                {
                    oldItem = newItem;
                    AbstractItem temp = playerInv.Body;
                    playerInv.Body = opt;
                    playerInv.Body.Equipped = BODY;
                    newItem = temp;
                }

                for (int i = playerInv.Item.Count - 1; i >= 0; i--)
                {
                    if (playerInv.Item.ElementAt(i).Equals(oldItem))
                    {
                        playerInv.Item.RemoveAt(i);
                        break;
                    }
                }
            }
            #endregion
            TheEpicTrapCard();
        }
        public void DropItemEquipGloves(PlayerInventory playerInv)
        {
            #region Gloves
            AbstractGloves opt = newItem as AbstractGloves;
            if (opt != null)
            {
                if (playerInv.Gloves == null)
                {
                    oldItem = newItem;
                    playerInv.Gloves = opt;
                    playerInv.Gloves.Equipped = GLOVES;
                    newItem = null;
                }
                else
                {
                    oldItem = newItem;
                    AbstractItem temp = playerInv.Gloves;
                    playerInv.Gloves = opt;
                    playerInv.Gloves.Equipped = GLOVES;
                    newItem = temp;
                }

                for (int i = playerInv.Item.Count - 1; i >= 0; i--)
                {
                    if (playerInv.Item.ElementAt(i).Equals(oldItem))
                    {
                        playerInv.Item.RemoveAt(i);
                        break;
                    }
                }
            }
            #endregion
            TheEpicTrapCard();
        }
        public void DropItemEquipBelt(PlayerInventory playerInv)
        {
            #region Belt
            AbstractBelt opt = newItem as AbstractBelt;
            if (opt != null)
            {
                if (playerInv.Belt == null)
                {
                    oldItem = newItem;
                    playerInv.Belt = opt;
                    playerInv.Belt.Equipped = BELT;
                    newItem = null;
                }
                else
                {
                    oldItem = newItem;
                    AbstractItem temp = playerInv.Belt;
                    playerInv.Belt = opt;
                    playerInv.Belt.Equipped = BELT;
                    newItem = temp;
                }

                for (int i = playerInv.Item.Count - 1; i >= 0; i--)
                {
                    if (playerInv.Item.ElementAt(i).Equals(oldItem))
                    {
                        playerInv.Item.RemoveAt(i);
                        break;
                    }
                }
            }
            #endregion
            TheEpicTrapCard();
        }
        public void DropItemEquipBoots(PlayerInventory playerInv)
        {
            #region Boots
            AbstractBoots opt = newItem as AbstractBoots;
            if (opt != null)
            {
                if (playerInv.Boots == null)
                {
                    oldItem = newItem;
                    playerInv.Boots = opt;
                    playerInv.Boots.Equipped = BOOTS;
                    newItem = null;
                }
                else
                {
                    oldItem = newItem;
                    AbstractItem temp = playerInv.Boots;
                    playerInv.Boots = opt;
                    playerInv.Boots.Equipped = BOOTS;
                    newItem = temp;
                }

                for (int i = playerInv.Item.Count - 1; i >= 0; i--)
                {
                    if (playerInv.Item.ElementAt(i).Equals(oldItem))
                    {
                        playerInv.Item.RemoveAt(i);
                        break;
                    }
                }
            }
            #endregion
            TheEpicTrapCard();
        }

        #endregion

        #region CheckItem Stuff

        private AbstractItem[] CheckItem(MouseState mouseState, PlayerInventory playerInv)
        {
            AbstractItem[] temp = new AbstractItem[2];
            for (int i = playerInv.Item.Count - 1; i >= 0; i--)
            {
                if (!newItem.Equals(playerInv.Item.ElementAt(i)))
                {
                    if (playerInv.Item.ElementAt(i).PickupItem(mouseState, newItem) != null)
                    {
                        if (temp[0] == null)
                        {
                            temp[0] = playerInv.Item.ElementAt(i).PickupItem(mouseState, newItem);
                        }
                        else
                        {
                            temp[1] = playerInv.Item.ElementAt(i).PickupItem(mouseState, newItem);
                            return temp;
                        }
                    }
                }
            }
            return temp;
        }
        private AbstractItem[] CheckItem(MouseState mouseState, MerchantInventory merchantInv)
        {
            AbstractItem[] temp = new AbstractItem[2];
            for (int i = merchantInv.Item.Count - 1; i >= 0; i--)
            {
                /*if (!newItem.Equals(merchantInv.Item.ElementAt(i)))
                {*/
                if (merchantInv.Item.ElementAt(i).PickupItem(mouseState, newItem) != null)
                {
                    if (temp[0] == null)
                    {
                        temp[0] = merchantInv.Item.ElementAt(i).PickupItem(mouseState, newItem);
                    }
                    else
                    {
                        temp[1] = merchantInv.Item.ElementAt(i).PickupItem(mouseState, newItem);
                        return temp;
                    }
                }
                //}
            }
            return temp;
        }

        #region Required or game will fail
        /// <summary>
        /// Whoop kicks in. Hopefully you didn't do something wrong.
        /// </summary>
        private void TheEpicTrapCard()
        {
            if (newItem != null)
            {
                newItem.Woop();
            }
        }
        #endregion

        #endregion
        #region Properties
        public AbstractItem Item { get { return newItem; } set { newItem = value; } }
        public AbstractItem OldItem { get { return oldItem; } set { oldItem = value; } }
        #endregion
    }
}
