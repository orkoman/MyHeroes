using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestGameLogic.main
{
    public class Damage
    {
        protected int minDamage = -1;
        protected int maxDamage = -1;

        public Damage(int minDamage, int maxDamage)
        {
            if (minDamage > maxDamage)
            {
                throw new Exception("Min > Max!!!");
            }
            this.minDamage = minDamage;
            this.maxDamage = maxDamage;
        }

        public int calculateDamage()
        { 
            int result = Game.GameRandom.Next(maxDamage-minDamage) + minDamage;
            return result;
        }

       
    }
}
