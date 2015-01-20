using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestGameLogic.units;

namespace TestGameLogic.skills
{
    public class ShieldSkill : baseSkill
    {
        public ShieldSkill()
        { 
        }

        protected override void setInitialParams()
        {
            //TODO Oleg read from xml or database
            costs = -2;
        }

        public override object Clone()
        {
            return new ShieldSkill();
        }
    }
}
