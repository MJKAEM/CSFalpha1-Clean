#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ContentLoader;
#endregion

namespace Item.Consumable.Food
{
    public class Dragonfruit : AbstractConsumable
    {
        public Dragonfruit(byte x, byte y)
            : base(x, y)
        {
            ItemSprite = TheContentLoader.ConsSprite[20];
        }
        public override void UseItem()
        {
            throw new NotImplementedException();
        }
    }
}
