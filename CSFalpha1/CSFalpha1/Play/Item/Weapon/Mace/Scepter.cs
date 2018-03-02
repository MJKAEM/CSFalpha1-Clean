using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSFalpha1.Play.Item.Weapon.Mace
{
    public class Scepter : Mace
    {
        public Scepter(int x, int y)
            : base(x, y)
        {
            spaceX = 1;
            spaceY = 3;
            minDmg = 5;
            maxDmg = 8;
            attackSpeed = 4;
        }
        public Scepter(int x, int y, bool a)
            : base(x, y, a)
        {
            spaceX = 1;
            spaceY = 3;
            minDmg = 5;
            maxDmg = 8;
            attackSpeed = 4;
        }
        public override void LoadContent()
        {
            itemSprite = ContentLoader.ItemSprite(40);
        }
    }
}
