using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StatsPlus;

namespace StatsPlus
{
    /// <summary>
    /// A skill can be bought and will possibly change some stats and/or behaviour.
    /// </summary>
    public class Skill : Named, Printable
    {
        /// <summary>
        /// A list of all effects the skill has.
        /// </summary>
        List<SkillEffect> Effects = new List<SkillEffect>();

        /// <summary>
        /// A list of affected stats to quickly discard stats that are not affected by this skill
        /// </summary>
        List<string> AffectedStats = new List<string>();

        /// <summary>
        /// A list of all conditions. If one of them is not true, the skill will not apply.
        /// </summary>
        List<Condition> Conditions = new List<Condition>();


        /// <summary>
        /// Processing a stat and wiring it through all the skill effects to return the correct result. Note that if a condition returns false, the SkillEffects will not be applied.
        /// </summary>
        /// <param name="stat">The stat to evaluate.</param>
        /// <param name="value">The initial stat value</param>
        /// <param name="strength">The strength modifier that will be passed to the effects.</param>
        /// <param name="statMachine">A link to the statMachine that ordered the processing.</param>
        /// <returns>The value of the stat after all skill effects have been applied.</returns>
        public object ProcessStat(Stat stat, object value, float strength, StatMachine statMachine)
        {
            if (!AffectedStats.Contains(stat.Identifier)) {
                return value;
            }

            //evaluate the conditions in this skill
            foreach (Condition condition in Conditions)
            {
                if (condition.SelfEvaluate(statMachine) == false) return value;
            }

            foreach (SkillEffect effect in Effects)
            {
                if (effect.Identifier.Equals(stat.Identifier))
                {
                    
                    bool AllConditionsTrue = true;

                    //evaluate the conditions in the SkillEffect. If one condition is false, continue with next SkillEffect
                    foreach (Condition condition in effect.Conditions)
                    {
                        if (condition.SelfEvaluate(statMachine) == false)
                        {
                            AllConditionsTrue = false;
                            break;
                        }
                    }

                    if (AllConditionsTrue)
                    {
                        value = effect.ProcessStat(stat, value, effect.ignoreSkillStrength ? 1f : strength, statMachine);
                    }
                }
            }
            return value;
        }

        public Skill(string Name, params SkillEffect[] InitialEffects) : base(Name)
        {
            AddEffects(InitialEffects);
        }

        /// <summary>
        /// Add a condition that must be resolved true for the skill to apply.
        /// </summary>
        /// <param name="Condition">The Condition that should be added</param>
        public Skill AddCondition(Condition Condition)
        {
            Conditions.Add(Condition);
            return this;
        }

        public Skill RemoveCondition(Condition Condition) {
            Conditions.Remove(Condition);
            return this;
        }

        /// <summary>
        /// Add one or more conditions that must be resolved true for the skill to apply.
        /// </summary>
        /// <param name="Condition">The Conditions that should be added</param>
        public Skill AddConditions(params Condition[] Conditions)
        {
            this.Conditions.AddRange(Conditions);
            return this;
        }

        public Skill AddConditionEquals(string factId, object compareTo)
        {
            Conditions.Add(new ConditionEquals(factId, compareTo));
            return this;
        }

        public Skill AddEffect(SkillEffect newEffect)
        {
            Effects.Add(newEffect);
            AffectedStats.Add(newEffect.Identifier);
            return this;
        }

        public Skill AddEffects(params SkillEffect[] newEffects)
        {
            foreach (SkillEffect effect in newEffects)
            {
                AddEffect(effect);
            }
            return this;
        }

        public Skill RemoveEffect(int atIndex)
        {
            if (Effects.Count > atIndex)
            {
                AffectedStats.Remove(Effects[atIndex].Identifier);
                Effects.RemoveAt(atIndex);
            }
            else
            {
                Debug.LogError("Couldn't remove effect at " + atIndex + " because the Skill only has " + Effects.Count + " effects.");
            }
            return this;
        }

        public Skill RemoveEffect(SkillEffect effect) {
            AffectedStats.Remove(effect.Identifier);
            Effects.Remove(effect);
            return this;
        }

        public string PrettyPrint()
        {
            string result = "Skill|name:" + Identifier + "|content:";
            foreach (SkillEffect effect in Effects)
            {
                result += "(" + effect.PrettyPrint() + ")";
            }
            return result + ";";
        }
    }

}
