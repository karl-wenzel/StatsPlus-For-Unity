using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StatsPlus;
using System;

namespace StatsPlus
{
    public class SkillsetStackEntry
    {
        public readonly Skillset Skillset;
        public readonly float Strength;
        public readonly float Length;
        public readonly float EntryTime;
        public readonly bool IgnoreTimeScale;

        public SkillsetStackEntry(Skillset skillset, float strength, float length, float entryTime, bool ignoreTimeScale)
        {
            Skillset = skillset ?? throw new ArgumentNullException(nameof(skillset));
            Strength = strength;
            Length = length;
            EntryTime = entryTime;
            IgnoreTimeScale = ignoreTimeScale;
        }
    }
}
