using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StatsPlus;

namespace StatsPlus
{
    /// <summary>
    /// With a SkillEffectMultiply, the stat value is multiplyed with a factor. Use for example 1.5f to add 50% to the stat value.
    /// Set AddToInitialValue to true to calculate the 50% from the initial value and then add it to the finished value.
    /// </summary>
    public class SkillEffectMultiply : SkillEffect
    {
        public readonly float MultiplyWith;
        public readonly bool AddToInitialValue;

        public SkillEffectMultiply(string affectsStatName, bool ignoreSkillStrength, float MultiplyWith, bool UseInitialValue) : base(affectsStatName, ignoreSkillStrength)
        {
            this.MultiplyWith = MultiplyWith;
            this.AddToInitialValue = UseInitialValue;
        }

        public override object ProcessStat(Stat stat, object value)
        {
            if (stat is StatFloat)
            {
                return AddToInitialValue ? (float)stat.GetValueAsObject() * (MultiplyWith-1f) + (float)value : (float)value * MultiplyWith;
            }
            if (stat is StatInt)
            {
                return (int)(AddToInitialValue ? (float)stat.GetValueAsObject() * (MultiplyWith - 1f) + (float)value : (float)value * MultiplyWith);
            }
            return value;
        }
    }
}
