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
        public readonly float amountToAdd;

        public SkillEffectAdd(string affectsStatName, bool ignoreSkillStrength, float amountToAdd) : base(affectsStatName, ignoreSkillStrength)
        {
            this.amountToAdd = amountToAdd;
        }

        public override object ProcessStat(Stat stat, object value, float strength)
        {
            if (stat is StatFloat)
            {
                return (float)value + amountToAdd;
            }
            if (stat is StatInt)
            {
                return (int)((float)value + amountToAdd);
            }
            return value;
        }
    }
}
