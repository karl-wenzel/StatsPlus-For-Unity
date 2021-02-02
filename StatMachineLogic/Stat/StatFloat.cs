using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StatsPlus;

namespace StatsPlus
{
    /// <summary>
    /// A StatFloat is a special Stat, which stores a float.
    /// </summary>
    public class StatFloat : Stat
    {
        public float Value = 0f;

        public override object GetValueAsObject()
        {
            return Value;
        }

        public override void OverwriteValue(object newValue)
        {
            Value = (float)newValue;
        }

        public StatFloat(string Name, float value) : base(Name)
        {
            Value = value;
        }
    }

}
