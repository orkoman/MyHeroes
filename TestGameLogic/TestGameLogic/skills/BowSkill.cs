using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestGameLogic.units;

namespace TestGameLogic.skills
{
    public class BowSkill : baseSkill
    {
        public BowSkill()
        { 
        }

        protected override void setInitialParams()
        {
            //TODO Oleg read from xml or database
            costs = -6;
        }

    }
}
