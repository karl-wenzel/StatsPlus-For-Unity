using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StatsPlus;

namespace StatsPlus
{
    /// <summary>
    /// <para> A Skillset contains a collection of skills to quickly save and set them. It could also only contain a single skill. </para>
    /// <para> If you change this Skillset after creation, all StatMachines that use this skillset will change their behaviour accordingly. </para>
    /// </summary>
    public class Skillset : StatsPlusCollection<Skill>
    {
        public Skillset(string Name, params Skill[] InitialData) : base(Name, InitialData) {}

        public object ProcessStat(Stat stat, object value, float strength) {
            foreach (Skill skill in Data.Values)
            {
                value = skill.ProcessStat(stat, value, strength);
            }
            return value;
        }
    }

}
