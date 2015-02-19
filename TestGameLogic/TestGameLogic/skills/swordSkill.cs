using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestGameLogic.units;

namespace TestGameLogic.skills
{
    public class SwordSkill : baseActiveMoveSkill
    {
        public SwordSkill()
            : base(-4) //TODO Oleg read from xml or database
        {
            
        }       
    }
}
