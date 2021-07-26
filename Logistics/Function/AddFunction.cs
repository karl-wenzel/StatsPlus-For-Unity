using System;
using System.Collections.Generic;
using StatsPlus;
using StatsPlus.Functions;

namespace StatsPlus.Functions
{
    /// <summary>
    /// The AddFunction class sums up all of its parts
    /// </summary>
    public class AddFunction : BaseFunction
    {
        public AddFunction(params BaseFunction[] Terms) : base(Terms) { }

        public override float Solve(FunctionSolver.VariableAssignments assignments) {
            float Result = 0;
            foreach (var item in EvaluateTerms)
            {
                Result += item.Solve(assignments);
            }
            return Result;
        }
    }
}
