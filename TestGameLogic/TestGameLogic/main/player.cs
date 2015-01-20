using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestGameLogic.units;

namespace TestGameLogic
{
    public class Player
    {
        private List<baseUnit> units = null;

        public Player(List<baseUnit> units)
        {
            this.units = units;
        }
    }
}
