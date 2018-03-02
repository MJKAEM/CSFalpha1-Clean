using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSFalpha1.Play.Level.Map.Town.BuildingParts;

namespace CSFalpha1.Play.Level.Map.Town
{
    public class MedicBuilding : Building
    {
        public MedicBuilding(int x, int y)
            : base(x, y)
        {
            Roof = new MedicRoof(x, y);
            Base = new MedicBase(x+8, y+230);
        }
    }
}
