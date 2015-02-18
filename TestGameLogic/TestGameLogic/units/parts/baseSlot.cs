using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestGameLogic.weapons;
using TestGameLogic.weapons.Interface;
using TestGameLogic.skills;

namespace TestGameLogic.units.parts
{
    public abstract class baseSlot
    {
        protected IInSlot thingInSlot = null;

        public baseSlot(/*IInSlot thingInSlot*/)
        { 
        
        }

        public bool isFree()
        {
            return (thingInSlot == null);
        }

        public void setSomething(IInSlot thingInSlot)    
        {
            this.thingInSlot = thingInSlot;
        }

        public List<baseSkill> getSkills()
        {
            if (thingInSlot != null)
            {
                return thingInSlot.getSkills();
            }
            return new List<baseSkill>();
        }

    }
}
