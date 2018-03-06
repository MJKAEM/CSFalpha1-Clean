#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Item.Consumable.HealthPotion;
using Item.Weapon.Polearm;
using Item.Weapon.OneHSword;
using Item.Weapon.Mace;
using Microsoft.Xna.Framework.Graphics;
using VideoDisplay;
using ContentLoader;
#endregion

namespace Inventory
{
    public class MerchantInventory : AbstractInventory
    {
        public MerchantInventory()
        {
            Item.Add(new Cheong(0, 0));
            Item.Add(new Scimitar(1, 0));
            Item.Add(new ShortSword(4, 0));
            Item.Add(new HonGim(5, 0));
            Item.Add(new GwaanDou(6, 0));
            Item.Add(new Dou(3, 1));
            Item.Add(new Naginata(8, 0));
            Item.Add(new HealthVial(0, 4));
            Item.Add(new HealthBottle(1, 4));
            Item.Add(new HealthFlask(2, 4));
            Item.Add(new HealthGourd(3, 4));
            Item.Add(new HealthPotion(4, 4));
            Item.Add(new HealthJar(5, 4));
            Item.Add(new HealthPot(5, 5));
            Item.Add(new Scepter(1, 5));
            Item.Add(new Flail(2, 5));
            Item.Add(new Bin(4, 5));

            InventorySprite = TheContentLoader.UITexture[1];
        }
        public override void ShowInventory(SpriteBatch sb)
        {
            sb.Draw(InventorySprite, new Rectangle(0, (VideoVariables.ResolutionHeight - 480) / 2, 320, 440), new Color(200, 200, 200, 225));
            for (int i = Item.Count - 1; i >= 0; i--)
            {
                Item.ElementAt(i).ElseShow(sb);
            }
        }
        public override void CloseMenu(MouseState mouseState)
        {
            if ((mouseState.X >= 280 && mouseState.X <= 280 + 30) || (mouseState.X >= (VideoVariables.ResolutionWidth - 320) + 10 && mouseState.X <= (VideoVariables.ResolutionWidth - 320) + 10 + 30))
            {
                if (mouseState.Y >= VideoVariables.ResolutionHeight / 2 + 165 && mouseState.Y <= VideoVariables.ResolutionHeight / 2 + 165 + 30)
                {
                    InventoryOpen = false;
                }
            }
        }
    }
}
