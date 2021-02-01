using System;
using StatsPlus;

namespace StatsPlus
{
    public abstract class Named
    {
        /// <summary>
        /// the internal name of  this object
        /// </summary>
        public string Name;

        protected Named(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}
