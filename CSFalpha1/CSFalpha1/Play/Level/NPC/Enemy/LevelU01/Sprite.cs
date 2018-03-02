using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace CSFalpha1.Play.Level.NPC.Enemy.LevelU01
{
    public class Sprite : RangeEnemy
    {
        public Sprite(int x, int y)
            : base(x, y)
        {
            maxAnimationFrame = 1;
        }
        public override void LoadContent()
        {
            charSprite = ContentLoader.CharSprite(10);
        }
        public override void Show(SpriteBatch sb)
        {
            if (frameTimer < 10*1)
            {
                frameTimer++;
            }
            else
            {
                frameTimer = 0;
                if (animationFrame < maxAnimationFrame)
                {
                    animationFrame += 1;
                }
                else
                {
                    animationFrame = 0;
                }
            }
            if (animationFrame == 0)
            {
                sb.Draw(charSprite,
                    new Rectangle(x - PlayState.Player.RenderPosX, y - PlayState.Player.RenderPosY, 32, 32),
                    new Rectangle(0, 0, 32, 32),
                    Color.White);
            }
            else
            {
                sb.Draw(charSprite,
                    new Rectangle(x - PlayState.Player.RenderPosX, y - PlayState.Player.RenderPosY, 32, 32),
                    new Rectangle(32, 0, 32, 32),
                    Color.White);
            }
        }
    }
}
