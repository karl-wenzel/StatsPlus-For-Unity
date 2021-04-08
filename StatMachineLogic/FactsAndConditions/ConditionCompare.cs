
namespace StatsPlus
{
    /// <summary>
    /// A condition that evaluates if a fact meets the specified condition. The ConditionCompare class supports the standard comparison operators equals, lessthan, lessequals, greaterthen and greaterequals.
    /// </summary>
    public class ConditionCompare :Condition
    {
        object compareTo;

        public enum CompareMethod
        {
            Equals, LessThan, LessEquals, GreaterThan, GreaterEquals
        }

        CompareMethod method;

        /// <summary>
        /// Create a new instance of ConditionCompare.
        /// </summary>
        /// <param name="compareTo">The value that will be compared with facts.</param>
        /// <param name="method">The CompareMethod to use. It will always compare the fact with the value specified in this instance. So, for example, if the method is LessThan, it will evaluate fact < compareTo.</param>
        public ConditionCompare(string factIdentifier, object compareTo, CompareMethod method) : base(factIdentifier) {
            this.compareTo = compareTo;
            this.method = method;
        }

        public override bool IsTrueForFact(Fact fact) {
            switch (method)
            {
                case CompareMethod.Equals:
                    return (compareTo.Equals(fact.getValueAsObject()));
                case CompareMethod.LessThan:
                    return (double)fact.getValueAsObject() < (double)compareTo;
                case CompareMethod.LessEquals:
                    return (double)fact.getValueAsObject() <= (double)compareTo;
                case CompareMethod.GreaterThan:
                    return (double)fact.getValueAsObject() > (double)compareTo;
                case CompareMethod.GreaterEquals:
                    return (double)fact.getValueAsObject() >= (double)compareTo;
                default:
                    return false;
            }
        }
    }
}
