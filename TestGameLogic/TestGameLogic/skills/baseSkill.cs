﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestGameLogic.units;

namespace TestGameLogic.skills
{
    public abstract class baseSkill
    {
        public baseSkill()
        { 
        }

        public abstract bool isActive();
    }
}
