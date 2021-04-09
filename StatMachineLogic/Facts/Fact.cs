
namespace StatsPlus
{
    /// <summary>
    /// A Fact holds an information, for example a boolean or an integer. It can easily be compared with other facts using conditions, no matter the contents of the fact.
    /// </summary>
    public abstract class Fact : Named
    {
        public Fact(string Identifier) : base(Identifier)
        {
        }

        /// <summary>
        /// returns the content of the fact as an object
        /// </summary>
        public abstract object getValueAsObject();

        /// <summary>
        /// Returns true if the facts content is equal to another facts content.
        /// </summary>
        /// <param name="other">The fact to compare to.</param>
        /// <returns></returns>
        public abstract bool Equals(Fact other);

        /// <summary>
        /// Returns true if the facts content is greater than another facts content.
        /// </summary>
        /// <param name="other">The fact to compare to</param>
        public abstract bool Greater(Fact other);

        /// <summary>
        /// Returns true if the facts content is less than another facts content.
        /// </summary>
        /// <param name="other">The fact to compare to</param>
        public abstract bool Less(Fact other);

        /// <summary>
        /// Returns true if the facts content is greater than or equal to another facts content.
        /// </summary>
        /// <param name="other">The fact to compare to</param>
        public bool GreaterEquals(Fact other) {
            return Greater(other) || Equals(other);
        }

        /// <summary>
        /// Returns true if the facts content is less than or equal to another facts content.
        /// </summary>
        /// <param name="other">The fact to compare to</param>
        public bool LessEquals(Fact other) {
            return Less(other) || Equals(other);
        }
    }
}
