﻿using StatsPlus.Hidden;

namespace StatsPlus
{
    public class FactFloatFromStat : FactFloat, ICheckForInfinityLoop
    {
        string StatName;
        StatMachine StatMachineLink;

        /// <summary>
        /// <para>Creates a FactFloat, which is linked to a Stat.</para>
        /// <para>Be carefull when creating Facts that get their values from stats, as an evaluation is called everytime the value gets asked and you can possibly create infinite loops with this.</para>
        /// </summary>
        /// <param name="Identifier">Identifier of this Fact.</param>
        /// <param name="StatToLink">The Stat that will output the value of this fact.</param>
        /// <param name="StatMachineLink">The Stat machine that should hold this Stat.</param>
        public FactFloatFromStat(string Identifier, string StatToLink, StatMachine StatMachineLink) : base(Identifier, 0)
        {
            if (FactFromStatSyntaxChecker.Check(StatMachineLink, StatToLink, typeof(StatFloat)))
            {
                StatName = StatToLink;
                this.StatMachineLink = StatMachineLink;
            }
            else
            {
                throw new System.Exception("Could not create FactFloatFromStat as the linked stat is not derived from StatFloat or does not exist in this statMachine.");
            }
        }

        public override object getValueAsObject()
        {
            return StatMachineLink.GetStatValue(StatName);
        }
    }
}
