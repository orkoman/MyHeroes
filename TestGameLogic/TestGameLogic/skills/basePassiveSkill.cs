using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestGameLogic.units;

namespace TestGameLogic.skills
{
    public abstract class basePassiveSkill : baseSkill
    {
        public basePassiveSkill()
        { 
        }

        public override bool isActive()
        {
            return false;
        }
    }
}
