using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestGameLogic.units;
using TestGameLogic.property;

namespace TestGameLogic.skills
{
    public abstract class baseActiveMoveSkill : baseActiveSkill
    {
        public baseActiveMoveSkill(int costs)
            : base(costs)
        {
            
        }

        public override bool needMove()
        {
            return true;
        }
    }
}
