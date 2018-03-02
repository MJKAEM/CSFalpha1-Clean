using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using CSFalpha1.Play.Level.NPC.Town;
using CSFalpha1.Play.Item.Consumable.HealthPotion;
using CSFalpha1.Play.Item.Weapon.Polearm;
using CSFalpha1.Play.Item.Weapon.Sword;
using CSFalpha1.Play.Inventory;

namespace CSFalpha1.Play.Player
{
    public sealed class PlayerInventory : abstractInventory
    {        
        private MouseStorage mouseStorage;

        public PlayerInventory()
            : base()
        {
            I.Add(new Cheung(0, 0, true));
            I.Add(new Dagger(1, 0, true));
            I.Add(new ShortSword(4, 0, true));
            I.Add(new HonGim(5, 0, true));
            I.Add(new GuaanDou(6, 0, true));
            I.Add(new Dou(3, 1, true));
            I.Add(new Naginata(8, 0, true));
            I.Add(new HealthVial(0, 4, true));
            I.Add(new HealthBottle(1, 4, true));
            I.Add(new HealthFlask(2, 4, true));
            I.Add(new HealthGourd(3, 4, true));
            I.Add(new HealthPotion(4, 4, true));
            I.Add(new HealthJar(5, 4, true));
            mouseStorage = new MouseStorage();
        }
        public override void LoadContent()
        {
            base.LoadContent();
            inventorySprite = ContentLoader.InvSprite(0);
            MouseStorage.Nothing.LoadContent();
        }
        public override void ShowInventory(SpriteBatch sb, MouseState mouseState)
        {
            sb.Draw(inventorySprite, new Rectangle(Game.Width - 320, (Game.Height - 480) / 2 , 320, 440), new Color(200, 200, 200, 225));
            for (int i = 0; i < I.Count(); i++)
            {
                I.ElementAt(i).Show(sb);
            }
            mouseStorage.Show(sb, mouseState);
        }
        public override void CloseMenu(MouseState mouseState, Merchant npc)
        {
            if (mouseState.X >= (Game.Width - 320) + 10 && mouseState.X <= (Game.Width - 320) + 10 + 30)
            {
                if (mouseState.Y >= Game.Height / 2 + 165 && mouseState.Y <= Game.Height / 2 + 165 + 30)
                {
                    PlayState.Player.Inv = false;
                }
            }
        }
        public MouseStorage MouseStorage { get { return mouseStorage; } set { mouseStorage = value; } }
        
    }
}
