using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestGameLogic.units;

namespace TestGameLogic.skills
{
    public class defence : baseSkill
    {
        public defence()
        { 
        }

        public override bool use()
        {
            if (owner.Power >= 4)
            {
                owner.Power += 4;
            }
            return false;
        }

        public override object Clone()
        {
            return new defence();
        }
    }
}
