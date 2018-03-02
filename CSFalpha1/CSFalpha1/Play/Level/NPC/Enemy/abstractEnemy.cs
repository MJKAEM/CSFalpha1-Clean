using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSFalpha1.Play.Level.NPC.Enemy
{
    public abstract class abstractEnemy : abstractNPC
    {
        protected bool playerSeen;
        protected int minDmg, maxDmg;
        protected byte attackFrame, attackTimer, maxAttackFrame, timeBeforeNextAttack;
        public abstractEnemy(int x, int y)
            : base(x, y)
        {
            playerSeen = false;
            attackFrame = 0;
        }
        public abstract void Attack();
    }
}
