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
        /// returns true if the first value and the compared value are equal
        /// </summary>
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
        /// returns true if the first value is false and the compared value is true
        /// </summary>
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
        /// returns true if the first value is true and the compared value is false
        /// </summary>
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
