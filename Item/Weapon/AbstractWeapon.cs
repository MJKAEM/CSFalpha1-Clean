using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ErrorDepartment;

namespace Item.Weapon
{
    public abstract class AbstractWeapon : AbstractEquipment
    {
        private bool oneHand, twoHand;
        private ushort minDmg, maxDmg;
        private sbyte attackSpeed;
        private byte weaponStat;

        protected AbstractWeapon(byte x, byte y)
            : base(x, y)
        {
            attackSpeed = 10; //attackSpeed goes from 0-10.  10 is the slowest and -10 is the fastest.
        }
        public void Attack()
        {

        }
        public override void Woop()
        {
            base.Woop();
            
            //At release, remove this, or the game will suffer lag.
            if (!oneHand && oneHand == twoHand)
            {
                for (; ; )
                    ConsolePrinter.RedPrint(this + " is no hand Jack! ARGGHHHH!!!");
            }
        }
        public virtual void Temper()
        {
            ConsolePrinter.RedPrint("Ivalid weapon. The weapon must be either a sword\n or a polearm.\n");
        }
        public bool OneHand { get { return oneHand; } set { oneHand = value; } }
        public bool TwoHand { get { return twoHand; } set { twoHand = value; } }
        public ushort MinDmg { get { return minDmg; } set { minDmg = value; } }
        public ushort MaxDmg { get { return maxDmg; } set { maxDmg = value; } }
        public sbyte AttackSpeed { get { return attackSpeed; } set { attackSpeed = value; } }

        /// <summary>
        /// Gets and sets the level of the weapon.
        /// 000 = Nothing.
        /// 001 = Tempered.
        /// 010 = Chromium.
        /// 011 = Tempered & Chromium.
        /// 100 = Titanium.
        /// 101 = Titanium & Tempered.
        /// 110 = Titanium & Chromium.
        /// 111 = Titanium, Chromium, & Tempered.
        /// </summary>
        public byte WeaponStat { get { return weaponStat; } set { weaponStat = value; } }
    }
}
