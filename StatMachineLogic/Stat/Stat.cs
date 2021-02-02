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

        /// <summary>
        /// Returns the Stat value as object.
        /// </summary>
        /// <returns>The Stat value.</returns>
        public abstract object GetValueAsObject();

        /// <summary>
        /// Overwrites the current value of the stat. Use with caution.
        /// </summary>
        /// <param name="newValue">The new value of the stat.</param>
        public abstract void OverwriteValue(object newValue);
    }

}
