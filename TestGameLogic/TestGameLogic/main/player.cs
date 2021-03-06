﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestGameLogic.units;

namespace TestGameLogic
{
    public class Player
    {
        private List<baseUnit> units = null;

        private baseUnit selectedUnit = null;

        public baseUnit SelectedUnit
        {
            get { return selectedUnit; }
        }

        public List<baseUnit> Units
        {
            get { return units; }
        }

        public Player(List<baseUnit> units)
        {
            this.units = units;
        }

        public void selectUnit(baseUnit unit)
        {
            selectedUnit = unit;
            if (selectedUnit.SelectedSkill == null)
            {
                selectedUnit.selectSkill(selectedUnit.getActiveSkills()[0]); //TODO must have at least one active skill otherwise null exception (not good)
            }
        }

        public void unselectUnit()
        {
            selectedUnit = null;
        }
    }
}
