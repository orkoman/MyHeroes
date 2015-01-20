using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestGameLogic.skills;
using TestGameLogic.main;
using TestGameLogic.main.Requirements;

namespace TestGameLogic.weapons
{
    public class Sword : baseWeapon
    {
        public Sword(List<baseSkill> skills, baseUnitRequirement requirements, Damage damage)
            : base(skills, requirements, damage)
        {

        }

        public override object Clone()
        {
            return new Sword(skills, requirements, damage);
        }
    }
}
