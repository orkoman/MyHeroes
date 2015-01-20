using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestGameLogic.main.Tests;

namespace TestGameLogic.main.Requirements
{
    public class TestCharacteristicsRequirement : baseRequirement<TestObject>
    {
        int value = -1;
        int type = -1;
        string text = "";

        public TestCharacteristicsRequirement(string text, int value, int type)
        {
            this.value = value;
            this.type = type;
            this.text = text;
        }

        protected override bool check(TestObject obj)
        {
            switch (type)
            {
                case 0:
                    return (obj.checkHp(value));
                case 1:
                    return (obj.checkDamage(value));
                case 2:
                    return (obj.checkSpeed(value));
                case 3:
                    return (obj.checkPower(value));
                default:
                    throw new Exception("No such type!!!");
            }
        }

        public override string ToString()
        {
            return text;
        }
    }
}
