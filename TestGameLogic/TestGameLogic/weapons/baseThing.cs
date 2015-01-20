using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestGameLogic.skills;
using TestGameLogic.units.parts;
using TestGameLogic.main;
using TestGameLogic.main.Requirements;
using TestGameLogic.units;

namespace TestGameLogic.weapons
{
    public abstract class baseThing : ICloneable
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

        public abstract object Clone();

        //TODO
        //public abstract bool setToUnit(baseUnit unit, basePart where);
    }
}
