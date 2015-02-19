using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestGameLogic.main;

namespace TestGameLogic.property
{
    public class DamageProperty : baseProperty
    {
        Damage damage = null;

        public override string Name
        {
            get { return "Damage"; }
        }

        public DamageProperty(Damage damage)
            : base(-1) //TODO OLEG dont like this workaround
        {
            this.damage = damage;
        }

        public override int Value
        {
            get { return damage.calculateDamage(); }
        }

        public override string ValueAsString
        {
            get { return damage.MinDamage.ToString() + " - " + damage.MaxDamage.ToString(); }
        }
    }
}
