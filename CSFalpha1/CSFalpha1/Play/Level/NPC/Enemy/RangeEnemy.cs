using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSFalpha1.Play.Level.NPC.Enemy
{
    public abstract class RangeEnemy : abstractEnemy
    {
        public RangeEnemy(int x, int y)
            : base(x, y)
        {
            playerSeen = true;
        }
        public override void Attack()
        {
            
        }
    }
}
