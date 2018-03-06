using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NPC.Enemy
{
    public abstract class RangeEnemy : WarriorEnemy
    {
        private int radius;
        protected double hypo;

        protected RangeEnemy(int x, int y)
            : base(x, y)
        {
            PlayerSeen = true;
            radius = 0;
        }
        protected RangeEnemy(int x, int y, int radius)
            : base(x, y)
        {
            this.radius = radius;
        }
        public override void Attack()
        {
            /*
            hypo = Math.Sqrt((PlayState.Player.PosX - PosX) ^ 2 + (PlayState.Player.PosY - PosY) ^ 2);
            
            if (hypo <= radius)
            {
                ProjectileSpam();
            }
             //*/
        }
        public override void Move()
        {
            if (hypo < radius)
            {
                if (PlayerSeen)
                {
                    /*
                    if (PlayState.Player.PosX - 16 >= PosX + Width)
                    {
                        PosX -= Speed;
                        XFacing = 1;
                    }
                    else if (PlayState.Player.PosX + 16 <= PosX)
                    {
                        PosX += Speed;
                        XFacing = 2;
                    }
                    else if (PlayState.Player.PosY - 16 > PosY + Height || PlayState.Player.PosY + 16 < PosY)
                    {
                        XFacing = 0;
                    }
                    if (PlayState.Player.PosY - 16 >= PosY + Height)
                    {
                        PosY -= Speed;
                        YFacing = 1;
                    }
                    else if (PlayState.Player.PosY + 16 <= PosY)
                    {
                        PosY += Speed;
                        YFacing = 2;
                    }
                    else
                    {
                        YFacing = 0;
                    }
                    //*/
                }
            }
            else
            {
                base.Move();
            }
        }
        public abstract void ProjectileSpam();
        public int Radius { get { return radius; } set { radius = value; } }
    }
}
