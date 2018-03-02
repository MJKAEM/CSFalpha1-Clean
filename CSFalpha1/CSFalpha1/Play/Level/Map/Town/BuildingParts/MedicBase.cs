using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace CSFalpha1.Play.Level.Map.Town.BuildingParts
{
    public class MedicBase : Base
    {
        public MedicBase(int x, int y) : base(x,y)
        {
            width = 428;
            height = 172;
        }
        public override void LoadContent()
        {
            objectSprite = ContentLoader.TextureSprite(2);
        }
        public override void Show(SpriteBatch sb)
        {
            sb.Draw(objectSprite,
                        new Rectangle(x - PlayState.Player.RenderPosX, y - PlayState.Player.RenderPosY, width, height),
                        new Rectangle(8, 230, width, height),
                       Color.White);
        }
    }
}
