using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestGameLogic.units;

namespace TestGameLogic.skills
{
    public class NormalAttack : baseActiveSkill
    {
        public NormalAttack()
        {
            //TODO Oleg read from xml or database
            costs = +4;
        }
                
    }
}
