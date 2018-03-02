using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using CSFalpha1.Play.Level.NPC;
using CSFalpha1.Play.Level.NPC.Town;
using CSFalpha1.Play.Level.Map;

namespace CSFalpha1.Play.Level
{
    public abstract class abstractLevel
    {
        protected int sizeX, sizeY;
        protected List<abstractNPC> npc;
        protected Texture2D Floor;
        protected List<Obstruction> structure;

        public abstractLevel()
        {
            structure = new List<Obstruction>();
            npc = new List<abstractNPC>();
        }
        public abstract void LoadContent();
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
        public void Move()
        {
            for (int i = 0; i < npc.Count(); i++)
            {
                npc.ElementAt(i).Move();
            }
        }
        public void Block()
        {
            for (int i = 0; i < npc.Count(); i++)
            {
                npc.ElementAt(i).Block();
            }
            for (int i = 0; i < structure.Count(); i++)
            {
                structure.ElementAt(i).Block();
            }
        }
        public bool GetCollide(int a)
        {
            for (int i = 0; i < npc.Count(); i++)
            {
                if (npc.ElementAt(i).GetCollide(a))
                {
                    return true;
                }
            }
            for (int i = 0; i < structure.Count(); i++)
            {
                if (structure.ElementAt(i).GetCollide(a))
                {
                    return true;
                }
            }
            return false;
        }
        public void UnCollide(int a)
        {
            for (int i = 0; i < npc.Count(); i++)
            {
                npc.ElementAt(i).UnCollide(a);
            }
            for (int i = 0; i < structure.Count(); i++)
            {
                structure.ElementAt(i).UnCollide(a);
            }
        }
        /**************These four layers are restricted to appearing below the player.**************/
        public abstract void Layer1(SpriteBatch sb);
        public abstract void Layer2(SpriteBatch sb);
        public abstract void Layer3(SpriteBatch sb);
        public abstract void Layer4(SpriteBatch sb);
        /**************These four layers are restricted to appearing above the player.**************/
        public abstract void ALayer1(SpriteBatch sb);
        public abstract void ALayer2(SpriteBatch sb);
        public abstract void ALayer3(SpriteBatch sb);
        public abstract void ALayer4(SpriteBatch sb);

        public List<abstractNPC> GetNPC { get { return npc; } }
    }
}
