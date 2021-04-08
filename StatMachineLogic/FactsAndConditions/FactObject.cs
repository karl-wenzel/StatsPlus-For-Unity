﻿using UnityEngine;

namespace StatsPlus
{
    public class FactObject : Fact
    {
        public object value;

        public FactObject(string Identifier, object value) : base(Identifier)
        {
            this.value = value;
        }

        public FactObject SetValue(bool value)
        {
            this.value = value;
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
            if (other is FactObject)
            {
                return value == ((FactObject)other).value;
            }
            else
            {
                Debug.LogWarning("You try comparing FactObject and " + other.GetType() + ". This will always return false.");
                return false;
            }
        }

        /// <summary>
        /// Always returns false
        /// </summary>
        public override bool Greater(Fact other)
        {
            return false;
        }

        /// <summary>
        /// Always returns false
        /// </summary>
        public override bool Less(Fact other)
        {
            return false;
        }
    }
}
