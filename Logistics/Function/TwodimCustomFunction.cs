using System;
using System.Collections.Generic;
using StatsPlus;
using StatsPlus.Functions;
using UnityEngine;

namespace StatsPlus.Functions
{
    /// <summary>
    /// The TwodimCustomFunction applies a custom function to its first 2 terms. The custom function must be passed in the constructor and should take 2 float arguments, returning a float.
    /// </summary>
    public class TwodimCustomFunction : BaseFunction
    {
        Func<float, float, float> customFunction;

        public TwodimCustomFunction(Func<float, float, float> customFunction, params BaseFunction[] Terms) : base(Terms) {
            if (Terms.Length != 2) {
                Debug.LogError("<color='red'><b>Incorrect arguments</b> creating LogFunction class: Must at any time have exactly 2 Terms!</color>");
            }
            this.customFunction = customFunction;
        }

        public override float Solve(FunctionSolver.VariableAssignments assignments) {
            return customFunction(EvaluateTerms[0].Solve(assignments), EvaluateTerms[1].Solve(assignments));
        }
    }
}
