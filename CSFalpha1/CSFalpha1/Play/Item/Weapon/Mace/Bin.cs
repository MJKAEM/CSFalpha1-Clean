using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSFalpha1.Play.Item.Weapon.Mace
{
    public class Bin : Mace
    {
        public Bin(int x, int y)
            : base(x, y)
        {
            spaceX = 1;
            spaceY = 3;
            minDmg = 6;
            maxDmg = 12;
            attackSpeed = 6;
        }
        public Bin(int x, int y, bool a)
            : base(x, y, a)
        {
            spaceX = 1;
            spaceY = 3;
            minDmg = 6;
            maxDmg = 12;
            attackSpeed = 6;
        }
        public override void LoadContent()
        {
            itemSprite = ContentLoader.ItemSprite(41);
        }
    }
}
