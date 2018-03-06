#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using NPC;
using NPC.Town;
using CSFalpha1.Play.Level.Map.Town;
using CSFalpha1.Play.Level.Map;
using VideoDisplay;
using ContentLoader;
#endregion

namespace CSFalpha1.Play.Level
{
    public sealed class Town : AbstractLevel
    {
        private Texture2D Dirt;
        private Merchant[] npc = new Merchant[5];

        public Town()
            : base()
        {
            SizeX = VideoVariables.ResolutionWidth;
            SizeY = VideoVariables.ResolutionHeight;
            //npc.Add(new TestNPC(20, 20));
            npc[0] = new TestMerchant(80, 80);
            npc[1] = new TestMerchant(-80, 80);
            npc[2] = new TestMerchant(-80, -80);
            npc[3] = new TestMerchant(80, -80);
            npc[4] = new TestMerchant(-20, 140);
            //npc.Add(new NPC.Enemy.LevelU01.Knight(50, 50));
            //structure.Add(new Building(100, 100));
            //structure.Add(new MedicBuilding(500, 100));

            Floor = TheContentLoader.TextureSprite[0];
            Dirt = TheContentLoader.TextureSprite[1];
            for (int i = structure.Count - 1; i >= 0; i--)
            {
                structure.ElementAt(i).LoadContent();
            }
        }
        public override void ALayer1(SpriteBatch sb)
        {
            for (int i = npc.Length - 1; i >= 0; i--)
            {
                if (npc[i].PosY > PlayState.Player.PosY)
                {
                    npc[i].Show(sb);
                }
            }
            /*if (npc[0].PosY > PlayState.Player.PosY)
            {
                npc[0].Show(sb);
            }
            npc[1].Show(sb);
            npc[2].Show(sb);
            npc[3].Show(sb);
            npc[4].Show(sb);*/
        }
        public override void ALayer2(SpriteBatch sb)
        {
            for (int i = structure.Count - 1; i >= 0; i--)
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
            /*for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    if (j % 6 == 0 && i % 6 == 0)
                    {
                        sb.Draw(Floor, new Rectangle(30 - VideoVariables.RenderPosX + (64 * i), 30 - VideoVariables.RenderPosY + (64 * j), 64, 64), Color.White);
                    }
                    else
                    {
                        sb.Draw(Dirt, new Rectangle(30 - VideoVariables.RenderPosX + (64 * i), 30 - VideoVariables.RenderPosY + (64 * j), 64, 64), Color.White);
                    }
                }
            }*/
            sb.Draw(Floor, new Rectangle(30 - VideoVariables.RenderPosX, 30 - VideoVariables.RenderPosY, Floor.Width, Floor.Height), Color.White);
        }
        public override void Layer2(SpriteBatch sb)
        {

        }
        public override void Layer3(SpriteBatch sb)
        {
        }
        public override void Layer4(SpriteBatch sb)
        {
            for (int i = npc.Length - 1; i >= 0; i--)
            {
                if (npc[i].PosY <= PlayState.Player.PosY)
                {
                    npc[i].Show(sb);
                }
            }
        }
        public void Chat()
        {
            for (int i = npc.Length - 1; i >= 0; i--)
            {
                npc[i].ChatLines();
            }
        }
        public void Merchant(SpriteBatch sb, MouseState mouseState)
        {
            npc[0].ShowMenu(sb);
            npc[1].ShowMenu(sb);
            npc[2].ShowMenu(sb);
            npc[3].ShowMenu(sb);
            npc[4].ShowMenu(sb);
            npc[0].ShowInventory(sb);
            npc[1].ShowInventory(sb);
            npc[2].ShowInventory(sb);
            npc[3].ShowInventory(sb);
            npc[4].ShowInventory(sb);
        }
        public void MerchantSelectMenu(MouseState mouseState, MouseState oldState)
        {
            Merchant temp = GetIsChattingMerchant();
            if (temp != null)
            {
                temp.SelectMenu(mouseState, oldState);
            }
            else if(GetIsTradingMerchant() == null)
            {
                npc[0].SelectMerchant(mouseState, oldState);
                npc[1].SelectMerchant(mouseState, oldState);
                npc[2].SelectMerchant(mouseState, oldState);
                npc[3].SelectMerchant(mouseState, oldState);
                npc[4].SelectMerchant(mouseState, oldState);
            }
        }
        public void Move()
        {
            npc[0].Move();
            npc[1].Move();
            npc[2].Move();
            npc[3].Move();
            npc[4].Move();
        }
        /// <summary>
        /// Returns the merchant that is chatting with the player.
        /// If there is no one chatting, it will return null.
        /// </summary>
        /// <returns>The chatting Merchant.</returns>
        public Merchant GetIsChattingMerchant()
        {
            for (int i = npc.Length - 1; i >= 0; i--)
            {
                if (npc[i].IsChatting)
                {
                    return npc[i];
                }
            }
            return null;
        }

        /// <summary>
        /// Returns the merchant that is trading with the player.
        /// If there is no one trading, it will return null.
        /// </summary>
        /// <returns>The trading Merchant.</returns>
        public Merchant GetIsTradingMerchant()
        {
            for (int i = npc.Length - 1; i >= 0; i--)
            {
                if (npc[i].IsTrading)
                {
                    return npc[i];
                }
            }
            return null;
        }
        public Merchant[] GetNPC { get { return npc; } set { npc = value; } }
    }
}
