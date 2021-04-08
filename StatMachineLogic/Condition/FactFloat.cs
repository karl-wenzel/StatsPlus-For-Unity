
namespace StatsPlus
{
    public class FactFloat : Fact
    {
        public float value;

        public FactFloat(string Identifier, float value) : base(Identifier)
        {
            this.value = value;
        }

        public FactFloat SetValue(float value)
        {
            this.value = value;
            return this;
        }

        public FactFloat Add(float value)
        {
            this.value += value;
            return this;
        }

        public FactFloat Substract(float value)
        {
            this.value -= value;
            return this;
        }

        public FactFloat Multiply(float factor)
        {
            value *= factor;
            return this;
        }

    }
}
