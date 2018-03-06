using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using VideoDisplay;
using ContentLoader;

namespace CSFalpha1.Play.Level.Map.Town.BuildingParts
{
    public class Base : AbstractObstruction
    {
        public Base(int x, int y)
            : base(x, y)
        {
            width = 357;
            height = 90;
        }
        public override void LoadContent()
        {
            objectSprite = TheContentLoader.TextureSprite[1];
        }
        public override void Show(SpriteBatch sb)
        {
            sb.Draw(objectSprite,
                        new Rectangle(x - VideoVariables.RenderPosX, y - VideoVariables.RenderPosY, width, height),
                        new Rectangle(38, 135, width, height),
                       Color.White);
        }
    }
}
