using System;
using System.Collections.Generic;
using StatsPlus;
using StatsPlus.Functions;
using UnityEngine;

namespace StatsPlus.Functions
{
    /// <summary>
    /// The first term shall be the base b, the second term is x. The LogFunction returns the number to which this base b must be raised to return x.
    /// </summary>
    public class LogFunction : BaseFunction
    {
        public LogFunction(params BaseFunction[] Terms) : base(Terms) {
            if (Terms.Length != 2) {
                Debug.LogError("<color='red'><b>Incorrect arguments</b> creating LogFunction class: Must at any time have exactly 2 Terms!</color>");
            }
        }

        public override float Solve(FunctionSolver.VariableAssignments assignments) {
            return (float)Math.Log(EvaluateTerms[1].Solve(assignments), EvaluateTerms[0].Solve(assignments));
        }
    }
}
