using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestGameLogic.units;

namespace TestGameLogic.main.Requirements
{
    public class EmptyUnitRequirement : baseUnitRequirement
    {
        public EmptyUnitRequirement()
        {
        }

        protected override bool check(baseUnit obj)
        {
            return true;
        }
    }
}
