using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StatsPlus;

namespace StatsPlus
{
    /// <summary>
    /// A Stat is a parameter of an ingame mechanic, for example a damage modifier.
    /// </summary>
    public abstract class Stat : Named
    {
        protected Stat(string Name) : base(Name) {}

        public abstract object GetValueAsObject();
    }

}
