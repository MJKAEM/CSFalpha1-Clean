using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ContentLoader;

namespace CSFalpha1.Play.Level.Map.Town.BuildingParts
{
    public class MedicRoof : Roof
    {
        public MedicRoof(int x, int y) : base(x,y)
        {
            width = 444;
            height = 230;
        }
        public override void LoadContent()
        {
            objectSprite = TheContentLoader.TextureSprite[2];
        }
    }
}
