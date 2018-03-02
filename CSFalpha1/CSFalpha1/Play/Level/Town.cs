using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using CSFalpha1.Play.Level.NPC;
using CSFalpha1.Play.Level.NPC.Town;
using CSFalpha1.Play.Level.Map.Town;
using CSFalpha1.Play.Level.Map;

namespace CSFalpha1.Play.Level
{
    public sealed class Town : abstractLevel
    {
        public Town()
            : base()
        {
            sizeX = Game.Width;
            sizeY = Game.Height;
            npc.Add(new TestNPC(20, 20));
            npc.Add(new TestMerchant(-20, 70));
            npc.Add(new CSFalpha1.Play.Level.NPC.Enemy.LevelU01.Knight(50,50));
            structure.Add(new Building(100, 100));
            structure.Add(new MedicBuilding(500, 100));
        }
        public override void LoadContent()
        {
            Floor = ContentLoader.TextureSprite(0);
            for (int i = 0; i < npc.Count(); i++)
            {
                npc.ElementAt(i).LoadContent();
            }
            for (int i = 0; i < structure.Count(); i++)
            {
                structure.ElementAt(i).LoadContent();
            }
        }
        public override void ALayer1(SpriteBatch sb)
        {
            ((Merchant)npc.ElementAt(1)).ShowMenu(sb);
        }
        public override void ALayer2(SpriteBatch sb)
        {
            for (int i = 0; i < structure.Count(); i++)
            {
                structure.ElementAt(i).Show(sb);
            }
        }
        public override void ALayer3(SpriteBatch sb)
        {
        }
        public override void ALayer4(SpriteBatch sb)
        {
        }
        public override void Layer1(SpriteBatch sb)
        {
            for (int i = 0; i < 32; i++)
            {
                for (int j = 0; j < 32; j++)
                {
                    if (j % 2 == 0 && i % 2 == 0)
                    {
                        sb.Draw(Floor, new Rectangle(30 - PlayState.Player.RenderPosX + (32 * i), 30 - PlayState.Player.RenderPosY + (32 * j), 32, 32), new Rectangle(0, 32, 32, 32), Color.White);
                    }
                    else
                    {
                        sb.Draw(Floor, new Rectangle(30 - PlayState.Player.RenderPosX + (32 * i), 30 - PlayState.Player.RenderPosY + (32 * j), 32, 32), new Rectangle(0, 32, 32, 32), Color.White);
                    }
                }
            }
        }
        public override void Layer2(SpriteBatch sb)
        {

        }
        public override void Layer3(SpriteBatch sb)
        {
        }
        public override void Layer4(SpriteBatch sb)
        {
            for (int i = 0; i < npc.Count(); i++)
            {
                npc.ElementAt(i).Show(sb);
            }
        }
        public void Chat()
        {
            for (int i = 0; i < npc.Count(); i++)
            {
                ((TownNPC)npc.ElementAt(i)).ChatLines();
            }
        }
        public void Merchant(SpriteBatch sb, MouseState mouseState)
        {
            ((Merchant)npc.ElementAt(1)).Inventory(sb, mouseState);
        }
        public void MerchantSelectMenu(MouseState mouseState, MouseState oldState)
        {
            ((Merchant)npc.ElementAt(1)).Function(mouseState, oldState);
        }
    }
}
