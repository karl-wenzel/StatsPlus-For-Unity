
namespace StatsPlus
{
    /// <summary>
    /// A condition that returns true if the value of the fact exactly equals the specified value
    /// </summary>
    public class ConditionEquals :Condition
    {
        object compareTo;

        public ConditionEquals(string factIdentifier, object compareTo) : base(factIdentifier) {
            this.compareTo = compareTo;
        }

        public override bool IsTrueForFact(Fact fact) {
            return fact.getValueAsObject().Equals(compareTo);
        }
    }
}
