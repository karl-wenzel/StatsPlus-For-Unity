using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StatsPlus;

namespace StatsPlus
{
    /// <summary>
    /// A StatMachine is directly responsible for one specific stat entity (e.g. a player). It returns information regarding the Stats of this entity.
    /// </summary>
    public class StatMachine
    {
        public StatEntity Owner;
        public Statset Statset;

        public StatMachine(StatEntity owner, Statset statset)
        {
            Owner = owner;
            Statset = statset;
        }

        public float GetStatValue(string StatName) {
            Stat Stat = Statset.GetValue(StatName);
            if (Stat is StatFloat)
            {
                return ((StatFloat)Stat).Value;
            }
            else {
                Debug.LogError("The requested Stat <b>" + StatName + "</b> does not contain a float.");
            }
            return 0f;
        }
    }
}
