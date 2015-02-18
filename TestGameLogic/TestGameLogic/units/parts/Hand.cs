using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestGameLogic.weapons;
using TestGameLogic.weapons.Interface;

namespace TestGameLogic.units.parts
{
    public abstract class Hand : baseSlot
    {
        public Hand(IInSlot thingInSlot)
            : base(thingInSlot)
        { 
        
        }
    }
}
