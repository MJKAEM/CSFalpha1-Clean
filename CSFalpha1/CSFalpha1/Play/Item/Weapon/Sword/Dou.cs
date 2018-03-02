using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSFalpha1.Play.Item.Weapon.Sword
{
    public class Dou : Sword
    {
        public Dou(int x, int y)
            : base(x, y)
        {
            spaceX = 1;
            spaceY = 3;
            minDmg = 5;
            maxDmg = 12;
            attackSpeed = 6;
        }
        public Dou(int x, int y, bool a)
            : base(x, y, a)
        {
            spaceX = 1;
            spaceY = 3;
            minDmg = 5;
            maxDmg = 12;
            attackSpeed = 6;
        }
        public override void LoadContent()
        {
            itemSprite = ContentLoader.ItemSprite(13);
        }
    }
}
