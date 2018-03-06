#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using VideoDisplay;
using ContentLoader;
#endregion

namespace CSFalpha1.Play.Level.Map.Town.BuildingParts
{
    public class Roof
    {
        protected int x, y, width, height;
        protected Texture2D objectSprite;
        public Roof(int x, int y)
        {
            this.x = x;
            this.y = y;
            width = 432;
            height = 141;
        }
        public virtual void LoadContent()
        {
            objectSprite = TheContentLoader.TextureSprite[1];
        }
        public void Show(SpriteBatch sb)
        {
            sb.Draw(objectSprite,
                        new Rectangle(x - VideoVariables.RenderPosX, y - VideoVariables.RenderPosY, width, height),
                        new Rectangle(0, 0, width, height),
                       Color.White);
        }
    }
}
