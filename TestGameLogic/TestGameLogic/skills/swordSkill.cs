using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestGameLogic.units;

namespace TestGameLogic.skills
{
    public class swordSkill : baseSkill
    {
        public swordSkill()
        { 
        }

        public override bool use()
        {
            //TODO
            return false;
        }

        public override object Clone()
        {
            return new swordSkill();
        }
    }
}
