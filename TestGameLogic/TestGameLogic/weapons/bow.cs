using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestGameLogic.skills;
using TestGameLogic.main;
using TestGameLogic.main.Requirements;

namespace TestGameLogic.weapons
{
    public class Bow : baseWeapon
    {
        public Bow(List<baseSkill> skills, baseUnitRequirement requirements, Damage damage)
            : base(skills, requirements, damage)
        {
            this.skills.Insert(0,new NormalRangeAttack()); //TODO OLEG maybe add this also through xml
        }

        
    }
}
