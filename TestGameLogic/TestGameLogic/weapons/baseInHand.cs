using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestGameLogic.skills;

namespace TestGameLogic.weapons
{
    public abstract class baseInHand : ICloneable
    {
        public baseSkill skill = null;

        public baseInHand(baseSkill skill)
        {
            this.skill = skill;
        }

        public abstract object Clone();
    }
}
