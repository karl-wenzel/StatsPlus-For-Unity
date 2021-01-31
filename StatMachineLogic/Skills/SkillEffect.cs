using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StatsPlus;

namespace StatsPlus
{
    /// <summary>
    /// A SkillEffect describes one effect a skill has on the behaviour of the stat machine.
    /// </summary>
    public class SkillEffect
    {
        public string affectsStatName;
        public bool ignoreSkillStrength;

        public SkillEffect(string affectsStatName, bool ignoreSkillStrength)
        {
            this.affectsStatName = affectsStatName;
            this.ignoreSkillStrength = ignoreSkillStrength;
        }
    }
}
