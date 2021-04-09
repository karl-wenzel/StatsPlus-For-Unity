
namespace StatsPlus
{
    public abstract class Fact : Named
    {
        public Fact(string Identifier) : base(Identifier)
        {
        }

        public abstract object getValueAsObject();

        public abstract bool Equals(Fact other);
        public abstract bool Greater(Fact other);
        public abstract bool Less(Fact other);

        /// <summary>
        /// returns true if the first value is greater than or equal to the compared value.
        /// </summary>
        public bool GreaterEquals(Fact other) {
            return Greater(other) || Equals(other);
        }

        /// <summary>
        /// returns true if the first value is less than or equal to the compared value.
        /// </summary>
        public bool LessEquals(Fact other) {
            return Less(other) || Equals(other);
        }
    }
}
