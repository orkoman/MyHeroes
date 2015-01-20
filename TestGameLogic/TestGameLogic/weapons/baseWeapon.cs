using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestGameLogic.skills;
using TestGameLogic.main;
using TestGameLogic.main.Requirements;

namespace TestGameLogic.weapons
{
    public abstract class baseWeapon: baseThing
    {
        public baseWeapon(List<baseSkill> skills, baseUnitRequirement requirements, Damage damage)
            : base(skills, requirements)
        {
            this.damage = damage;
        }

        protected Damage damage = null;
    }
}
