using System;
using System.Collections.Generic;
using StatsPlus;
using StatsPlus.Functions;
using UnityEngine;

namespace StatsPlus.Functions
{
    /// <summary>
    /// The Subtract Function class takes the first Term and subtracts all the others from it
    /// </summary>
    public class SubtractFunction : BaseFunction
    {
        public SubtractFunction(params BaseFunction[] Terms) : base(Terms) {
            if (Terms.Length < 1) {
                Debug.LogError("<color='red'><b>Insufficient arguments</b> creating SubtractFunction class: Must at any time have at least 1 Term!</color>");
            }
        }

        public override float Solve(FunctionSolver.VariableAssignments assignments) {
            float Result = EvaluateTerms[0].Solve(assignments);
            for (int i = 1; i < EvaluateTerms.Count; i++)
            {
                Result -= EvaluateTerms[i].Solve(assignments);
            }
            return Result;
        }
    }
}
