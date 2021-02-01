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

        public StatBool(bool value, string Name) : base(Name)
        {
            Value = value;
        }
    }

}
