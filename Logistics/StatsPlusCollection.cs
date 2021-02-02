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
    public class StatsPlusCollection<T> where T : Named
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
            Debug.LogError("Couldn't find " + IdName + " in collection.");
            return default;
        }


        /// <summary>
        /// Adds a new value to this Collection while checking, if its already contained in this Collection. Logs a friendly error if already contained.
        /// </summary>
        /// <param name="value">The Value to add.</param>
        public StatsPlusCollection<T> AddValue(T value)
        {
            if (!Data.ContainsKey(value.Name))
            {
                Data.Add(value.Name, value);
            }
            else
            {
                Debug.LogError("The Collection <b>" + Name + "</b> already contains an Object named <b>" + value.Name + "</b>.");
            }
            return this;
        }

        /// <summary>
        /// Removes a Value from the collection using its name. Logs a friendly error if this key is not present.
        /// </summary>
        /// <param name="IdName">The Name of this named object.</param>
        public StatsPlusCollection<T> RemoveValueByName(string IdName)
        {
            if (Data.ContainsKey(IdName))
            {
                Data.Remove(IdName);
            }
            else
            {
                Debug.LogError("The IdName: " + IdName + " could not be found in the collection " + Name + ".");
            }
            return this;
        }

        /// <summary>
        /// Removes all entries from the collection.
        /// </summary>
        /// <returns>A reference to the Collection</returns>
        public StatsPlusCollection<T> Clear()
        {
            Data.Clear();
            return this;
        }

        public override string ToString()
        {
            string toString = "Collection with " + Data.Count + " entries: ";
            foreach (string key in Data.Keys)
            {
                toString += key + " ";
            }
            return toString;
        }
    }

}
