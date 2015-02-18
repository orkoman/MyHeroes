using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestGameLogic.skills;
using TestGameLogic.main;
using TestGameLogic.main.Requirements;

namespace TestGameLogic.weapons
{
    public class Shield : baseThing
    {
        public Shield(List<baseSkill> skills, baseUnitRequirement requirements)
            : base(skills, requirements)
        {

        }

        
    }
}
