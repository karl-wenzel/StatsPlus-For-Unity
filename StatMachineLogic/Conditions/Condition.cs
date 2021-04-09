using UnityEngine;

namespace StatsPlus
{
    /// <summary>
    /// A condition holds information about how to evaluate if a fact meets the requirements. You may add conditions to Skills and SkillEffects.
    /// </summary>
    public abstract class Condition
    {
        public Fact compareTo;

        public abstract bool IsTrueForFact(Fact fact);

        /// <summary>
        /// Tries to evaluate the condition. If the fact this should compare to isn't found, returns false.
        /// </summary>
        /// <param name="statMachineLink">This stat machine will be searched for a matching fact with the same identifier.</param>
        public bool SelfEvaluate(StatMachine statMachineLink) {
            Fact searchResultFact = default;
            if (statMachineLink.FactStorage.HasValue(compareTo.Identifier, out searchResultFact)) {
                return IsTrueForFact(searchResultFact);
            }
            else {
                return false;
            }
        }
    }
}
