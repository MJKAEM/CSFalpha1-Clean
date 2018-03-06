#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using ContentLoader;
#endregion

namespace NPC.Town
{
    public sealed class TestNPC : TownNPC
    {
        public TestNPC(int x, int y) : base(x, y) { CharSprite = TheContentLoader.NPCSprite[1]; }
        public override string[] ChatLines()
        {
            string[] temp = 
            {
                "Hello World!"
            };

            return temp;
        }
    }
}
