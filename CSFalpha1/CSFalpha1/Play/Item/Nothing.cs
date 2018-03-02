using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSFalpha1.Play.Item
{
    public class Nothing : abstractItem
    {
        public Nothing() { }
        public override void LoadContent()
        {
            itemSprite = ContentLoader.ItemSprite(0);
            if (itemSprite.Width != 1 && itemSprite.Height != 1)
            {
                for(;;)
                {
                    Console.WriteLine("FATAL ERROR!");
                }
            }
        }
    }
}
