using System;
using System.Collections.Generic;
using StatsPlus;
using StatsPlus.Functions;

namespace StatsPlus.Functions
{
    /// <summary>
    /// The MultiplyFunction class multiplies all of its parts
    /// </summary>
    public class MultiplyFunction : BaseFunction
    {
        public MultiplyFunction(params BaseFunction[] Terms) : base(Terms) { }

        public override float Solve(FunctionSolver.VariableAssignments assignments) {
            float Result = 1;
            foreach (var item in EvaluateTerms)
            {
                Result *= item.Solve(assignments);
            }
            return Result;
        }
    }
}
