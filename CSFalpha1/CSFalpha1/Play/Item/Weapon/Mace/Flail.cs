using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSFalpha1.Play.Item.Weapon.Mace
{
    public class Flail : Mace
    {
        public Flail(int x, int y)
            : base(x, y)
        {
            spaceX = 2;
            spaceY = 3;
            minDmg = 3;
            maxDmg = 15;
            attackSpeed = 4;
        }
        public Flail(int x, int y, bool a)
            : base(x, y, a)
        {
            spaceX = 2;
            spaceY = 3;
            minDmg = 3;
            maxDmg = 15;
            attackSpeed = 4;
        }
        public override void LoadContent()
        {
            itemSprite = ContentLoader.ItemSprite(42);
        }
    }
}
