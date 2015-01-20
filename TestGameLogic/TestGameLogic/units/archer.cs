using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestGameLogic.weapons;
using TestGameLogic.main;
using TestGameLogic.units.parts;

namespace TestGameLogic.units
{
    public class Archer : Warrior
    {
        public Archer(List<basePart> parts, int count, int baseHp, int baseSpeed, int basePower, Damage baseDamage)
            : base(parts, count, baseHp, baseSpeed, basePower, baseDamage)
        {
        }

        public override object Clone()
        {
            //TODO
            return new Archer(parts, count, baseHp, baseSpeed, basePower, baseDamage);
        }
    }
}
