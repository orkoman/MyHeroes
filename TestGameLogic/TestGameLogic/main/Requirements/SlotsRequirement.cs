using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestGameLogic.units;

namespace TestGameLogic.main.Requirements
{
    public class SlotsRequirement : baseUnitRequirement
    {
        protected Type slotType = null;
        protected int slotsCount = -1;

        public Type SlotType
        {
            get { return slotType; }
        }

        public int SlotsCount
        {
            get { return slotsCount; }
        }

        public SlotsRequirement(Type slotType, int slotsCount)
        {
            this.slotType = slotType;
            this.slotsCount = slotsCount;
        }

        protected override bool check(baseUnit unit)
        {
            return (unit.countFreeSlots(slotType) >= slotsCount);
        }
    }
}
