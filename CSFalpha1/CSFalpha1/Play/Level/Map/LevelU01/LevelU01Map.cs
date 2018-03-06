#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NPC.Enemy.LevelU01;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using ContentLoader;
#endregion

namespace CSFalpha1.Play.Level.Map.LevelU01
{
    public class LevelU01Map : DungeonLevel
    {
        public LevelU01Map()
            : base()
        {
            Floor = TheContentLoader.TextureSprite[0];
            GetNPC.Add(new Knight(40, 40));
        }
        public override void Layer1(SpriteBatch sb)
        {
            //sb.Draw(Floor, new Vector2(0, 0), Color.White);
        }
        public override void Layer2(SpriteBatch sb)
        {
            for (int i = GetNPC.Count - 1; i >= 0; i--)
            {
                GetNPC.ElementAt(i).Show(sb);
            }
        }
    }
}
