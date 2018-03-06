using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NPC.Enemy
{
    public abstract class AbstractEnemy : AbstractNPC
    {
        private bool playerSeen;
        private int minDmg, maxDmg;
        private byte attackFrame, attackTimer, maxAttackFrame, timeBeforeNextAttack;
        protected AbstractEnemy(int x, int y)
            : base(x, y)
        {
            playerSeen = false;
            attackFrame = 0;
        }
        public abstract void Attack();
        public bool PlayerSeen { get { return playerSeen; } set { playerSeen = value; } }
        public int MinDmg { get { return minDmg; } set { minDmg = value; } }
        public int MaxDmg { get { return maxDmg; } set { maxDmg = value; } }
        public byte AttackFrame { get { return attackFrame; } set { attackFrame = value; } }
        public byte AttackTimer { get { return attackTimer; } set { attackTimer = value; } }
        public byte MaxAttackFrame { get { return maxAttackFrame; } set { maxAttackFrame = value; } }
        public byte TimeBeforeNextAttack { get { return timeBeforeNextAttack; } set { timeBeforeNextAttack = value; } }
    }
}
