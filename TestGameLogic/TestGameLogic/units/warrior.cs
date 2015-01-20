using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestGameLogic.weapons;

namespace TestGameLogic.units
{
    public class warrior : baseUnit
    {
        protected baseInHand rightHandWeapon = null;
        protected baseInHand leftHandWeapon = null;

        public warrior(baseInHand rightHandWeapon, baseInHand leftHandWeapon)
        {
            this.rightHandWeapon = rightHandWeapon;
            this.leftHandWeapon = leftHandWeapon;



        }

        public override object Clone()
        {
            return new warrior(rightHandWeapon.Clone() as baseInHand, leftHandWeapon.Clone() as baseInHand);
        }
    }
}
