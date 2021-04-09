using System;
using System.Collections.Generic;
using UnityEngine;
using StatsPlus;

namespace StatsPlus
{
    /// <summary>
    /// With a SkillEffectFactMultiply, the stat value is multiplyed with a factor. Use for example 1.5f to add 50% to the stat value.
    /// Set AddToInitialValue to true to calculate the 50% from the initial value and then add it to the finished value.
    /// </summary>
    public class SkillEffectFactMultiply : SkillEffect
    {
        public readonly string MultiplyWith;
        public readonly bool AddToInitialValue;

        public SkillEffectFactMultiply(string affectsStatName, bool ignoreSkillStrength, string MultiplyWithFactId, bool UseInitialValue) : base(affectsStatName, ignoreSkillStrength)
        {
            this.MultiplyWith = MultiplyWithFactId;
            this.AddToInitialValue = UseInitialValue;
        }

        public override object ProcessStat(Stat stat, object value, float strength, StatMachine statMachine)
        {
            Fact searchResultFact = default;
            if (statMachine.FactStorage.HasValue(MultiplyWith, out searchResultFact))
            {
                if (searchResultFact is FactFloat || searchResultFact is FactInt)
                {
                    float factor = Convert.ToSingle(searchResultFact.getValueAsObject());
                    float tempValue = Convert.ToSingle(value);
                    if (stat is StatFloat)
                    {
                        return AddToInitialValue ? (float)stat.GetValueAsObject() * (factor - 1f) * strength + tempValue : tempValue * (factor * strength);
                    }
                    if (stat is StatInt)
                    {
                        return (int)(AddToInitialValue ? (int)stat.GetValueAsObject() * (factor - 1f) * strength + tempValue : tempValue * (factor * strength));
                    }
                }
            }
            return base.ProcessStat(stat, value, strength, statMachine);
        }

        public override string PrettyPrint()
        {
            return "MultiplyWithFact" + "|fact:" + MultiplyWith + (AddToInitialValue ? "|ignoreOtherEffects" : "") + ";";
        }
    }
}
