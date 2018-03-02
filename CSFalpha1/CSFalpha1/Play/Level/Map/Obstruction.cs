using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace CSFalpha1.Play.Level.Map
{
    public abstract class Obstruction
    {
        protected int x, y, width, height;
        protected bool leftFactorX, rightFactorX, upFactorY, downFactorY;
        protected bool collideUp, collideDown, collideLeft, collideRight;
        protected Texture2D objectSprite;
        public Obstruction() { Console.WriteLine("Do not use the default constructor!"); }
        public Obstruction(int x, int y)
        {
            this.x = x;
            this.y = y;
            collideUp = false;
            collideDown = false;
            collideLeft = false;
            collideRight = false;
        }
        public abstract void LoadContent();
        public abstract void Show(SpriteBatch sb);
        public virtual void Block()
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
                }
                else if (downFactorY)
                {
                    collideDown = true;
                }
            }
            else
            {
                collideUp = false;
                collideDown = false;
            }
            if (PlayState.Player.PosY - 16 <= y + height && PlayState.Player.PosY + 16 >= y)
            {
                if (leftFactorX)
                {
                    collideLeft = true;
                }
                else if (rightFactorX)
                {
                    collideRight = true;
                }
            }
            else
            {
                collideLeft = false;
                collideRight = false;
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
        public virtual bool GetCollide(int a)
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
                    Console.WriteLine("Error: Can only call Obstruction.GetCollide() with an argument: integer between 0-3.");
                    return false;
            }
        }
        public virtual void UnCollide(int a)
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
                    Console.WriteLine("Error: Can only call Obstruction.UnCollide() with an argument: integer between 0-3.");
                    break;
            }
        }
    }
}
