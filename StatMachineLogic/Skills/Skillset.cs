using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StatsPlus;

namespace StatsPlus
{
    /// <summary>
    /// A Skillset contains a collection of skills to quickly save and set them. It could also only contain a single skill.
    /// </summary>
    public class Skillset : StatsPlusCollection<Skill>
    {
        public Skillset(string Name, params Skill[] InitialData) : base(Name, InitialData) {}
    }

}
