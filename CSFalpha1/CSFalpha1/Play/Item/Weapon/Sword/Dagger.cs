using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSFalpha1.Play.Item.Weapon.Sword
{
    public class Dagger : Sword
    {
        public Dagger(int x, int y)
            : base(x, y)
        {
            spaceX = 1;
            spaceY = 2;
            minDmg = 2;
            maxDmg = 5;
            attackSpeed = 3;
        }
        public Dagger(int x, int y, bool a)
            : base(x, y, a)
        {
            spaceX = 1;
            spaceY = 2;
            minDmg = 2;
            maxDmg = 5;
            attackSpeed = 3;
        }
        public override void LoadContent()
        {
            itemSprite = ContentLoader.ItemSprite(10);
        }
    }
}
