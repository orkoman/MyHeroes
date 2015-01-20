using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestGameLogic.units;

namespace TestGameLogic.skills
{
    public abstract class baseSkill: ICloneable
    {
        /*protected baseUnit owner = null;
        public void setOwner(baseUnit owner)
        {
            this.owner = owner;
        }*/

        protected int costs = -1;


        public baseSkill()
        { 
        }

        protected abstract void setInitialParams();
        
        public abstract object Clone();
    }
}
