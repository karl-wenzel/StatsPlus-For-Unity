using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StatsPlus;

namespace StatsPlus
{
    /// <summary>
    /// A StatBoolean is a special Stat, which stores a boolean.
    /// </summary>
    public class StatBool : Stat
    {
        public bool Value = false;

        public override object GetValueAsObject()
        {
            return Value;
        }

        public override void OverwriteValue(object newValue)
        {
            Value = (bool)newValue;
        }

        public StatBool(string Name, bool value) : base(Name)
        {
            Value = value;
        }
    }

}
