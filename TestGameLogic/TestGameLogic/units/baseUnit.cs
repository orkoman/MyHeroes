using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestGameLogic.skills;
using TestGameLogic.weapons;
using TestGameLogic.main;
using TestGameLogic.units.parts;
using TestGameLogic.main.Requirements;
using System.Windows.Forms;

namespace TestGameLogic.units
{
    public abstract class baseUnit : ICloneable
    {
        protected List<baseSkill> baseSkills = null;
        protected List<basePart> parts = null;

        protected int position = -1; //not set
        protected int count = -1;

        protected int baseHp = -1;
        protected int baseSpeed = -1;
        protected int basePower = -1;
        protected Damage baseDamage = null;

        //TODO workaround
        protected List<basePart> lastFreeParts = null;

        public baseUnit(List<basePart> parts, int count, int baseHp, int baseSpeed, int basePower, Damage baseDamage)
        {
            this.parts = parts;
            this.baseSkills = new List<baseSkill> { new NormalAttack(), new NormalDefence() };
            this.count = count;
            this.baseHp = baseHp;
            this.baseSpeed = baseSpeed;
            this.basePower = basePower;
            this.baseDamage = baseDamage;
        }

        public int Power
        {
            get { return basePower; }
            set { basePower = value; }
        }

        /*public bool hasPart(Type type)
        {
            foreach (basePart part in parts)
            {
                if ((part.GetType().IsAssignableFrom(type)))
                {
                    return true;
                }
            }
            return false;
        }*/

        public int countParts(Type type)
        {
            lastFreeParts = new List<basePart>();
            int count = 0;
            foreach (basePart part in parts)
            {
                if (part.GetType().IsAssignableFrom(type)
                    && part.isFree()
                    )
                {
                    lastFreeParts.Add(part);
                    count++;
                }
            }
            return count;
        }

        public virtual void setWeapon(baseThing thing, basePart where = null)
        {
            bool checkReqs = thing.Requirements.checkAll(this);

            if (checkReqs)
            {
                //thing.setToUnit(this,where);
                /*if (lastFreeParts.Contains(where))
                { 
                    
                }*/
            }
            else
            {
                MessageBox.Show("Cant set weapon");
            }
        }

        public abstract object Clone();

    }
}