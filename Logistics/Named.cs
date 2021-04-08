using System;
using StatsPlus;

namespace StatsPlus
{
    public abstract class Named
    {
        /// <summary>
        /// the internal name of  this object
        /// </summary>
        public string Identifier;

        protected Named(string name)
        {
            Identifier = name ?? throw new ArgumentNullException(nameof(name));
        }

        public override string ToString()
        {
            return Identifier;
        }
    }
}
