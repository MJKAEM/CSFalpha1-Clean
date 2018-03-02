using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSFalpha1.Play.Item.Weapon.Polearm
{
    public abstract class Polearm : Weapon
    {
        public Polearm(int x, int y)
            : base(x, y)
        {
            spaceX = 2;
            spaceY = 4;
            minDmg = 1;
            maxDmg = 35;
            attackSpeed = 7;
        }
        public Polearm(int x, int y, bool a)
            : base(x, y, a)
        {
            spaceX = 2;
            spaceY = 4;
            minDmg = 1;
            maxDmg = 35;
            attackSpeed = 7;
        }
    }
}
