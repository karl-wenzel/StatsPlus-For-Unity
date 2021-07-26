using System;
using System.Collections.Generic;
using StatsPlus;
using StatsPlus.Functions;
using UnityEngine;

namespace StatsPlus.Functions
{
    /// <summary>
    /// The OnedimCustomFunction applies a custom function to its first term. The custom function must be passed in the constructor and should take 1 float argument, returning a float.
    /// </summary>
    public class OnedimCustomFunction : BaseFunction
    {
        Func<float, float> customFunction;

        public OnedimCustomFunction(Func<float, float> customFunction, params BaseFunction[] Terms) : base(Terms) {
            if (Terms.Length != 1) {
                Debug.LogError("<color='red'><b>Incorrect arguments</b> creating LogFunction class: Must at any time have exactly 1 Term!</color>");
            }
            this.customFunction = customFunction;
        }

        public override float Solve(FunctionSolver.VariableAssignments assignments) {
            return customFunction(EvaluateTerms[0].Solve(assignments));
        }
    }
}
