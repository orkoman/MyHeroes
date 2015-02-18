using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestGameLogic.units;

namespace TestGameLogic.skills
{
    public class SwordSkill : baseActiveSkill
    {
        public SwordSkill()
        {
            //TODO Oleg read from xml or database
            costs = -4;
        }       
    }
}
