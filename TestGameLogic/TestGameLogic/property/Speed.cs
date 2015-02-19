using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestGameLogic.property
{
    public class Speed : baseProperty
    {

        public override string Name
        {
            get { return "Speed"; }
        }

        public Speed(int value)
            : base(value)
        {
            
        }

    }
}
