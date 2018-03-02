using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSFalpha1.Play.Item.Weapon
{
    public abstract class Weapon : abstractItem
    {
        protected int minDmg, maxDmg;
        protected int attackSpeed;

        public Weapon(int x, int y)
            : base(x, y)
        {
            attackSpeed = 10; //attackSpeed goes from 0-10.  10 is the slowest and 0 is the fastest.
            minDmg = 0;
            maxDmg = 0;
        }
        public Weapon(int x, int y, bool a)
            : base(x, y, a)
        {
            attackSpeed = 10; //attackSpeed goes from 0-10.  10 is the slowest and 0 is the fastest.
            minDmg = 0;
            maxDmg = 0;
        }
        public void Attack()
        {

        }
    }
}
