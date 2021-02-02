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
                StatMachine newMachine = new StatMachine(Owner, Statset);
                StatMachines.Add(Owner, newMachine);
                return newMachine;
            }
            Debug.LogError("Only one stat machine per owner allowed: <b>" + Owner.ToString() + "</b> already controls a stat machine.");
            return default;
        }

        /// <summary>
        /// returns a reference to a StatMachine owned by a StatEntity.
        /// </summary>
        /// <param name="Owner">The owner of the StatMachine.</param>
        /// <returns>A reference to the StatMachine or null of no StatMachine was found.</returns>
        public StatMachine GetStatMachine(StatEntity Owner) {
            if (StatMachines.ContainsKey(Owner))
            {
                return StatMachines[Owner];
            }
            else
            {
                Debug.LogError("Couldn't find StatMachine for Owner " + Owner.ToString() + ". Mayber you need to create one or the owner is misspelled?");
                return null;
            }
        }
    }

}
