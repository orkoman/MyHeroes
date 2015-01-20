using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestGameLogic.units;

namespace TestGameLogic.skills
{
    public abstract class baseSkill: ICloneable
    {
        protected baseUnit owner = null;

        public baseSkill()
        { 
        }

        public void setOwner(baseUnit owner)
        {
            this.owner = owner;
        }

        public abstract object Clone();

        public abstract bool use();
    }
}
