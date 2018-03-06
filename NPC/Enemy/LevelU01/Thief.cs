using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NPC.Enemy.LevelU01
{
    public class Thief : WarriorEnemy
    {
        public Thief(int x, int y)
            : base(x, y)
        {
            PlayerSeen = true;
        }
    }
}
