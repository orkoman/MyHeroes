using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestGameLogic.skills;

namespace TestGameLogic.weapons.Interface
{
    public interface IInSlot
    {
        baseThing getThing();
        List<baseSkill> getSkills();
    }
}
