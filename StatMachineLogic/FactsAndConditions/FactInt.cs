using UnityEngine;

namespace StatsPlus
{
    public class FactInt : Fact
    {
        public int value;

        public FactInt(string Identifier, int value) : base(Identifier)
        {
            this.value = value;
        }

        public FactInt SetValue(int value)
        {
            this.value = value;
            return this;
        }

        public FactInt Add(int value)
        {
            this.value += value;
            return this;
        }

        public FactInt Substract(int value)
        {
            this.value -= value;
            return this;
        }

        public FactInt Multiply(int factor)
        {
            value *= factor;
            return this;
        }

        public override object getValueAsObject()
        {
            return (double)value;
        }

        /// <summary>
        /// returns true if the first value and the compared value are equal
        /// </summary>
        public override bool Equals(Fact other)
        {
            if (other is FactInt)
            {
                return value == ((FactInt)other).value;
            }
            else
            {
                Debug.LogWarning("You try comparing FactInt and " + other.GetType() + ". This will always return false.");
                return false;
            }
        }

        /// <summary>
        /// returns true if the first value is greater than the compared value
        /// </summary>
        public override bool Greater(Fact other)
        {
            if (other is FactInt)
            {
                return value > ((FactInt)other).value;
            }
            else
            {
                Debug.LogWarning("You try comparing FactInt and " + other.GetType() + ". This will always return false.");
                return false;
            }
        }

        /// <summary>
        /// returns true if the first value is less than the compared value
        /// </summary>
        public override bool Less(Fact other)
        {
            if (other is FactInt)
            {
                return value < ((FactInt)other).value;
            }
            else
            {
                Debug.LogWarning("You try comparing FactInt and " + other.GetType() + ". This will always return false.");
                return false;
            }
        }

    }
}
