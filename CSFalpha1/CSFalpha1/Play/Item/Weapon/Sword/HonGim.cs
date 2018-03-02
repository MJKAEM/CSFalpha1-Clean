using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSFalpha1.Play.Item.Weapon.Sword
{
    public class HonGim : Sword
    {
        public HonGim(int x, int y)
            : base(x, y)
        {
            spaceX = 1;
            spaceY = 3;
            minDmg = 8;
            maxDmg = 10;
            attackSpeed = 5;
        }
        public HonGim(int x, int y, bool a)
            : base(x, y, a)
        {
            spaceX = 1;
            spaceY = 3;
            minDmg = 12;
            maxDmg = 15;
            attackSpeed = 5;
        }
        public override void LoadContent()
        {
            itemSprite = ContentLoader.ItemSprite(12);
        }
    }
}
