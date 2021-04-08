using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StatsPlus;
using System;

namespace StatsPlus
{
    public class SkillsetStackEntry : Printable
    {
        public readonly Skillset Skillset;
        public float Strength;
        public string StrengthFunction;
        public readonly float Length;
        public readonly float EntryTime;

        public readonly bool IgnoreTimeScale;
        public bool applyAfterLifetime = false;
        public bool clippedOnTop = false;

        public SkillsetStackEntry(Skillset skillset, float strength, float length, float entryTime, bool ignoreTimeScale)
        {
            Skillset = skillset ?? throw new ArgumentNullException(nameof(skillset));
            Strength = strength;
            StrengthFunction = null;
            Length = length;
            EntryTime = entryTime;
            IgnoreTimeScale = ignoreTimeScale;
        }

        public SkillsetStackEntry(Skillset skillset, string strengthFunction, float length, float entryTime, bool ignoreTimeScale)
        {
            Skillset = skillset ?? throw new ArgumentNullException(nameof(skillset));
            SetStrengthFunction(strengthFunction);
            Length = length;
            EntryTime = entryTime;
            IgnoreTimeScale = ignoreTimeScale;
        }

        public SkillsetStackEntry SetStrength(float newStrength) {
            Strength = newStrength;
            return this;
        }

        public SkillsetStackEntry AddStrength(float amount) {
            Strength += amount;
            return this;
        }

        public SkillsetStackEntry SetStrengthFunction(string strengthFunction) {
            Strength = 1f;
            if (FunctionSolver.LiteralWellFormatted(strengthFunction))
            {
                StrengthFunction = strengthFunction;
            }
            else
            {
                Debug.LogError("Skipping strengthFunction " + strengthFunction + ", as it contains syntax errors.");
                StrengthFunction = null;
            }
            return this;
        }

        public SkillsetStackEntry ApplyAfterLifetime() {
            applyAfterLifetime = true;
            return this;
        }

        public SkillsetStackEntry ClipOnTop() {
            clippedOnTop = true;
            return this;
        }

        public SkillsetStackEntry ReleaseFromTop()
        {
            clippedOnTop = false;
            return this;
        }

        public override string ToString()
        {
            return Skillset.ToString();
        }

        public string PrettyPrint()
        {
            return "Stack|" + (StrengthFunction == null ? "strength:"+Strength : "strengthFunction:"+StrengthFunction) + "|content:" + Skillset.PrettyPrint() + ";";
        }
    }
}
