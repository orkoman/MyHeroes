using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestGameLogic.weapons;
using TestGameLogic.weapons.Interface;

namespace TestGameLogic.units.parts
{
    public abstract class baseSlot
    {
        protected IInSlot thingInSlot = null;

        public baseSlot(IInSlot thingInSlot)
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

    }
}
