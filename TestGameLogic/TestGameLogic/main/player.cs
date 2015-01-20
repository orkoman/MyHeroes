using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestGameLogic.units;

namespace TestGameLogic
{
    public class player
    {
        private baseUnit[] units = null;

        public player(baseUnit unit1, baseUnit unit2)
        {
            units = new baseUnit[] { unit1, unit2 };
        }
    }
}
