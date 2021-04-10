namespace StatsPlus
{
    public class FactObjectFromStat : FactObject, ICheckForInfinityLoop
    {
        string StatName;
        StatMachine StatMachineLink;

        /// <summary>
        /// <para>Creates a FactObject, which is linked to a Stat.</para>
        /// <para>Be carefull when creating Facts that get their values from stats, as an evaluation is called everytime the value gets asked and you can possibly create infinite loops with this.</para>
        /// </summary>
        /// <param name="Identifier">Identifier of this Fact.</param>
        /// <param name="StatToLink">The Stat that will output the value of this fact.</param>
        /// <param name="StatMachineLink">The Stat machine that should hold this Stat.</param>
        public FactObjectFromStat(string Identifier, string StatToLink, StatMachine StatMachineLink) : base(Identifier, false)
        {
            StatName = StatToLink;
            this.StatMachineLink = StatMachineLink;
        }

        public override object getValueAsObject()
        {
            return StatMachineLink.GetStatValue(StatName);
        }
    }
}
