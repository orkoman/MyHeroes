using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestGameLogic.weapons;

namespace TestGameLogic.units.parts
{
    public class basePart
    {
        protected baseThing thing = null;

        public basePart()
        { 
        
        }

        public bool isFree()
        { 
            return (thing == null);
        }

        //TODO
        //public abstract void setSomething(baseInHandWithSkill thing);     
        /*{
            //if (thingInHand == null) //TODO hand not empty
            //{

            if (handType == thing.getHandType())
            {
                thingInHand = thing;
            }
        }*/
    }
}
