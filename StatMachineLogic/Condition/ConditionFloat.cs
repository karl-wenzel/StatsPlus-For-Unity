
namespace StatsPlus
{
    public class ConditionFloat : Condition
    {
        public float value;

        public ConditionFloat(string ConditionIdentifier, float value) : base(ConditionIdentifier)
        {
            this.ConditionIdentifier = ConditionIdentifier;
            this.value = value;
        }

        public ConditionFloat SetValue(float value)
        {
            this.value = value;
            return this;
        }

        public ConditionFloat Add(float value)
        {
            this.value += value;
            return this;
        }

        public ConditionFloat Substract(float value)
        {
            this.value -= value;
            return this;
        }

        public ConditionFloat Multiply(float factor)
        {
            value *= factor;
            return this;
        }

    }
}
