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
        /// a list of all effects the skill has
        /// </summary>
        public List<SkillEffect> Effects = new List<SkillEffect>();

        public object ProcessStat(Stat stat, object value, float strength, StatMachine statMachine) {
            foreach (SkillEffect effect in Effects)
            {
                if (effect.affectsStatName.Equals(stat.Name))
                {
                    value = effect.ProcessStat(stat, value, effect.ignoreSkillStrength ? 1f : strength, statMachine);
                }
            }
            return value;
        }

        public Skill(string Name, params SkillEffect[] InitialEffects) : base(Name) {
            AddEffects(InitialEffects);
        }

        public Skill AddEffect(SkillEffect newEffect) {
            Effects.Add(newEffect);
            return this;
        }

        public Skill AddEffects(params SkillEffect[] newEffects)
        {
            Effects.AddRange(newEffects);
            return this;
        }

        public Skill RemoveEffect(int atIndex)
        {
            if (Effects.Count > atIndex)
            {
                Effects.RemoveAt(atIndex);
            }
            else {
                Debug.LogError("Couldn't remove effect at " + atIndex + " because the Skill only has " + Effects.Count + " effects.");
            }
            return this;
        }

        public string PrettyPrint() {
            string result = "Skill|name:" + Name + "|content:";
            foreach (SkillEffect effect in Effects)
            {
                result += "(" + effect.PrettyPrint() + ")";
            }
            return result + ";";
        }
    }

}
