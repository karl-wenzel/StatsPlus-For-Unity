using UnityEngine;

namespace StatsPlus
{
    public class FactBool : Fact
    {
        public bool value;

        public FactBool(string Identifier, bool value) : base(Identifier)
        {
            this.value = value;
        }

        public FactBool SetValue(bool value)
        {
            this.value = value;
            return this;
        }

        public bool IsTrue()
        {
            return value;
        }

        /// <summary>
        /// inverts the current boolean value
        /// </summary>
        public FactBool Flip()
        {
            value = !value;
            return this;
        }

        public override object getValueAsObject()
        {
            return value;
        }

        /// <summary>
        /// Returns true if the value is equal to the compared value.
        /// </summary>
        /// <param name="other">The fact to compare to</param>
        public override bool Equals(Fact other)
        {
            if (other is FactBool)
            {
                return value == ((FactBool)other).value;
            }
            else
            {
                Debug.LogWarning("You try comparing FactBool and " + other.GetType() + ". This will always return false.");
                return false;
            }
        }

        /// <summary>
        /// Returns true if the value is false and the compared value is true.
        /// </summary>
        /// <param name="other">The fact to compare to</param>
        public override bool Greater(Fact other)
        {
            if (other is FactBool)
            {
                return (!value) && ((FactBool)other).value;
            }
            else
            {
                Debug.LogWarning("You try comparing FactBool and " + other.GetType() + ". This will always return false.");
                return false;
            }
        }

        /// <summary>
        /// Returns true if the value is true and the compared value is false.
        /// </summary>
        /// <param name="other">The fact to compare to</param>
        public override bool Less(Fact other)
        {
            if (other is FactBool)
            {
                return (value) && !((FactBool)other).value;
            }
            else
            {
                Debug.LogWarning("You try comparing FactBool and " + other.GetType() + ". This will always return false.");
                return false;
            }
        }
    }
}
