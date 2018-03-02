using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using CSFalpha1.Play.Inventory;
using CSFalpha1.Play.Item.Consumable.HealthPotion;
using CSFalpha1.Play.Item.Weapon.Polearm;
using CSFalpha1.Play.Item.Weapon.Sword;
using CSFalpha1.Play.Item.Weapon.Mace;

namespace CSFalpha1.Play.Level.NPC.Town.MerchantStuff
{
    public class MerchantInventory : abstractInventory
    {
        public MerchantInventory()
            : base()
        {
            I.Add(new Cheung(0, 0));
            I.Add(new Dagger(1, 0));
            I.Add(new ShortSword(4, 0));
            I.Add(new HonGim(5, 0));
            I.Add(new GuaanDou(6, 0));
            I.Add(new Dou(3, 1));
            I.Add(new Naginata(8, 0));
            I.Add(new HealthVial(0, 4));
            I.Add(new HealthBottle(1, 4));
            I.Add(new HealthFlask(2, 4));
            I.Add(new HealthGourd(3, 4));
            I.Add(new HealthPotion(4, 4));
            I.Add(new HealthJar(5, 4));
            I.Add(new HealthPot(5, 5));
            I.Add(new Scepter(1, 5));
            I.Add(new Flail(2, 5));
            I.Add(new Bin(4, 5));
        }
        public override void LoadContent()
        {
            base.LoadContent();
            inventorySprite = ContentLoader.InvSprite(1);
        }
        public override void ShowInventory(SpriteBatch sb, MouseState mouseState)
        {
            sb.Draw(inventorySprite, new Rectangle(0, (Game.Height - 480) / 2, 320, 440), new Color(200, 200, 200, 225));
            for (int i = 0; i < I.Count(); i++)
            {
                I.ElementAt(i).Show(sb);
            }
        }
        public override void CloseMenu(MouseState mouseState, Merchant npc)
        {
            if ((mouseState.X >= 280 && mouseState.X <= 280 + 30) || (mouseState.X >= (Game.Width - 320) + 10 && mouseState.X <= (Game.Width - 320) + 10 + 30))
            {
                if (mouseState.Y >= Game.Height / 2 + 165 && mouseState.Y <= Game.Height / 2 + 165 + 30)
                {
                    npc.IsTrading = false;
                    npc.MerchantMenu.IsTrading = false;
                    PlayState.Player.Inv = false;
                }
            }
        }
    }
}
