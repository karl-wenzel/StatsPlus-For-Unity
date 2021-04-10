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

        bool doModulo;
        int moduloValue;

        /// <summary>
        /// Call this, to set up modulo application.
        /// </summary>
        /// <param name="value">The value that should be used for the modulo operation.</param>
        public FactInt DoModulo(int value)
        {
            doModulo = true;
            moduloValue = value;
            ApplyModulo();
            return this;
        }

        /// <summary>
        /// Deactivates modulo application
        /// </summary>
        public FactInt ResetModulo()
        {
            doModulo = false;
            return this;
        }

        void ApplyModulo() {
            if (doModulo)
            {
                value = value % moduloValue;
            }
        }

        public FactInt SetValue(int value)
        {
            this.value = value;
            ApplyModulo();
            return this;
        }

        public FactInt Add(int value)
        {
            this.value += value;
            ApplyModulo();
            return this;
        }

        public FactInt Substract(int value)
        {
            this.value -= value;
            ApplyModulo();
            return this;
        }

        public FactInt Multiply(int factor)
        {
            value *= factor;
            ApplyModulo();
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
            if (other is FactInt myOther)
            {
                return (int)getValueAsObject() == (int)myOther.getValueAsObject();
            }
            else
            {
                Debug.LogWarning("You try comparing FactInt and " + other.GetType() + ". This will always return false.");
                return false;
            }
        }

        /// <summary>
        /// Returns true if the value is greater than the compared value.
        /// </summary>
        /// <param name="other">The fact to compare to</param>
        public override bool Greater(Fact other)
        {
            if (other is FactInt myOther)
            {
                return (int)getValueAsObject() > (int)myOther.getValueAsObject();
            }
            else
            {
                Debug.LogWarning("You try comparing FactInt and " + other.GetType() + ". This will always return false.");
                return false;
            }
        }

        /// <summary>
        /// Returns true if the value is greater than or equal to the compared value.
        /// </summary>
        /// <param name="other">The fact to compare to</param>
        public override bool GreaterEquals(Fact other)
        {
            if (other is FactInt myOther)
            {
                return (int)getValueAsObject() >= (int)myOther.getValueAsObject();
            }
            else
            {
                Debug.LogWarning("You try comparing FactInt and " + other.GetType() + ". This will always return false.");
                return false;
            }
        }

        /// <summary>
        /// Returns true if the value is less than the compared value.
        /// </summary>
        /// <param name="other">The fact to compare to</param>
        public override bool Less(Fact other)
        {
            if (other is FactInt myOther)
            {
                return (int)getValueAsObject() < (int)myOther.getValueAsObject();
            }
            else
            {
                Debug.LogWarning("You try comparing FactInt and " + other.GetType() + ". This will always return false.");
                return false;
            }
        }

        /// <summary>
        /// Returns true if the value is less than or equal to the compared value.
        /// </summary>
        /// <param name="other">The fact to compare to</param>
        public override bool LessEquals(Fact other)
        {
            if (other is FactInt myOther)
            {
                return (int)getValueAsObject() <= (int)myOther.getValueAsObject();
            }
            else
            {
                Debug.LogWarning("You try comparing FactInt and " + other.GetType() + ". This will always return false.");
                return false;
            }
        }

    }
}
