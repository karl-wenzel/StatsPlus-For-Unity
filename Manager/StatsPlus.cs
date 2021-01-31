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

        public Dictionary<StatEntity, StatMachine> StatMachines;

        /// <summary>
        /// creates a new StatMachine and registers it in the system. It can be found again using its Owner.
        /// </summary>
        /// <param name="Owner"></param>
        /// <returns>true if the creation of the statMachine was successfull, false if this owner already controls a stat machine.</returns>
        public StatMachine CreateStatMachine(StatEntity Owner, Statset Statset) {
            if (!StatMachines.ContainsKey(Owner)) {
                StatMachine newMachine = new StatMachine(Owner, Statset); //TODO: replace null pointer
                StatMachines.Add(Owner, newMachine);
                return newMachine;
            }
            Debug.LogError("Only one stat machine per owner allowed: <b>" + Owner.ToString() + "</b> already controls a stat machine.");
            return default;
        }

        public StatMachine GetStatMachine(StatEntity Owner) {
            if (StatMachines.ContainsKey(Owner))
            {
                return StatMachines[Owner];
            }
            else return default;
        }
    }

}
