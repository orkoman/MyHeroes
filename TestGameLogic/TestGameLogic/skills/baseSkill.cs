using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestGameLogic.units;
using TestGameLogic.property;

namespace TestGameLogic.skills
{
    public abstract class baseSkill
    {
        protected List<baseProperty> properties = null;

        public baseSkill()
        {
            properties = new List<baseProperty>();
        }

        public abstract bool isActive();
    }
}
