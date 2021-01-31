using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StatsPlus;

namespace StatsPlus
{
    /// <summary>
    /// With a SkillEffectAdd, a float is added to the stat.
    /// </summary>
    public class SkillEffectAdd : SkillEffect
    {
        public float amountToAdd;

        public SkillEffectAdd(string affectsStatName, bool ignoreSkillStrength, float amountToAdd) : base(affectsStatName, ignoreSkillStrength)
        {
            this.amountToAdd = amountToAdd;
        }
    }
}
