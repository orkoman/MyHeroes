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
    public class ShadowThing : IInSlot
    {
        baseThing thing = null;

        public ShadowThing(baseThing thing)
        {
            this.thing = thing;
        }

        public baseThing getThing()
        {
            return thing;
        }

        public List<baseSkill> getSkills()
        {
            return new List<baseSkill>();
        }
    }
}
