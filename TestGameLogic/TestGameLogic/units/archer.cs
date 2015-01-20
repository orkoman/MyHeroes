using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestGameLogic.weapons;

namespace TestGameLogic.units
{
    public class archer : warrior
    {
        public archer(baseInHand rightHandWeapon, baseInHand leftHandWeapon)
            :base(rightHandWeapon,leftHandWeapon)
        { 
        
        }

        public override object Clone()
        {
            return new archer(rightHandWeapon.Clone() as baseInHand, leftHandWeapon.Clone() as baseInHand);
        }
    }
}
