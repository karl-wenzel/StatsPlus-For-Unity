using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StatsPlus;

namespace StatsPlus
{
    /// <summary>
    /// A skill can be bought and will possibly change some stats and/or behaviour.
    /// </summary>
    public class Skill : Named
    {
        /// <summary>
        /// a list of all effects the skill has
        /// </summary>
        public List<SkillEffect> Effects = new List<SkillEffect>();

        public object ProcessStat(Stat stat, object value) {
            foreach (SkillEffect effect in Effects)
            {
                if (effect.affectsStatName.Equals(stat.Name))
                {
                    value = effect.ProcessStat(stat, value);
                }
            }
            return value;
        }
    }

}
