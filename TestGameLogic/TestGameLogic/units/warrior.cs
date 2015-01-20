using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestGameLogic.weapons;
using TestGameLogic.main;
using TestGameLogic.units.parts;

namespace TestGameLogic.units
{
    public class Warrior : baseUnit
    {
        public Warrior(List<basePart> parts, int count, int baseHp, int baseSpeed, int basePower, Damage baseDamage)
            : base(parts, count, baseHp, baseSpeed, basePower, baseDamage)
        {
        }

        public override object Clone()
        {
            //TODO parts.Clone()
            return new Warrior(parts, count, baseHp, baseSpeed, basePower, baseDamage);
        }

        /*public override void setWeapon(baseInHand thing)
        { 
            
        }

        public override void setWeapon(baseInHand thing, EHandType place)
        { 
        }*/
    }
}
