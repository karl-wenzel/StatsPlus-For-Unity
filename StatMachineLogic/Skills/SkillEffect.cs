using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StatsPlus;

namespace StatsPlus
{
    /// <summary>
    /// A SkillEffect describes one effect a skill has on the behaviour of the stat machine.
    /// </summary>
    public abstract class SkillEffect : Printable
    {
        public string affectsStatName;
        public bool ignoreSkillStrength;

        public SkillEffect(string affectsStatName, bool ignoreSkillStrength)
        {
            this.affectsStatName = affectsStatName;
            this.ignoreSkillStrength = ignoreSkillStrength;
        }

        public virtual object ProcessStat(Stat stat, object value, float strength) {
            return value;
        }

        /// <summary>
        /// <para>
        /// This PrettyPrint method will return formalized descriptions of the SkillEffects, that can be used in combination of a language file to ouput human-readable descriptions of your skill effects.
        /// </para>
        /// <para>
        /// Use this for example to show descriptions of the skills in your Skillsystem user interface.
        /// </para>
        /// </summary>
        public abstract string PrettyPrint();
    }
}
