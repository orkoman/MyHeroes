using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestGameLogic.skills;

namespace TestGameLogic.weapons
{
    public class shield : baseInHand
    {
        public shield()
            : base(new swordSkill())
        {
        }

        public override object Clone()
        {
            return new shield();
        }
    }
}
