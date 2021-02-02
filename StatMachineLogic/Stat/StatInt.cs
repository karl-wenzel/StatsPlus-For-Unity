using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StatsPlus;

namespace StatsPlus
{
    /// <summary>
    /// A StatInt is a special Stat, which stores an integer.
    /// </summary>
    public class StatInt : Stat
    {
        public int Value = 0;

        public override object GetValueAsObject()
        {
            return Value;
        }

        public override void OverwriteValue(object newValue)
        {
            Value = (int)newValue;
        }

        public StatInt(string Name, int value) : base(Name)
        {
            Value = value;
        }
    }

}
