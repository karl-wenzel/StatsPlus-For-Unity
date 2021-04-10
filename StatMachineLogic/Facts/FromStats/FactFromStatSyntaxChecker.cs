using UnityEngine;

namespace StatsPlus.Hidden
{
    public static class FactFromStatSyntaxChecker
    {
        public static bool Check(StatMachine statMachineLink, string StatId, System.Type expectedType) {
            Stat foundStat = null;
            if (statMachineLink.Statset.HasKey(StatId, out foundStat)) {
                return foundStat.GetType().IsSubclassOf(expectedType) || foundStat.GetType() == expectedType;
            }
            else return false;
        }
    }
}
