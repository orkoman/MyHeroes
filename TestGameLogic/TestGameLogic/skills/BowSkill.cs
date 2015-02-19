using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestGameLogic.units;

namespace TestGameLogic.skills
{
    public class BowSkill : baseActiveRangeSkill
    {
        public BowSkill()
            : base(-6) //TODO Oleg read from xml or database
        {
            
        }

    }
}
