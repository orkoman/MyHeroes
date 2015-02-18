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
        public Warrior(List<baseSlot> parts, int count, int baseHp, int baseSpeed, int basePower, Damage baseDamage)
            : base(parts, count, baseHp, baseSpeed, basePower, baseDamage)
        {
        }


    }
}
