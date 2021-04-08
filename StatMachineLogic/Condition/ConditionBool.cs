
namespace StatsPlus
{
    public class ConditionBool : Condition
    {
        public bool value;

        public ConditionBool(string ConditionIdentifier, bool value) : base(ConditionIdentifier) {
            this.ConditionIdentifier = ConditionIdentifier;
            this.value = value;
        }

        public ConditionBool SetValue(bool value) {
            this.value = value;
            return this;
        }

        public bool IsTrue() {
            return value;
        }

        /// <summary>
        /// inverts the current boolean value
        /// </summary>
        public ConditionBool Flip() {
            value = !value;
            return this;
        }


    }
}
