using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StatsPlus;

namespace StatsPlus
{
    /// <summary>
    /// With a SkillEffectMinMax, you can set a minimum or a maximum for the stat.
    /// </summary>
    public class SkillEffectMinMax : SkillEffect
    {
        float Maximum;
        bool HasMaximum;
        float Minimum;
        bool HasMinimum;

        public SkillEffectMinMax(string affectsStatName, bool ignoreSkillStrength) : base(affectsStatName, ignoreSkillStrength)
        {
        }

        public override object ProcessStat(Stat stat, object value, float strength)
        {
            if (HasMaximum) {
                value = Mathf.Min((float)value, Maximum);
            }
            if (HasMinimum) {
                value = Mathf.Max((float)value, Minimum);
            }
            return base.ProcessStat(stat, value, strength);
        }

        public SkillEffectMinMax SetMaximum(float Maximum) {
            this.Maximum = Maximum;
            HasMaximum = true;
            return this;
        }

        public SkillEffectMinMax ResetMaximum() {
            HasMaximum = false;
            return this;
        }

        public SkillEffectMinMax SetMinimum(float Minimum)
        {
            this.Minimum = Minimum;
            HasMinimum = true;
            return this;
        }

        public SkillEffectMinMax ResetMinimum()
        {
            HasMinimum = false;
            return this;
        }
    }
}
