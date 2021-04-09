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

        /// <summary>
        /// A list of conditions. If one of them is not true, the skill effect will not apply.
        /// </summary>
        public List<Condition> Conditions = new List<Condition>();

        public SkillEffect(string affectsStatName, bool ignoreSkillStrength, params Condition[] Conditions)
        {
            this.affectsStatName = affectsStatName;
            this.ignoreSkillStrength = ignoreSkillStrength;
            this.Conditions.AddRange(Conditions);
        }

        public virtual object ProcessStat(Stat stat, object value, float strength, StatMachine statMachine) {
            return value;
        }

        /// <summary>
        /// Add a condition that must be resolved true for the skill effect to apply.
        /// </summary>
        /// <param name="Condition">The Condition that should be added</param>
        public SkillEffect AddCondition(Condition Condition) {
            Conditions.Add(Condition);
            return this;
        }

        /// <summary>
        /// Add one or more conditions that must be resolved true for the skill effect to apply.
        /// </summary>
        /// <param name="Condition">The Conditions that should be added</param>
        public SkillEffect AddConditions(params Condition[] Conditions)
        {
            this.Conditions.AddRange(Conditions);
            return this;
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
