using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSFalpha1.Play.Item.Weapon.Mace
{
    public class Mace : Weapon
    {
        public Mace(int x, int y)
            : base(x, y)
        {
            spaceX = 1;
            spaceY = 3;
            minDmg = 7;
            maxDmg = 10;
            attackSpeed = 5;
        }
        public Mace(int x, int y, bool a)
            : base(x, y, a)
        {
            spaceX = 1;
            spaceY = 3;
            minDmg = 7;
            maxDmg = 10;
            attackSpeed = 5;
        }
        public override void LoadContent()
        {
            itemSprite = ContentLoader.ItemSprite(11);
        }
    }

}
