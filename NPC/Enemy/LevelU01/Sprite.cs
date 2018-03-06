#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using ContentLoader;
using VideoDisplay;
#endregion

namespace NPC.Enemy.LevelU01
{
    public class Sprite : RangeEnemy
    {
        public Sprite(int x, int y)
            : base(x, y)
        {
            MaxAnimationFrame = 1;
            CharSprite = TheContentLoader.NPCSprite[10];
        }
        public override void Show(SpriteBatch sb)
        {
            if (FrameTimer < 10*1)
            {
                FrameTimer++;
            }
            else
            {
                FrameTimer = 0;
                if (AnimationFrame < MaxAnimationFrame)
                {
                    AnimationFrame += 1;
                }
                else
                {
                    AnimationFrame = 0;
                }
            }
            if (AnimationFrame == 0)
            {
                sb.Draw(CharSprite,
                    new Rectangle(PosX - VideoVariables.RenderPosX, PosY - VideoVariables.RenderPosY, 32, 32),
                    new Rectangle(0, 0, 32, 32),
                    Color.White);
            }
            else
            {
                sb.Draw(CharSprite,
                    new Rectangle(PosX - VideoVariables.RenderPosX, PosY - VideoVariables.RenderPosY, 32, 32),
                    new Rectangle(32, 0, 32, 32),
                    Color.White);
            }
        }
        public override void ProjectileSpam()
        {
            
        }
    }
}
