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
        float Maximum;
        bool HasMaximum;
        float Minimum;
        bool HasMinimum;

        public SkillEffectAdd(string affectsStatName, bool ignoreSkillStrength, float amountToAdd) : base(affectsStatName, ignoreSkillStrength)
        {
            this.amountToAdd = amountToAdd;
        }

        public override object ProcessStat(Stat stat, object value, float strength)
        {
            if (stat is StatFloat)
            {
                return (float)value + (amountToAdd * strength);
            }
            if (stat is StatInt)
            {
                return (int)((float)value + (amountToAdd * strength));
            }
            return base.ProcessStat(stat, value, strength);
        }

        public override string PrettyPrint()
        {
            return "Add|amount:" + amountToAdd + ";";
        }
    }
}
