#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using ContentLoader;
#endregion

namespace NPC.Town
{
    public sealed class TestMerchant : Merchant
    {
        public TestMerchant(int x, int y)
            : base(x, y)
        {
            CharSprite = TheContentLoader.NPCSprite[1];
            Width = CharSprite.Width;
            Height = CharSprite.Height;
        }
        public override string[] ChatLines()
        {
            string[] temp = 
            {
                "Well, what can I do for ya?"
            };
            return temp;
        }
    }
}
