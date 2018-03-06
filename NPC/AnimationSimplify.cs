using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace NPC
{
    public static class AnimationSimplify
    {
        public static void AttackAnimate(SpriteBatch sb, bool attackBool, Texture2D sprite, byte frame,
            int posX, int posY, int sizeX, int sizeY,
            int sourceFrameX, int sourceFrameY)
        {
            if (attackBool)
            {
                int slotX = frame, slotY = 0;

                if (slotX >= sourceFrameX)
                {
                    slotY++;
                    slotX = 0;
                }

                sb.Draw(sprite, new Rectangle(posX, posY, sizeX, sizeY), new Rectangle(0 + (sizeX * slotX), 0 + (sizeY * slotY), sizeX, sizeY), Color.White);
            }
        }
    }
}
