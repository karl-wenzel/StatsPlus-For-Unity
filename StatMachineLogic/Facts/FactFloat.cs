using UnityEngine;

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

        public override object getValueAsObject()
        {
            return value;
        }

        /// <summary>
        /// returns true if the first value and the compared value are equal
        /// </summary>
        public override bool Equals(Fact other)
        {
            if (other is FactFloat)
            {
                return value == ((FactFloat)other).value;
            }
            else
            {
                Debug.LogWarning("You try comparing FactFloat and " + other.GetType() + ". This will always return false.");
                return false;
            }
        }

        /// <summary>
        /// returns true if the first value is greater than the compared value
        /// </summary>
        public override bool Greater(Fact other)
        {
            if (other is FactFloat)
            {
                return value > ((FactFloat)other).value;
            }
            else
            {
                Debug.LogWarning("You try comparing FactFloat and " + other.GetType() + ". This will always return false.");
                return false;
            }
        }

        /// <summary>
        /// returns true if the first value is less than the compared value
        /// </summary>
        public override bool Less(Fact other)
        {
            if (other is FactFloat)
            {
                return value < ((FactFloat)other).value;
            }
            else
            {
                Debug.LogWarning("You try comparing FactFloat and " + other.GetType() + ". This will always return false.");
                return false;
            }
        }

    }
}
