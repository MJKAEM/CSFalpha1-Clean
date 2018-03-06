#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
#endregion

namespace NPC.Enemy
{
    public abstract class AbstractMissile
    {
        private int posX, posY;
        private Texture2D sprite;

        protected AbstractMissile(int x, int y)
        {
            posX = x;
            posY = y;
        }
        public abstract void Show();
        public int PosX { get { return posX; } set { posX = value; } }
        public int PosY { get { return posY; } set { posY = value; } }
        public Texture2D Sprite { get { return sprite; } set { sprite = value; } }
    }
}
