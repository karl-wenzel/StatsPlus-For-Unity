using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StatsPlus;

namespace StatsPlus
{
    /// <summary>
    /// This is the central class of the StatsPlus-system.
    /// </summary>
    public class StatsPlus
    {
        /// <summary>
        /// use this reference to do anything
        /// </summary>
        public static StatsPlus Instance;

        /// <summary>
        /// creates a new StatMachine and registers it in the system. It can be found again using its Owner.
        /// </summary>
        /// <param name="Owner"></param>
        /// <returns>true if the creation of the statMachine was successfull</returns>
        public bool CreateStatMachine(StatEntity Owner) {
            return true;
        }

    }

}
