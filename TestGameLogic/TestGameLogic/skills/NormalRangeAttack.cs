using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestGameLogic.units;

namespace TestGameLogic.skills
{
    public class NormalRangeAttack : baseActiveRangeSkill
    {
        public NormalRangeAttack()
            : base(-1) //TODO Oleg read from xml or database
        { 
        }

    }
}
