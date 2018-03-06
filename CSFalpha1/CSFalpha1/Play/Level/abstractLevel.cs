#region Using Statements
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using NPC;
using NPC.Town;
using CSFalpha1.Play.Level.Map;
#endregion

namespace CSFalpha1.Play.Level
{
    public abstract class AbstractLevel
    {
        private int sizeX, sizeY;

        protected Texture2D Floor;
        protected List<AbstractObstruction> structure;

        protected AbstractLevel()
        {
            structure = new List<AbstractObstruction>();
        }
        public void Show(SpriteBatch sb)
        {
            Layer1(sb);
            Layer2(sb);
            Layer3(sb);
            Layer4(sb);
        }
        public void AShow(SpriteBatch sb)
        {
            ALayer1(sb);
            ALayer2(sb);
            ALayer3(sb);
            ALayer4(sb);
        }
        /**************These four layers are restricted to appearing below the player.**************/
        public virtual void Layer1(SpriteBatch sb) { }
        public virtual void Layer2(SpriteBatch sb) { }
        public virtual void Layer3(SpriteBatch sb) { }
        public virtual void Layer4(SpriteBatch sb) { }
        /**************These four layers are restricted to appearing above the player.**************/
        public virtual void ALayer1(SpriteBatch sb) { }
        public virtual void ALayer2(SpriteBatch sb) { }
        public virtual void ALayer3(SpriteBatch sb) { }
        public virtual void ALayer4(SpriteBatch sb) { }

        public int SizeX { get { return sizeX; } set { sizeX = value; } }
        public int SizeY { get { return sizeY; } set { sizeY = value; } }
    }
}
