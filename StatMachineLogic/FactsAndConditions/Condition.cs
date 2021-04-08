
namespace StatsPlus
{
    /// <summary>
    /// A condition holds information about how to evaluate if a fact meets the requirements. You may add conditions to Skills and SkillEffects.
    /// </summary>
    public abstract class Condition
    {
        string factIdentifier;

        /// <summary>
        /// Creates a new condition.
        /// </summary>
        /// <param name="factIdentifier">The identifier of the fact this condition should search for evaluation.</param>
        public Condition(string factIdentifier) {
            this.factIdentifier = factIdentifier;
        }

        public abstract bool IsTrueForFact(Fact fact);

        public bool SelfEvaluate(StatMachine statMachineLink) {
            Fact searchResultFact = statMachineLink.FactStorage.GetValue(factIdentifier);
            return IsTrueForFact(searchResultFact);
        }
    }
}
