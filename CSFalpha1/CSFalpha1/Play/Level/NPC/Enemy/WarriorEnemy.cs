using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSFalpha1.Play.Level.NPC.Enemy
{
    public abstract class WarriorEnemy : abstractEnemy
    {
        protected byte frameOfAttack;
        public WarriorEnemy(int x, int y)
            : base(x, y)
        {
            playerSeen = true;
        }
        public override void Move()
        {
            if (playerSeen)
            {
                if (PlayState.Player.PosX - 16 >= x + width)
                {
                    x += speed;
                    xFacing = 1;
                }
                else if (PlayState.Player.PosX + 16 <= x)
                {
                    x -= speed;
                    xFacing = 2;
                }
                else if (PlayState.Player.PosY - 16 > y + height || PlayState.Player.PosY + 16 < y)
                {
                    xFacing = 0;
                }
                if (PlayState.Player.PosY - 16 >= y + height)
                {
                    y += speed;
                    yFacing = 1;
                }
                else if (PlayState.Player.PosY + 16 <= y)
                {
                    y -= speed;
                    yFacing = 2;
                }
                else
                {
                    yFacing = 0;
                }
            }
        }
        public override void Attack()
        {
            if (touchingPlayer)
            {
                Random r = new Random();

                int plyX = PlayState.Player.PosX;
                int plyY = PlayState.Player.PosY;

                if (attackFrame == frameOfAttack)
                {
                    PlayState.Player.Damage((int)(r.Next() * maxDmg) + minDmg);
                }
            }
        }
    }
}
