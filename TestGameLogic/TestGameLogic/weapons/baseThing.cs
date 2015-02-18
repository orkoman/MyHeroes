using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestGameLogic.skills;
using TestGameLogic.units.parts;
using TestGameLogic.main;
using TestGameLogic.main.Requirements;
using TestGameLogic.units;
using TestGameLogic.weapons.Interface;

namespace TestGameLogic.weapons
{
    public abstract class baseThing : IInSlot
    {
        protected baseUnitRequirement requirements = null;
        protected List<baseSkill> skills = null;

        public baseUnitRequirement Requirements
        {
            get { return requirements; }
        }

        public baseThing(List<baseSkill> skills, baseUnitRequirement requirements)
        {
            this.skills = skills;
            this.requirements = requirements;
        }

        public baseThing getThing()
        {
            return this;
        }
    }
}
