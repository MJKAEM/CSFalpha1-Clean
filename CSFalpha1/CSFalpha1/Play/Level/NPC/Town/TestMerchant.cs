using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace CSFalpha1.Play.Level.NPC.Town
{
    public sealed class TestMerchant : Merchant
    {
        public TestMerchant(int x, int y)
            : base(x, y)
        {
        }
        public override void LoadContent()
        {
            base.LoadContent();
            
            charSprite = ContentLoader.CharSprite(2);
        }
        public override void ChatLines()
        {
            Chat("Well, what can I do for you?");
        }
    }
}
