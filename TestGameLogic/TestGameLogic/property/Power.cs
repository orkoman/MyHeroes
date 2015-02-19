using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestGameLogic.property
{
    public class Power : baseProperty
    {

        public override string Name
        {
            get { return "Power"; }
        }

        public Power(int value)
            : base(value)
        {
            
        }

    }
}
