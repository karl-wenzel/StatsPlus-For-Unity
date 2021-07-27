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

        public virtual FactFloat Add(float value)
        {
            this.value += value;
            return this;
        }

        public virtual FactFloat Substract(float value)
        {
            this.value -= value;
            return this;
        }

        public virtual FactFloat Multiply(float factor)
        {
            value *= factor;
            return this;
        }

        public override object getValueAsObject()
        {
            return value;
        }

        /// <summary>
        /// Returns true if the value and the compared value are equal.
        /// </summary>
        /// <param name="other">The fact to compare to</param>
        public override bool Equals(Fact other)
        {
            if (other is FactFloat)
            {
                return (float)getValueAsObject() == (float)((FactFloat)other).getValueAsObject();
            }
            else
            {
                Debug.LogWarning("You try comparing FactFloat and " + other.GetType() + ". This will always return false.");
                return false;
            }
        }

        /// <summary>
        /// Returns true if the value is greater than the compared value.
        /// </summary>
        /// <param name="other">The fact to compare to</param>
        public override bool Greater(Fact other)
        {
            if (other is FactFloat)
            {
                return (float)getValueAsObject() > (float)((FactFloat)other).getValueAsObject();
            }
            else
            {
                Debug.LogWarning("You try comparing FactFloat and " + other.GetType() + ". This will always return false.");
                return false;
            }
        }

        /// <summary>
        /// Returns true if the value is less than the compared value.
        /// </summary>
        /// <param name="other">The fact to compare to</param>
        public override bool Less(Fact other)
        {
            if (other is FactFloat)
            {
                return (float)getValueAsObject() < (float)((FactFloat)other).getValueAsObject();
            }
            else
            {
                Debug.LogWarning("You try comparing FactFloat and " + other.GetType() + ". This will always return false.");
                return false;
            }
        }

    }
}
