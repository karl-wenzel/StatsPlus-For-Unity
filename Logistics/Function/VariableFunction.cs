using System;
using System.Collections.Generic;
using StatsPlus;
using StatsPlus.Functions;
using UnityEngine;

namespace StatsPlus.Functions
{
    /// <summary>
    /// The Variable function class returns the value a variable was bound to, if contained in assignements, else returns 0
    /// </summary>
    public class VariableFunction : BaseFunction
    {
        string variableName;

        public VariableFunction(string variableName){
            this.variableName = variableName;
        }

        public override float Solve(FunctionSolver.VariableAssignments assignments) {
            if (assignments == null) return 0;
            if (assignments.Data.ContainsKey(variableName))
            {
                return assignments.Data[variableName];
            }
            return 0;
        }

        public override string ToString()
        {
            return "Var(" + variableName + ")";
        }
    }
}
