using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestGameLogic.property
{
    public class HitPoints : baseProperty
    {

        public override string Name
        {
            get { return "HitPoints"; }
        }

        public HitPoints(int value)
            : base(value)
        {
            
        }

    }
}
