using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace CSFalpha1.Play.Level.NPC.Town
{
    public sealed class TestNPC : TownNPC
    {
        public TestNPC(int x, int y) : base(x, y) { }
        public override void LoadContent()
        {
            charSprite = ContentLoader.CharSprite(1);
        }
        public override void ChatLines()
        {
            Chat("Hello World!");
        }
    }
}
