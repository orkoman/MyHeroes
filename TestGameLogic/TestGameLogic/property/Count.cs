using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestGameLogic.property
{
    public class Count : baseProperty
    {

        public override string Name
        {
            get { return "Count"; }
        }

        public Count(int value)
            : base(value)
        {
            
        }

    }
}
