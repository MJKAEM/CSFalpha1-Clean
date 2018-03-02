using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSFalpha1.Play.Item.Weapon.Polearm
{
    public class GuaanDou : Polearm
    {
        public GuaanDou(int x, int y)
            : base(x, y)
        {
            spaceX = 2;
            spaceY = 4;
            minDmg = 20;
            maxDmg = 32;
            attackSpeed = 8;
        }
        public GuaanDou(int x, int y, bool a)
            : base(x, y, a)
        {
            spaceX = 2;
            spaceY = 4;
            minDmg = 20;
            maxDmg = 32;
            attackSpeed = 8;
        }
        public override void LoadContent()
        {
            itemSprite = ContentLoader.ItemSprite(32);
        }
    }
}
