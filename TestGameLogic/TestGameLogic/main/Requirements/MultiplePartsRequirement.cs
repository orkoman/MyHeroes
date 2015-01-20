using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestGameLogic.units;

namespace TestGameLogic.main.Requirements
{
    public class MultiplePartsRequirement : baseUnitRequirement
    {
        Type partType = null;
        int count = -1;

        public MultiplePartsRequirement(Type partType, int count)
        {
            this.partType = partType;
            this.count = count;
        }

        protected override bool check(baseUnit unit)
        {
            return (unit.countParts(partType) >= count);
        }
    }
}
