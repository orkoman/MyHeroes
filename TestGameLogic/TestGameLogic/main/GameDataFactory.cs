using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestGameLogic.units;
using TestGameLogic.weapons;
using TestGameLogic.skills;
using TestGameLogic.units.parts;
using TestGameLogic.main.Requirements;

namespace TestGameLogic.main
{
    public static class GameDataFactory
    {
        // UNITS
        public static Warrior createWarrior()
        {
            List<basePart> parts = new List<basePart> { new MainHand(), new OffHand() };
            int count = 50;
            int baseHp = 50;
            int baseSpeed = 5;
            int basePower = 5;
            Damage baseDamage = new Damage(1, 2);


            return new Warrior(parts, count, baseHp, baseSpeed, basePower, baseDamage);
        }

        public static Archer createArcher()
        {
            List<basePart> parts = new List<basePart> { new MainHand(), new OffHand() };
            int count = 50;
            int baseHp = 30;
            int baseSpeed = 5;
            int basePower = 5;
            Damage baseDamage = new Damage(2, 3);

            return new Archer(parts, count, baseHp, baseSpeed, basePower, baseDamage);
        }

        // WEAPONS
        public static Sword createSword()
        {
            //TODO read from xml
            List<baseSkill> skills = new List<baseSkill> { new SwordSkill() };
            baseUnitRequirement reqs = new MultiplePartsRequirement(typeof(Hand),1);
            
            return new Sword(skills,reqs,new Damage(5,10));
        }

        public static Shield createShield()
        {
            //TODO read from xml
            List<baseSkill> skills = new List<baseSkill> { new BowSkill() };
            baseUnitRequirement reqs = new MultiplePartsRequirement(typeof(OffHand),1);

            return new Shield(skills, reqs);
        }

        public static Bow createBow()
        {
            //TODO read from xml
            List<baseSkill> skills = new List<baseSkill> { new BowSkill() };
            baseUnitRequirement reqs = new MultiplePartsRequirement(typeof(Hand), 2);
            reqs.and(new MultiplePartsRequirement(typeof(OffHand), 1));

            return new Bow(skills, reqs, new Damage(5, 10));
        }
    }
}

/*(X1orY1)and(X2orY2)


baseUnitRequirement x1 = new baseUnitRequirement();
baseUnitRequirement y1 = new baseUnitRequirement();

baseUnitRequirement x2 = new baseUnitRequirement();
baseUnitRequirement y2 = new baseUnitRequirement();

X1orX2orX3)and(Y1)and(Y2)

y1.and(y2)
x1.or(x2);
x2.or(x3)
x1.and(y1);
x2.and(y1);
x3.and(y1);



reqs.and(new MultiplePartsRequirement(typeof(OffHand), 1));*/
