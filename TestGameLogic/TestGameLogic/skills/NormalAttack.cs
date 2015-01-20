using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestGameLogic.units;

namespace TestGameLogic.skills
{
    public class NormalAttack : baseSkill
    {
        public NormalAttack()
        { 
        }

        protected override void setInitialParams()
        { 
            //TODO Oleg read from xml or database
            costs = +4;
        }

        public override object Clone()
        {
            return new NormalAttack();
        }
    }
}
