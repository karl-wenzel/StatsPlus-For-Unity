﻿using System.Collections;
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
        public List<SkillsetStackEntry> SkillsetStack = new List<SkillsetStackEntry>();
        public int LastRefresh = -1;

        public StatMachine(StatEntity owner, Statset statset)
        {
            Owner = owner;
            Statset = statset;
        }

        /// <summary>
        /// Searches for a requested Stat and overwrites the default value of this Stat with the value calculated after applying the StackEntries passed.
        /// </summary>
        /// <param name="StatName">The name of the Stat to apply to.</param>
        /// <param name="Stack">The SkillsetStackEntries that will be applied to this Stat.</param>
        public void Apply(string StatName, bool AutomaticallyRemove, params SkillsetStackEntry[] Stack)
        {
            Stat ApplyToStat = Statset.GetValue(StatName);
            ApplyToStat.OverwriteValue(EvaluateStat(ApplyToStat, new List<SkillsetStackEntry>(Stack)));
            if (AutomaticallyRemove)
            {
                foreach (SkillsetStackEntry Entry in Stack)
                {
                    SkillsetStack.Remove(Entry);
                }
            }
        }

        /// <summary>
        /// Overwrites all stat with their values calculated after applying the passed StackEntries.
        /// </summary>
        /// <param name="Stack">The SkillsetStackEntries that will be applied to the Statset.</param>
        public void Apply(bool AutomaticallyRemove, params SkillsetStackEntry[] Stack)
        {
            foreach (Stat ApplyToStat in Statset.Data.Values)
            {
                ApplyToStat.OverwriteValue(EvaluateStat(ApplyToStat, new List<SkillsetStackEntry>(Stack)));
            }
            if (AutomaticallyRemove)
            {
                foreach (SkillsetStackEntry Entry in Stack)
                {
                    SkillsetStack.Remove(Entry);
                }
            }
        }

        /// <summary>
        /// Overwrites all stats in the given statset with their values calculated after applying the passed StackEntries.
        /// </summary>
        /// <param name="Statset">The name of the Statset to apply to.</param>
        /// <param name="Stack">The SkillsetStackEntries that will be applied to the Statset.</param>
        public void Apply(Statset statset, bool AutomaticallyRemove, params SkillsetStackEntry[] Stack)
        {
            foreach (Stat ApplyToStat in statset.Data.Values)
            {
                ApplyToStat.OverwriteValue(EvaluateStat(ApplyToStat, new List<SkillsetStackEntry>(Stack)));
            }
            if (AutomaticallyRemove)
            {
                foreach (SkillsetStackEntry Entry in Stack)
                {
                    SkillsetStack.Remove(Entry);
                }
            }
        }

        /// <summary>
        /// Gets the value of a Stat for you, including the effects of all skills.
        /// </summary>
        /// <param name="StatName">The unique name-identifier of the Stat.</param>
        /// <returns>The evaluated Stat or 0 if the Stat could not be evaluated</returns>
        public float GetStatValueFloat(string StatName)
        {
            Stat Stat = Statset.GetValue(StatName);
            if (Stat is StatFloat)
            {
                return (float)EvaluateStat(Stat, SkillsetStack);
            }
            else
            {
                Debug.LogError("The requested Stat <b>" + StatName + "</b> does not contain a float.");
            }
            return 0f;
        }

        /// <summary>
        /// Gets the value of a Stat for you, including the effects of all skills.
        /// </summary>
        /// <param name="StatName">The unique name-identifier of the Stat.</param>
        /// <returns>The evaluated Stat or false if the Stat could not be evaluated</returns>
        public bool GetStatValueBool(string StatName)
        {
            Stat Stat = Statset.GetValue(StatName);
            if (Stat is StatBool)
            {
                return (bool)EvaluateStat(Stat, SkillsetStack);
            }
            else
            {
                Debug.LogError("The requested Stat <b>" + StatName + "</b> does not contain a boolean.");
            }
            return false;
        }

        /// <summary>
        /// Gets the value of a Stat for you, including the effects of all skills.
        /// </summary>
        /// <param name="StatName">The unique name-identifier of the Stat.</param>
        /// <returns>The evaluated Stat or 0 if the Stat could not be evaluated</returns>
        public int GetStatValueInt(string StatName)
        {
            Stat Stat = Statset.GetValue(StatName);
            if (Stat is StatInt)
            {
                return (int)EvaluateStat(Stat, SkillsetStack);
            }
            else
            {
                Debug.LogError("The requested Stat <b>" + StatName + "</b> does not contain an integer.");
            }
            return 0;
        }

        /// <summary>
        /// Removes all entries from the SkillsetStack.
        /// </summary>
        public void ClearSkillStack()
        {
            ReorderSkillsetStack(new int[] { }, true);
        }

        /// <summary>
        /// Gets the value of a Stat for you. If you know exactly what Stattype to expect, consider using GetStatValueFloat or such instead.
        /// </summary>
        /// <param name="StatName">The unique name-identifier of the Stat.</param>
        /// <returns>The evaluated Stat</returns>
        public object GetStatValue(string StatName)
        {
            Stat Stat = Statset.GetValue(StatName);
            return EvaluateStat(Stat, SkillsetStack);
        }

        /// <summary>
        /// Moves an Entry to the top of the SkillsetStack
        /// </summary>
        /// <param name="EntryToMove"></param>
        public void MoveStackEntryToTop(SkillsetStackEntry EntryToMove)
        {
            RemoveSkillsetStackEntries(EntryToMove);
            SkillsetStack.Add(EntryToMove);
        }

        /// <summary>
        /// Constructs an array with the length of SkillsetStacks size. You can use this array to pass a modified version to ReorderSkillsetStack.
        /// </summary>
        /// <returns>an array of integers of legnth SkillsetStack.Count, counting up from 0</returns>
        public int[] GetSkillsetStackOrder()
        {
            int[] result = new int[SkillsetStack.Count];
            for (int i = 0; i < SkillsetStack.Count; i++)
            {
                result[i] = i;
            }
            return result;
        }

        /// <summary>
        /// <para>Reorders the skillsetStack. The passed integer-array should have the same length as the original stack and only contain integers that are not bigger than the Stack.Count-1.</para>
        /// <para>You can use this method differently though, for example by taking a smaller list of entries than the length of the additional stack, therefore resulting in less stack entries.</para>
        /// <para>It is not encouraged to use entries twice, except for when setting MakeNewStack to true. Using entries twice without making a new stack will result in unpredictable behaviour.</para>
        /// </summary>
        /// <param name="NewOrder">The new order of the skillsetstack</param>
        /// <param name="MakeNewStack">If this is true, the entries in the stack will be created as though they were new. Note, that this will reset timed entries.</param>
        public void ReorderSkillsetStack(int[] NewOrder, bool MakeNewStack)
        {
            List<SkillsetStackEntry> OriginalStack = new List<SkillsetStackEntry>(SkillsetStack);
            SkillsetStack.Clear();
            foreach (int insertIndex in NewOrder)
            {
                if (insertIndex >= OriginalStack.Count)
                {
                    Debug.LogError("Reordering entry " + NewOrder + " failed. Index bigger than Stack height.");
                }
                else
                {
                    if (MakeNewStack)
                    {
                        if (OriginalStack[insertIndex].StrengthFunction == null)
                        {
                            AddSkillsetStackEntry(OriginalStack[insertIndex].Skillset, OriginalStack[insertIndex].Length, OriginalStack[insertIndex].Strength, OriginalStack[insertIndex].IgnoreTimeScale);
                        }
                        else
                        {
                            AddSkillsetStackEntry(OriginalStack[insertIndex].Skillset, OriginalStack[insertIndex].Length, OriginalStack[insertIndex].StrengthFunction, OriginalStack[insertIndex].IgnoreTimeScale);
                        }
                    }
                    else
                    {
                        SkillsetStack.Add(OriginalStack[insertIndex]);
                    }
                }
            }
        }

        /// <summary>
        /// Place a new entry on the SkillsetStack of this StatMachine.
        /// </summary>
        /// <param name="skillset">A Reference to the Skillset which should be added.</param>
        /// <param name="length">How long will this skillset be added? Pass -1 for infinite duration.
        /// You can still remove infinite duration SkillStackEntries from the stack by saving the reference returned by this method.
        /// Use RemoveSkillsetStackEntries(SkillsetStackEntry[]) to remove the created entry using this reference.</param>
        /// <param name="strength">A strength modifier, which may or may not be used by some of the skills.</param>
        /// <param name="ignoreTimeScale">Will the time calculation be performed in unscaled time?</param>
        public SkillsetStackEntry AddSkillsetStackEntry(Skillset skillset, float length, float strength, bool ignoreTimeScale)
        {
            SkillsetStackEntry newEntry = CreateIndependentStackEntry(skillset, length, strength, ignoreTimeScale);
            SkillsetStack.Add(newEntry);
            return newEntry;
        }

        /// <summary>
        /// Place a new entry on the SkillsetStack of this StatMachine.
        /// </summary>
        /// <param name="skillset">A Reference to the Skillset which should be added.</param>
        /// <param name="length">How long will this skillset be added? Pass -1 for infinite duration.
        /// You can still remove infinite duration SkillStackEntries from the stack by saving the reference returned by this method.
        /// Use RemoveSkillsetStackEntries(SkillsetStackEntry[]) to remove the created entry using this reference.</param>
        /// <param name="strengthFunction">A strength modifier, expressed as a function. Use t in this function to get the active time of this SkillsetStackEntry.</param>
        /// <param name="ignoreTimeScale">Will the time calculation be performed in unscaled time?</param>
        public SkillsetStackEntry AddSkillsetStackEntry(Skillset skillset, float length, string strengthFunction, bool ignoreTimeScale)
        {
            SkillsetStackEntry newEntry = CreateIndependentStackEntry(skillset, length, strengthFunction, ignoreTimeScale);
            SkillsetStack.Add(newEntry);
            return newEntry;
        }

        public SkillsetStackEntry CreateIndependentStackEntry(Skillset skillset, float length, string strengthFunction, bool ignoreTimeScale)
        {
            SkillsetStackEntry newEntry = new SkillsetStackEntry(skillset, strengthFunction, length, ignoreTimeScale ? Time.realtimeSinceStartup : Time.time, ignoreTimeScale);
            return newEntry;
        }

        public SkillsetStackEntry CreateIndependentStackEntry(Skillset skillset, float length, float strength, bool ignoreTimeScale)
        {
            SkillsetStackEntry newEntry = new SkillsetStackEntry(skillset, strength, length, ignoreTimeScale ? Time.realtimeSinceStartup : Time.time, ignoreTimeScale);
            return newEntry;
        }

        /// <summary>
        /// Removing SkillsetStackEntries using saved references.
        /// </summary>
        /// <param name="skillsetStackEntriesToRemove">The references to remove</param>
        public void RemoveSkillsetStackEntries(params SkillsetStackEntry[] skillsetStackEntriesToRemove)
        {
            foreach (SkillsetStackEntry entryToRemove in skillsetStackEntriesToRemove)
            {
                if (SkillsetStack.Contains(entryToRemove))
                {
                    SkillsetStack.Remove(entryToRemove);
                }
                else
                {
                    Debug.LogError("Error while removing skillset entry: SkillsetStackEntry of skillset " + entryToRemove.Skillset.Name + " could not be found");
                }
            }
        }

        /// <summary>
        /// Refreshing the SkillsetStack and removing any timed out or irrelevant SkillStackEntries. Will not do anything, if it was already called this frame.
        /// </summary>
        /// <param name="ForceCompute">Force the method to refresh the SkillStack, even if it already did this frame.</param>
        public void RefreshSkillsetStack(bool ForceCompute)
        {
            if (LastRefresh == Time.frameCount && !ForceCompute) return;
            LastRefresh = Time.frameCount;
            for (int i = 0; i < SkillsetStack.Count; i++)
            {
                if (SkillsetStack[i].EntryTime != -1
                    && SkillsetStack[i].EntryTime + SkillsetStack[i].Length < (SkillsetStack[i].IgnoreTimeScale ? Time.realtimeSinceStartup : Time.time))
                {
                    if (SkillsetStack[i].applyAfterLifetime)
                    {
                        Apply(false, SkillsetStack[i]);
                    }
                    SkillsetStack.RemoveAt(i);
                    i--;
                }
            }
        }

        /// <summary>
        /// Evaluating a Stat by wiring it through all skillsets on this StatMachine.
        /// </summary>
        /// <param name="stat">The stat to be evaluating.</param>
        /// <returns>The value this Stat resolves to after applying all effects.</returns>
        public object EvaluateStat(Stat stat, List<SkillsetStackEntry> Stack)
        {
            RefreshSkillsetStack(false);
            object value = stat.GetValueAsObject();
            foreach (SkillsetStackEntry entry in Stack)
            {
                FunctionSolver.VariableAssignments variableAssignments = new FunctionSolver.VariableAssignments()
                        .AddVariable("t", (entry.IgnoreTimeScale ? Time.realtimeSinceStartup : Time.time) - entry.EntryTime);
                float Strength;
                if (entry.StrengthFunction == null)
                {
                    Strength = entry.Strength;
                }
                else
                {
                    Strength = FunctionSolver.SolveSimpleLiteral(entry.StrengthFunction, variableAssignments);
                }
                value = entry.Skillset.ProcessStat(stat, value, Strength);
            }
            return value;
        }
    }
}