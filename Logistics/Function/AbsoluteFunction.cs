using System;
using System.Collections.Generic;
using StatsPlus;
using StatsPlus.Functions;
using UnityEngine;

namespace StatsPlus.Functions
{
    /// <summary>
    /// The Absolute Function class returns the absolute of its first term
    /// </summary>
    public class AbsoluteFunction : BaseFunction
    {
        public AbsoluteFunction(params BaseFunction[] Terms) : base(Terms) {
            if (Terms.Length < 1) {
                Debug.LogError("<color='red'><b>Insufficient arguments</b> creating AbsoluteFunction class: Must at any time have at least 1 Term!</color>");
            }
        }

        public override float Solve(FunctionSolver.VariableAssignments assignments) {
            return Math.Abs(EvaluateTerms[0].Solve(assignments));
        }
    }
}
