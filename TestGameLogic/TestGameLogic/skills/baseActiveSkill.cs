using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestGameLogic.units;
using TestGameLogic.property;

namespace TestGameLogic.skills
{
    public abstract class baseActiveSkill : baseSkill
    {
        public baseActiveSkill(int costs)
        {
            properties.Add(new CostProperty(costs));
        }

        public override bool isActive()
        {
            return true;
        }

        public baseProperty Costs
        { 
            get{return properties[0];} //TODO OLEG change to hashtable or something
        }

        public abstract bool needMove(); //TODO OLEG make extra interface for this?
    }
}
