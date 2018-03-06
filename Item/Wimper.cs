#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Item.Weapon;
#endregion

namespace Item
{
    public static class Wimper
    {

        /// <summary>
        /// Wa!!! Hen duo de damage!
        /// </summary>
        /// <param name="contraband">Super weapon.</param>
        public static void TurboDamage(AbstractWeapon contraband)
        {
            contraband.MaxDmg = 0;
            contraband.MinDmg = 0;
        }

        /// <summary>
        /// How do you make varnish disappear?
        /// varnish -> vanish
        /// </summary>
        /// <param name="contraband">Specify the illegal item.</param>
        public static void Varnish(AbstractItem contraband)
        {
            //Bye bye
            contraband = null;
        }

        /// <summary>
        /// Houston, we have a problem.
        /// </summary>
        public static void Spacemen(AbstractItem contraband)
        {
            contraband.SpaceX = 10;
            contraband.SpaceY = 5;
        }
    }
}
