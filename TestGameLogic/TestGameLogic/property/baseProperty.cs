using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestGameLogic.property
{
    public abstract class baseProperty
    {
        protected int value = -1;

        public virtual int Value
        {
            get { return this.value; }
        }

        public virtual string ValueAsString
        {
            get { return this.value.ToString(); }
        }

        public abstract string Name
        {
            get;
        }

        public baseProperty(int value)
        {
            this.value = value;
        }



    }
}
