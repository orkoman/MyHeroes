using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestGameLogic.skills;

namespace TestGameLogic.weapons
{
    public abstract class baseWeapon: baseInHand
    {
        public baseWeapon(baseSkill skill)
            :base(skill)
        {
            //TODO
            skill.setOwner(null);
        }

        private int minDamage = -1;
        private int maxDamage = -1;
    }
}
