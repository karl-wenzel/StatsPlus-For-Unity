
namespace StatsPlus
{
    /// <summary>
    /// A condition that returns true if the value of the fact exactly equals the specified value
    /// </summary>
    public class ConditionEquals :Condition
    {
        public ConditionEquals(string identifier, object compareTo) {
            this.compareTo = new FactObject(identifier, compareTo);
        }

        public ConditionEquals(FactObject compareTo)
        {
            this.compareTo = compareTo;
        }

        public override bool IsTrueForFact(Fact fact) {
            return fact.getValueAsObject().Equals(compareTo);
        }
    }
}
