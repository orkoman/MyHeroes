using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestGameLogic.units;
using TestGameLogic.property;

namespace TestGameLogic.skills
{
    public abstract class baseActiveRangeSkill : baseActiveSkill
    {
        public baseActiveRangeSkill(int costs)
            : base(costs)
        {
            //TODO Oleg range for skill? or weapon or unit !!!!!!
            //properties.Add(new Range(range));
        }

        public override bool needMove()
        {
            return false;
        }
    }
}
