#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion

namespace NPC.Enemy
{
    public abstract class WarriorEnemy : AbstractEnemy
    {
        private byte frameOfAttack;

        protected WarriorEnemy(int x, int y)
            : base(x, y)
        {
            PlayerSeen = true;
        }
        public override void Move()
        {
            if (PlayerSeen)
            {
                /*if (PlayState.Player.PosX - 16 >= PosX + Width)
                {
                    PosX += Speed;
                    XFacing = 1;
                }
                else if (PlayState.Player.PosX + 16 <= PosX)
                {
                    PosX -= Speed;
                    XFacing = 2;
                }
                else if (PlayState.Player.PosY - 16 > PosY + Height || PlayState.Player.PosY + 16 < PosY)
                {
                    XFacing = 0;
                }
                if (PlayState.Player.PosY - 16 >= PosY + Height)
                {
                    PosY += Speed;
                    YFacing = 1;
                }
                else if (PlayState.Player.PosY + 16 <= PosY)
                {
                    PosY -= Speed;
                    YFacing = 2;
                }
                else
                {
                    YFacing = 0;
                }*/
            }
        }
        public override void Attack()
        {
            if (TouchingPlayer)
            {
                Random r = new Random();

                if (AttackFrame == frameOfAttack)
                {
                    
                }
            }
        }
    }
}
