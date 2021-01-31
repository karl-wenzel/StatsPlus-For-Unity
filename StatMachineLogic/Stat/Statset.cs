using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StatsPlus;

namespace StatsPlus
{
    /// <summary>
    /// A Statset is a collection of stats with methods to extract information from it.
    /// </summary>
    public abstract class Statset : StatsPlusCollection<Stat>
    {
        public Statset(string Name, params Stat[] InitialData) : base(Name, InitialData) { }
    }

}
