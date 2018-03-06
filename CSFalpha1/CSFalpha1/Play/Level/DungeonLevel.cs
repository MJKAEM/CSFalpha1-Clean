#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NPC;
#endregion

namespace CSFalpha1.Play.Level
{
    public abstract class DungeonLevel : AbstractLevel
    {
        private List<AbstractNPC> npc = new List<AbstractNPC>();

        protected DungeonLevel()
            : base()
        {

        }

        public void Move()
        {
            for (int i = npc.Count - 1; i >= 0; i--)
            {
                npc.ElementAt(i).Move();
            }
        }
        public List<AbstractNPC> GetNPC { get { return npc; } set { npc = value; } }
    }
}
