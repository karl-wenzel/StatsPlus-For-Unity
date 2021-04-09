
namespace StatsPlus
{
    public class FactIntFromStat : FactInt
    {
        string FactName;
        StatMachine StatMachineLink;

        public FactIntFromStat(string Identifier, string FactName, StatMachine StatMachineLink) : base(Identifier, 0)
        {
            this.FactName = FactName;
            this.StatMachineLink = StatMachineLink;
        }

        public override object getValueAsObject()
        {
            return StatMachineLink.GetStatValueInt(FactName);
        }
    }
}
