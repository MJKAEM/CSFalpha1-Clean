#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion

namespace NPC.Town
{
    public abstract class TownNPC : AbstractNPC
    {
        protected TownNPC(int x, int y) : base(x, y) { }
        public abstract string[] ChatLines();
    }
}
