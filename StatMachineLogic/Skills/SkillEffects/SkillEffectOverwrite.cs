using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StatsPlus;

namespace StatsPlus
{
    /// <summary>
    /// With a SkillEffectOverwrite, the initial value of a Stat is overwritten with this new value
    /// </summary>
    public class SkillEffectOverwrite : SkillEffect
    {
        public readonly object newValue;

        public SkillEffectOverwrite(string affectsStatName, object newValue) : base(affectsStatName, true)
        {
            this.newValue = newValue;
        }

        public override object ProcessStat(Stat stat, object value, float strength, StatMachine statMachine)
        {
            if (stat is StatFloat)
            {
                return (float)newValue;
            }
            if (stat is StatInt)
            {
                return (int)newValue;
            }
            if (stat is StatBool)
            {
                return (bool)newValue;
            }
            return base.ProcessStat(stat, value, strength, statMachine);
        }

        public override string PrettyPrint()
        {
            return "Overwrite|" + "|value:" + newValue + ";";
        }
    }
}
