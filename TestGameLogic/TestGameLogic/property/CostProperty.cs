using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestGameLogic.property
{
    public class CostProperty : baseProperty
    {

        public override string Name
        {
            get { return "Costs"; }
        }

        public CostProperty(int value)
            : base(value)
        {
            
        }

    }
}
