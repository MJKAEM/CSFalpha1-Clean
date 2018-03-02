using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSFalpha1.Play.Level.Map.Town.BuildingParts;
using Microsoft.Xna.Framework.Graphics;

namespace CSFalpha1.Play.Level.Map.Town
{
    public class Building : Obstruction
    {
        protected Roof Roof;
        protected Base Base;
        public Building(int x, int y)
            : base(x, y)
        {
            Roof = new Roof(x, y);
            Base = new Base(x + 38, y + 135);
        }
        public override void Show(SpriteBatch sb)
        {
            Roof.Show(sb);
            Base.Show(sb);
        }
        public override void LoadContent()
        {
            Roof.LoadContent();
            Base.LoadContent();
        }
        public override void Block()
        {
            Base.Block();
        }
        public override bool GetCollide(int a)
        {
            return Base.GetCollide(a);
        }
        public override void UnCollide(int a)
        {
            Base.UnCollide(a);
        }
    }
}
