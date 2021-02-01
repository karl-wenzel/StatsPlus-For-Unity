using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StatsPlus;

namespace StatsPlus
{
    /// <summary>
    /// A reusable Collection code
    /// </summary>
    /// <typeparam name="T">Class type which should be stored in the Collection</typeparam>
    public class StatsPlusCollection<T> where T:Named
    {
        public string Name;
        public Dictionary<string, T> Data = new Dictionary<string, T>();

        public StatsPlusCollection(string Name, params T[] SetInitialData)
        {
            this.Name = Name;
            foreach (T value in SetInitialData)
            {
                AddValue(value);
            }
        }

        /// <summary>
        /// Returns a value from this collection, identified by its name.
        /// </summary>
        /// <param name="IdName">The Name of this named object.</param>
        /// <returns></returns>
        public T GetValue(string IdName)
        {
            if (Data.ContainsKey(IdName))
            {
                return Data[IdName];
            }
            return default;
        }


        /// <summary>
        /// Adds a new value to this Collection while checking, if its already contained in this Collection. Logs a friendly error if already contained.
        /// </summary>
        /// <param name="value">The Value to add.</param>
        public void AddValue(T value)
        {
            if (!Data.ContainsKey(value.Name))
            {
                Data.Add(value.Name, value);
            }
            else
            {
                Debug.LogError("The Collection <b>" + Name + "</b> already contains an Object named <b>" + value.Name + "</b>.");
            }
        }

        /// <summary>
        /// Removes a Value from the collection using its name. Logs a friendly error if this key is not present.
        /// </summary>
        /// <param name="IdName">The Name of this named object.</param>
        public void RemoveValueByName(string IdName) {
            if (Data.ContainsKey(IdName))
            {
                Data.Remove(IdName);
            }
            else {
                Debug.LogError("The IdName: " + IdName + " could not be found in the collection " + Name + ".");
            }
        }
    }

}
