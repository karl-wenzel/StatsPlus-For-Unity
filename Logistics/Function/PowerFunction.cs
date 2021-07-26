using System;
using System.Collections.Generic;
using StatsPlus;
using StatsPlus.Functions;
using UnityEngine;

namespace StatsPlus.Functions
{
    /// <summary>
    /// <para>The PowerFunction raises term one to the power of term two, then the result to the power of term 3 and so on.</para>
    /// example: ((Term1^Term2)^Term3)^Term4
    /// </summary>
    public class PowerFunction : BaseFunction
    {
        public PowerFunction(params BaseFunction[] Terms) : base(Terms)
        {
            if (Terms.Length < 1)
            {
                Debug.LogError("<color='red'><b>Insufficient arguments</b> creating PowerFunction class: Must at any time have at least 1 Term!</color>");
            }
        }

        public override float Solve(FunctionSolver.VariableAssignments assignments)
        {
            float Result = EvaluateTerms[0].Solve(assignments);
            for (int i = 1; i < EvaluateTerms.Count; i++)
            {
                Result = (float)Math.Pow(Result, EvaluateTerms[i].Solve(assignments));
            }
            return Result;
        }
    }
}
