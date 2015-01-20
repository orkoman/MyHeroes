using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestGameLogic.main.Tests
{
    public class TestObject
    {
        int hp = 50;
        int damage = 10;

        int speed = 4;
        int power = 7;

        public bool checkHp(int value)
        {
            if (hp == value)
            {
                return true;
            }

            return false;
        }

        public bool checkDamage(int value)
        {
            if (damage == value)
            {
                return true;
            }

            return false;
        }

        public bool checkSpeed(int value)
        {
            if (speed == value)
            {
                return true;
            }

            return false;
        }

        public bool checkPower(int value)
        {
            if (power == value)
            {
                return true;
            }

            return false;
        }
    }
}
