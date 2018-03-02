using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSFalpha1.Play.Level.NPC.Enemy.LevelU01
{
    public class Thief : WarriorEnemy
    {
        public Thief(int x, int y)
            : base(x, y)
        {
            playerSeen = true;
        }
        public override void LoadContent()
        {
            charSprite = null/*ContentLoader.CharSprite(0)*/;
        }
    }
}
