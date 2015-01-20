using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestGameLogic.skills;

namespace TestGameLogic.units
{
    public abstract class baseUnit : ICloneable
    {
        protected baseSkill[] baseSkills = null;

        protected int position = -1; //not set
        protected int hp = -1;
        protected int count = -1;
        protected int speed = -1;
        protected int power = -1;
        protected int baseDamage = -1;

        public baseUnit()
        {
            baseSkills = new baseSkill[] { new attack(), new defence() };
        }

        public int Power
        {
            get { return power; }
            set { power = value; }
        }

        public abstract object Clone();

        //public abstract void move();
    }
}