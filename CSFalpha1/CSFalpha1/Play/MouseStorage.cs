using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using CSFalpha1.Play.Level.NPC.Town;
using CSFalpha1.Play.Level;
using CSFalpha1.Play.Item;

namespace CSFalpha1.Play
{
    public sealed class MouseStorage
    {
        private abstractItem oldItem, newItem, nothing;

        public MouseStorage()
        {
            nothing = new Nothing();
            oldItem = nothing;
            newItem = nothing;
        }
        public void Show(SpriteBatch sb, MouseState mouseState)
        {
            sb.Draw(newItem.ItemSprite,
                new Rectangle((int)mouseState.X - (30 * (newItem.SpaceX + 1) / 2),
                    (int)mouseState.Y - (30 * (newItem.SpaceY + 1) / 2),
                    newItem.ItemSprite.Width, newItem.ItemSprite.Height),
                    Color.White);
        }
        public void DropItem(MouseState mouseState)
        {
            if (PlayState.Player.Inv)
            {
                Merchant npc = null;
                for (int elephant = 0; elephant < ((Town)PlayState.Level.ElementAt(0)).GetNPC.Count(); elephant++)
                {
                    if (((Town)PlayState.Level.ElementAt(0)).GetNPC.ElementAt(elephant) is Merchant)
                    {
                        if (((Merchant)((Town)PlayState.Level.ElementAt(0)).GetNPC.ElementAt(elephant)).IsTrading)
                        {
                            npc = ((Merchant)((Town)PlayState.Level.ElementAt(0)).GetNPC.ElementAt(elephant));
                        }
                    }
                }
                if (mouseState.X > Game.Width / 2)
                {
                    bool factorX = false, factorY = false;

                    for (int i = 0; i < 10; i++)
                    {
                        switch (newItem.SpaceX)
                        {
                            case 0:
                                factorX = mouseState.X > i * 30 + (Game.Width - 320) + 10 && mouseState.X < i * 30 + (Game.Width - 320) + 10 + 30;
                                break;
                            case 1:
                                factorX = mouseState.X > i * 30 + (Game.Width - 320) + 10 + 15 && mouseState.X < i * 30 + (Game.Width - 320) + 10 + 30 + 15;
                                break;
                        }
                        for (int j = 0; j < 5; j++)
                        {
                            switch (newItem.SpaceY)
                            {
                                case 0:
                                    factorY = mouseState.Y > j * 30 + Game.Height / 2 + 10 && mouseState.Y < j * 30 + Game.Height / 2 + 10 + 30;
                                    break;
                                case 1:
                                    factorY = mouseState.Y > j * 30 + Game.Height / 2 + 10 + 15 && mouseState.Y < j * 30 + Game.Height / 2 + 10 + 30 + 15;
                                    break;
                                case 2:
                                    factorY = mouseState.Y > j * 30 + Game.Height / 2 + 10 + 30 && mouseState.Y < j * 30 + Game.Height / 2 + 10 + 30 + 30;
                                    break;
                                case 3:
                                    factorY = mouseState.Y > j * 30 + Game.Height / 2 + 10 + 45 && mouseState.Y < j * 30 + Game.Height / 2 + 10 + 30 + 45;
                                    break;
                            }
                            if (factorX)
                            {
                                if (factorY)
                                {
                                    if (!newItem.Equals(Nothing))
                                    {
                                        if (newItem.PlayerItem)
                                        {
                                            for (int z = 0; z < PlayState.Player.PInv.Item.Count(); z++)
                                            {
                                                if (i + newItem.SpaceX < 10)
                                                {
                                                    if (j + newItem.SpaceY < 5)
                                                    {
                                                        if (PlayState.Player.PInv.Item.ElementAt(z).Equals(newItem))
                                                        {
                                                            List<abstractItem> temp = new List<abstractItem>();
                                                            temp = CheckItem(PlayState.Player.PInv.Item.ElementAt(z), mouseState, newItem);
                                                            if (temp.Count() < 2)
                                                            {
                                                                PlayState.Player.PInv.Item.ElementAt(z).PosX = i;
                                                                PlayState.Player.PInv.Item.ElementAt(z).PosY = j;

                                                                PlayState.Player.PickUpItem = false;

                                                                if (temp.ElementAt(0).Equals(nothing))
                                                                {
                                                                    PlayState.Player.PInv.Item.ElementAt(z).PlayerItem = true;
                                                                    oldItem = newItem;
                                                                    newItem = nothing;

                                                                }
                                                                else
                                                                {
                                                                    PlayState.Player.PickUpItem = true;
                                                                    if (!oldItem.Equals(temp.ElementAt(0)))
                                                                    {
                                                                        PlayState.Player.PInv.Item.ElementAt(z).PlayerItem = true;
                                                                        oldItem = newItem;
                                                                        newItem = temp.ElementAt(0);
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            for (int z = 0; z < npc.GetInventory.Item.Count(); z++)
                                            {
                                                if (i + newItem.SpaceX < 10)
                                                {
                                                    if (j + newItem.SpaceY < 5)
                                                    {
                                                        if (npc.GetInventory.Item.ElementAt(z).Equals(newItem))
                                                        {
                                                            List<abstractItem> temp = new List<abstractItem>();

                                                            temp = CheckItem(npc.GetInventory.Item.ElementAt(z), mouseState, newItem);

                                                            if (temp.Count() < 2)
                                                            {
                                                                PlayState.Player.PInv.Item.Add(npc.GetInventory.Item.ElementAt(z));

                                                                npc.GetInventory.Item.RemoveAt(z);

                                                                PlayState.Player.PInv.Item.ElementAt(PlayState.Player.PInv.Item.Count() - 1).PosX = i;
                                                                PlayState.Player.PInv.Item.ElementAt(PlayState.Player.PInv.Item.Count() - 1).PosY = j;

                                                                PlayState.Player.PickUpItem = false;

                                                                if (temp.ElementAt(0).Equals(nothing))
                                                                {
                                                                    PlayState.Player.PInv.Item.ElementAt(PlayState.Player.PInv.Item.Count() - 1).PlayerItem = true;
                                                                    oldItem = newItem;
                                                                    newItem = nothing;
                                                                }
                                                                else
                                                                {
                                                                    PlayState.Player.PickUpItem = true;
                                                                    if (!oldItem.Equals(temp.ElementAt(0)))
                                                                    {
                                                                        PlayState.Player.PInv.Item.ElementAt(PlayState.Player.PInv.Item.Count() - 1).PlayerItem = true;
                                                                        oldItem = newItem;
                                                                        newItem = temp.ElementAt(0);
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }

                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    bool factorX = false, factorY = false;

                    for (int i = 0; i < 10; i++)
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
                        for (int j = 0; j < 14; j++)
                        {
                            switch (newItem.SpaceY)
                            {
                                case 0:
                                    factorY = mouseState.Y > j * 30 + (Game.Height / 2 - 230) && mouseState.Y < j * 30 + (Game.Height / 2 - 230) + 30;
                                    break;
                                case 1:
                                    factorY = mouseState.Y > j * 30 + (Game.Height / 2 - 230) + 15 && mouseState.Y < j * 30 + (Game.Height / 2 - 230) + 30 + 15;
                                    break;
                                case 2:
                                    factorY = mouseState.Y > j * 30 + (Game.Height / 2 - 230) + 30 && mouseState.Y < j * 30 + (Game.Height / 2 - 230) + 30 + 30;
                                    break;
                                case 3:
                                    factorY = mouseState.Y > j * 30 + (Game.Height / 2 - 230) + 45 && mouseState.Y < j * 30 + (Game.Height / 2 - 230) + 30 + 45;
                                    break;
                            }
                            if (factorX)
                            {
                                if (factorY)
                                {
                                    if (!newItem.Equals(Nothing))
                                    {
                                        if (newItem.PlayerItem && npc != null)
                                        {
                                            for (int z = 0; z < PlayState.Player.PInv.Item.Count(); z++)
                                            {
                                                if (i + newItem.SpaceX < 10)
                                                {
                                                    if (j + newItem.SpaceY < 14)
                                                    {
                                                        if (PlayState.Player.PInv.Item.ElementAt(z).Equals(newItem))
                                                        {
                                                            List<abstractItem> temp = new List<abstractItem>();

                                                            temp = CheckItem(PlayState.Player.PInv.Item.ElementAt(z), mouseState, newItem, npc);

                                                            if (temp.Count() < 2)
                                                            {
                                                                npc.GetInventory.Item.Add(PlayState.Player.PInv.Item.ElementAt(z));

                                                                PlayState.Player.PInv.Item.RemoveAt(z);

                                                                npc.GetInventory.Item.ElementAt(npc.GetInventory.Item.Count() - 1).PosX = i;
                                                                npc.GetInventory.Item.ElementAt(npc.GetInventory.Item.Count() - 1).PosY = j;

                                                                PlayState.Player.PickUpItem = false;

                                                                if (temp.ElementAt(0).Equals(nothing))
                                                                {
                                                                    npc.GetInventory.Item.ElementAt(npc.GetInventory.Item.Count() - 1).PlayerItem = false;
                                                                    oldItem = newItem;
                                                                    newItem = nothing;
                                                                }
                                                                else
                                                                {
                                                                    PlayState.Player.PickUpItem = true;
                                                                    if (!oldItem.Equals(temp.ElementAt(0)))
                                                                    {
                                                                        npc.GetInventory.Item.ElementAt(npc.GetInventory.Item.Count() - 1).PlayerItem = false;
                                                                        oldItem = newItem;
                                                                        newItem = temp.ElementAt(0);
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (npc != null)
                                            {
                                                for (int z = 0; z < npc.GetInventory.Item.Count(); z++)
                                                {
                                                    if (i + newItem.SpaceX < 10)
                                                    {
                                                        if (j + newItem.SpaceY < 14)
                                                        {
                                                            if (npc.GetInventory.Item.ElementAt(z).Equals(newItem))
                                                            {
                                                                List<abstractItem> temp = new List<abstractItem>();
                                                                temp = CheckItem(npc.GetInventory.Item.ElementAt(z), mouseState, newItem, npc);
                                                                if (temp.Count() < 2)
                                                                {
                                                                    npc.GetInventory.Item.ElementAt(z).PosX = i;
                                                                    npc.GetInventory.Item.ElementAt(z).PosY = j;

                                                                    PlayState.Player.PickUpItem = false;

                                                                    if (temp.ElementAt(0).Equals(nothing))
                                                                    {
                                                                        npc.GetInventory.Item.ElementAt(z).PlayerItem = false;
                                                                        oldItem = newItem;
                                                                        newItem = nothing;
                                                                    }
                                                                    else
                                                                    {
                                                                        PlayState.Player.PickUpItem = true;
                                                                        if (!oldItem.Equals(temp.ElementAt(0)))
                                                                        {
                                                                            npc.GetInventory.Item.ElementAt(z).PlayerItem = false;
                                                                            oldItem = newItem;
                                                                            newItem = temp.ElementAt(0);
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public List<abstractItem> CheckItem(abstractItem tempItem, MouseState mouseState, abstractItem newItem)
        {
            List<abstractItem> temp = new List<abstractItem>();
            for (int i = 0; i < PlayState.Player.PInv.Item.Count(); i++)
            {
                if (!tempItem.Equals(PlayState.Player.PInv.Item.ElementAt(i)))
                {
                    if (PlayState.Player.PInv.Item.ElementAt(i).PickupItem(mouseState, newItem) != null)
                    {
                        temp.Add(PlayState.Player.PInv.Item.ElementAt(i).PickupItem(mouseState, newItem));
                    }
                }
            }
            if (temp.Count() == 0)
            {
                temp.Add(nothing);
            }
            return temp;
        }
        public List<abstractItem> CheckItem(abstractItem tempItem, MouseState mouseState, abstractItem newItem, Merchant npc)
        {
            List<abstractItem> temp = new List<abstractItem>();
            for (int i = 0; i < npc.GetInventory.Item.Count(); i++)
            {
                if (!tempItem.Equals(npc.GetInventory.Item.ElementAt(i)))
                {
                    if (npc.GetInventory.Item.ElementAt(i).PickupItem(mouseState, newItem) != null)
                    {
                        temp.Add(npc.GetInventory.Item.ElementAt(i).PickupItem(mouseState, newItem));
                    }
                }
            }
            if (temp.Count() == 0)
            {
                temp.Add(nothing);
            }
            return temp;
        }
        public abstractItem Item { get { return newItem; } set { newItem = value; } }
        public abstractItem OldItem { get { return oldItem; } set { oldItem = value; } }
        public abstractItem Nothing { get { return nothing; } }
    }

}
