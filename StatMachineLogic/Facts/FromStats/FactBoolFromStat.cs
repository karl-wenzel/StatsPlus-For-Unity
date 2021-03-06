﻿using StatsPlus.Hidden;

namespace StatsPlus
{
    public class FactBoolFromStat : FactBool, ICheckForInfinityLoop
    {
        string StatName;
        StatMachine StatMachineLink;

        /// <summary>
        /// <para>Creates a FactBool, which is linked to a Stat.</para>
        /// <para>Be carefull when creating Facts that get their values from stats, as an evaluation is called everytime the value gets asked and you can possibly create infinite loops with this.</para>
        /// </summary>
        /// <param name="Identifier">Identifier of this Fact.</param>
        /// <param name="StatToLink">The Stat that will output the value of this fact.</param>
        /// <param name="StatMachineLink">The Stat machine that should hold this Stat.</param>
        public FactBoolFromStat(string Identifier, string StatToLink, StatMachine StatMachineLink) : base(Identifier, false)
        {
            if (FactFromStatSyntaxChecker.Check(StatMachineLink, StatToLink, typeof(StatBool)))
            {
                StatName = StatToLink;
                this.StatMachineLink = StatMachineLink;
            }
            else
            {
                throw new System.Exception("Could not create FactBoolFromStat as the linked stat is not derived from StatBool or does not exist in this statMachine.");
            }
        }

        public override object getValueAsObject()
        {
            return StatMachineLink.GetStatValue(StatName);
        }
    }
}
