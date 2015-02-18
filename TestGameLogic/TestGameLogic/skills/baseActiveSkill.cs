using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestGameLogic.units;

namespace TestGameLogic.skills
{
    public abstract class baseActiveSkill : baseSkill
    {
        protected int costs = -1;

        public baseActiveSkill()
        { 
        }

        public override bool isActive()
        {
            return true;
        }
    
    }
}
