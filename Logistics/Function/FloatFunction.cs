using System;
using System.Collections.Generic;
using StatsPlus;
using StatsPlus.Functions;
using UnityEngine;

namespace StatsPlus.Functions
{
    /// <summary>
    /// The Float Function class returns a float
    /// </summary>
    public class FloatFunction : BaseFunction
    {
        float f;

        public FloatFunction(float value){
            f = value;
        }

        public override float Solve(FunctionSolver.VariableAssignments assignments) {
            return f;
        }
    }
}
