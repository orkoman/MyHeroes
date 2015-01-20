using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestGameLogic.units;

namespace TestGameLogic.skills
{
    public class attack : baseSkill
    {
        public attack()
        { 
        }

        public override bool use()
        {
            owner.Power += 4; //TODO put in xml
            //TODO damage
            return true;
        }

        public override object Clone()
        {
            return new attack();
        }
    }
}
