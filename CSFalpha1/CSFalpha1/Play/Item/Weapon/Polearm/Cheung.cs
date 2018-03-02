using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSFalpha1.Play.Item.Weapon.Polearm
{
    public class Cheung : Polearm
    {
        public Cheung(int x, int y)
            : base(x, y)
        {
            spaceX = 1;
            spaceY = 4;
            minDmg = 20;
            maxDmg = 25;
            attackSpeed = 7;
        }
        public Cheung(int x, int y, bool a)
            : base(x, y, a)
        {
            spaceX = 1;
            spaceY = 4;
            minDmg = 20;
            maxDmg = 25;
            attackSpeed = 7;
        }
        public override void LoadContent()
        {
            itemSprite = ContentLoader.ItemSprite(30);
        }
    }
}
