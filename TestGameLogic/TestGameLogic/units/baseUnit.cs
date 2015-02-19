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
using TestGameLogic.property;

namespace TestGameLogic.units
{
    public abstract class baseUnit
    {
        protected baseActiveSkill selectedSkill = null;

        protected List<baseSkill> skills = null;
        protected List<baseSlot> slots = null;

        protected List<baseProperty> properties = null;

        protected int position = -1; //not set
        protected int target = -1; //not set
        //protected int count = -1;

        //protected int baseHp = -1;
        //protected int baseSpeed = -1;
        //protected int basePower = -1;
        //protected Damage baseDamage = null;

        

        public baseUnit(List<baseSlot> parts, int count, int baseHp, int baseSpeed, int basePower, Damage baseDamage)
        {
            this.slots = parts;
            this.skills = new List<baseSkill> { new NormalAttack(), new NormalDefence() };
            //this.count = count;

            properties = new List<baseProperty>();
            properties.Add(new Count(count));
            properties.Add(new HitPoints(baseHp));
            properties.Add(new DamageProperty(baseDamage));
            properties.Add(new Power(basePower));
            properties.Add(new Speed(baseSpeed));
        }

        public baseActiveSkill SelectedSkill
        {
            get { return selectedSkill; }
        }

        public List<baseProperty> Properties
        {
            get { return properties; }
        }

        public int Position
        {
            get { return position; }
            set { position = value; }
        }

        public int Target
        {
            get { return target; }
            set { target = value; }
        }

        /*public int Power
        {
            get { return properties[3].Value; } //TODO OLEG change to hashtable or something
        }*/

        public int Speed
        {
            get { return properties[4].Value; }  //TODO OLEG change to hashtable or something
        }

        public int countFreeSlots(Type type)
        {
            int count = 0;
            foreach (baseSlot part in slots)
            {
                if (type.IsAssignableFrom(part.GetType())
                    && part.isFree()
                    )
                {
                    count++;
                }
            }
            return count;
        }

        public List<baseSlot> getFreeSlots(Type type)
        {
            List<baseSlot> freeSlots = new List<baseSlot>();
            foreach (baseSlot part in slots)
            {
                if (type.IsAssignableFrom(part.GetType())
                    && part.isFree()
                    )
                {
                    freeSlots.Add(part);
                }
            }
            return freeSlots;
        }

        //TODO put in more then 1 mainSlot
        public virtual void setWeapon(baseThing thing, baseSlot slotWhereToPut = null)
        {
            bool checkReqs = thing.Requirements.checkAll(this);

            if (checkReqs)
            {
                SlotsRequirement slotReq = thing.Requirements.findFirstRequirement(typeof(SlotsRequirement)) as SlotsRequirement;
                List<baseSlot> slots = getFreeSlots(slotReq.SlotType);

                int mainSlotIndex = slots.IndexOf(slotWhereToPut);
                if (mainSlotIndex >= 0)
                {
                    slots[mainSlotIndex].setSomething(thing);
                }
                else
                {
                    mainSlotIndex = 0;
                    slots[mainSlotIndex].setSomething(thing);
                }

                for (int n = 0; n < slotReq.SlotsCount;n++ )
                {
                    if (n != mainSlotIndex)
                    {
                        slots[n].setSomething(new ShadowThing(thing));
                    }
                }
                
            }
            else
            {
                MessageBox.Show("Cant set weapon");
            }
        }

        public List<baseActiveSkill> getActiveSkills()
        {
            List<baseActiveSkill> tempSkills = getActiveSkillsHelper(skills);

            //also from weapons
            foreach (baseSlot slot in slots)
            {
                tempSkills.AddRange(getActiveSkillsHelper(slot.getSkills()));
            }

            return tempSkills;
        }

        private List<baseActiveSkill> getActiveSkillsHelper(List<baseSkill> helperSkills)
        {
            List<baseActiveSkill> tempSkills = new List<baseActiveSkill>();

            foreach (baseSkill skill in helperSkills)
            {
                if (skill.isActive())
                {
                    tempSkills.Add(skill as baseActiveSkill);
                }
            }
            return tempSkills;
        }

        public void selectSkill(baseActiveSkill skill)
        {
            selectedSkill = skill;
        }

        public void unselectUnit()
        {
            selectedSkill = null;
        }
    }
}