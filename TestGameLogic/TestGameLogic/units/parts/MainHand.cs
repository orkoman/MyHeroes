﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestGameLogic.weapons;
using TestGameLogic.weapons.Interface;

namespace TestGameLogic.units.parts
{
    public class MainHand : Hand
    {
        public MainHand(IInSlot thingInSlot = null)
            : base(thingInSlot)
        {

        }

       
    }
}
