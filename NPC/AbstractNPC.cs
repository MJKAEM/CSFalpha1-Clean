#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Diagnostics.Contracts;
using ContentLoader;
using VideoDisplay;
#endregion

namespace NPC
{
    public abstract class AbstractNPC
    {
        private int x, y, width, height;
        private bool collideUp, collideDown, collideLeft, collideRight;
        private byte speed;
        private Texture2D charSprite;
        private byte animationFrame, frameTimer, maxAnimationFrame;
        private byte xFacing, yFacing;
        private bool touchingPlayer;
        protected AbstractNPC(int x, int y)
        {
            this.x = x;
            this.y = y;
            animationFrame = 0;
            speed = 0;
            width = 0;
            height = 0;
        }
        public bool GetCollide(int a)
        {
            Contract.Requires(a >= 0 && a <= 3, "Error: Can only call NPC.GetCollide() with an argument: integer between 0-3.");
            switch (a)
            {
                case 0:
                    return collideUp;
                case 1:
                    return collideDown;
                case 2:
                    return collideLeft;
                case 3:
                    return collideRight;
            }
            //Unreachable code lol.
            return false;
        }
        public void UnCollide(int a)
        {
            Contract.Requires(a >= 0 && a <= 3, "Error: Can only call NPC.UnCollide() with an argument: integer between 0-3.");
            switch (a)
            {
                case 0:
                    collideUp = false;
                    break;
                case 1:
                    collideDown = false;
                    break;
                case 2:
                    collideLeft = false;
                    break;
                case 3:
                    collideRight = false;
                    break;
            }
        }
        public virtual void Move() { }
        public virtual void Show(SpriteBatch sb)
        {
            try
            {
                sb.Draw(charSprite,
                    new Rectangle(x - VideoVariables.RenderPosX - width / 2, y - VideoVariables.RenderPosY - height / 2, 32, 32), 
                    Color.White);
            }
            catch (ArgumentNullException)
            {
                charSprite = TheContentLoader.BackUp;
            }
        }
        #region Properties
        public int PosX { get { return x; } set { x = value; } }
        public int PosY { get { return y; } set { y = value; } }
        public int Width { get { return width; } set { width = value; } }
        public int Height { get { return height; } set { height = value; } }
        public Texture2D CharSprite { get { return charSprite; } set { charSprite = value; } }
        public byte AnimationFrame { get { return animationFrame; } set { animationFrame = value; } }
        public byte FrameTimer { get { return frameTimer; } set { frameTimer = value; } }
        public byte MaxAnimationFrame { get { return maxAnimationFrame; } set { maxAnimationFrame = value; } }
        public byte Speed { get { return speed; } set { speed = value; } }
        public byte XFacing { get { return xFacing; } set { xFacing = value; } }
        public byte YFacing { get { return yFacing; } set { yFacing = value; } }
        public bool TouchingPlayer { get { return touchingPlayer; } set { touchingPlayer = value; } }
        #endregion
    }
}
