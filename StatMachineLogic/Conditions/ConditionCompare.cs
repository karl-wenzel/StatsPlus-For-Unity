
namespace StatsPlus
{
    /// <summary>
    /// A condition that evaluates if a fact meets the specified condition. The ConditionCompare class supports the standard comparison operators equals, lessthan, lessequals, greaterthen and greaterequals.
    /// </summary>
    public class ConditionCompare :Condition
    {
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
        public ConditionCompare(Fact compareTo, CompareMethod method){
            this.compareTo = compareTo;
            this.method = method;
        }

        public override bool IsTrueForFact(Fact fact) {
            switch (method)
            {
                case CompareMethod.Equals:
                    return fact.Equals(compareTo);
                case CompareMethod.LessThan:
                    return fact.Less(compareTo);
                case CompareMethod.LessEquals:
                    return fact.LessEquals(compareTo);
                case CompareMethod.GreaterThan:
                    return fact.Greater(compareTo);
                case CompareMethod.GreaterEquals:
                    return fact.GreaterEquals(compareTo);
                default:
                    return false;
            }
        }
    }
}
