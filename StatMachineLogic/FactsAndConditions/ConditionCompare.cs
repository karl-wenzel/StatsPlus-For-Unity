
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

        bool doModulo;
        float moduloValue;

        /// <summary>
        /// call this, to set up modulo application to the fact value.
        /// </summary>
        /// <param name="value">The value that should be used for the modulo operation.</param>
        public Condition DoModulo(float value) {
            doModulo = true;
            moduloValue = value;
            return this;
        }

        /// <summary>
        /// Deactivates modulo application
        /// </summary>
        public Condition ResetModulo() {
            doModulo = false;
            return this;
        }

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
            double factValue = (double)fact.getValueAsObject();
            if (doModulo) {
                factValue = factValue % moduloValue;
            }
            switch (method)
            {
                case CompareMethod.Equals:
                    return factValue == (double)compareTo;
                case CompareMethod.LessThan:
                    return factValue < (double)compareTo;
                case CompareMethod.LessEquals:
                    return factValue <= (double)compareTo;
                case CompareMethod.GreaterThan:
                    return factValue > (double)compareTo;
                case CompareMethod.GreaterEquals:
                    return factValue >= (double)compareTo;
                default:
                    return false;
            }
        }
    }
}
