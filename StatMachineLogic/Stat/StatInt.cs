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
    }

}
