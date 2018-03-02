using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace CSFalpha1.Play.Level.NPC
{
    public abstract class abstractNPC
    {
        protected int x, y, width, height;
        protected bool leftFactorX, rightFactorX, upFactorY, downFactorY;
        protected bool collideUp, collideDown, collideLeft, collideRight;
        protected int speed;
        protected Texture2D charSprite;
        protected byte animationFrame, frameTimer, maxAnimationFrame;
        protected byte xFacing, yFacing;
        protected bool touchingPlayer;
        public abstractNPC(int x, int y)
        {
            this.x = x;
            this.y = y;
            animationFrame = 0;
            collideUp = false;
            collideDown = false;
            collideLeft = false;
            collideRight = false;
            touchingPlayer = false;
            speed = 0;
            width = 0;
            height = 0;
        }
        public void Block()
        {
            leftFactorX = (PlayState.Player.PosX - 16 >= x + width - 2 && PlayState.Player.PosX - 16 <= x + width);
            rightFactorX = (PlayState.Player.PosX + 16 >= x && PlayState.Player.PosX + 16 <= x + 2);
            upFactorY = (PlayState.Player.PosY - 16 >= y + height - 2 && PlayState.Player.PosY - 16 <= y + height);
            downFactorY = (PlayState.Player.PosY + 16 >= y && PlayState.Player.PosY + 16 <= y + 2);
            if (PlayState.Player.PosX - 16 <= x + width && PlayState.Player.PosX + 16 >= x)
            {
                if (upFactorY)
                {
                    collideUp = true;
                    touchingPlayer = true;
                }
                else if (downFactorY)
                {
                    collideDown = true;
                    touchingPlayer = true;
                }
            }
            else
            {
                collideUp = false;
                collideDown = false;
                touchingPlayer = false;
            }
            if (PlayState.Player.PosY - 16 <= y + height && PlayState.Player.PosY + 16 >= y)
            {
                if (leftFactorX)
                {
                    collideLeft = true;
                    touchingPlayer = true;
                }
                else if (rightFactorX)
                {
                    collideRight = true;
                    touchingPlayer = true;
                }
            }
            else
            {
                collideLeft = false;
                collideRight = false;
                touchingPlayer = false;
            }
            if (collideUp == collideLeft && collideUp == true)
            {
                collideUp = false;
                collideLeft = false;
            }
            if (collideUp == collideRight && collideUp == true)
            {
                collideUp = false;
                collideRight = false;
            }
            if (collideDown == collideLeft && collideDown == true)
            {
                collideDown = false;
                collideLeft = false;
            }
            if (collideDown == collideRight && collideDown == true)
            {
                collideDown = false;
                collideRight = false;
            }
        }

        public bool GetCollide(int a)
        {
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
                default:
                    Console.WriteLine("Error: Can only call NPC.GetCollide() with an argument: integer between 0-3.");
                    return false;
            }
        }
        public void UnCollide(int a)
        {
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
                default:
                    Console.WriteLine("Error: Can only call NPC.UnCollide() with an argument: integer between 0-3.");
                    break;
            }
        }
        public virtual void Move() { }
        public abstract void LoadContent();
        public virtual void Show(SpriteBatch sb)
        {
            sb.Draw(charSprite, new Rectangle(x - PlayState.Player.RenderPosX, y - PlayState.Player.RenderPosY, 32, 32), Color.White);
        }
        public int PosX { get { return x; } }
        public int PosY { get { return y; } }
    }
}
