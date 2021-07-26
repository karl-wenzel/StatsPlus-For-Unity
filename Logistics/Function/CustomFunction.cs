using System;

namespace StatsPlus.Functions
{
    /// <summary>
    /// The CustomFunction applies a custom function to its terms. The function, which sould be passed in the constructor, should take an array of floats and return a float.
    /// </summary>
    public class CustomFunction : BaseFunction
    {
        Func<float[] , float> customFunction;

        public CustomFunction(Func<float[] , float> customFunction, params BaseFunction[] Terms) : base(Terms) {
            this.customFunction = customFunction;
        }

        public override float Solve(FunctionSolver.VariableAssignments assignments) {
            float[] args = new float[EvaluateTerms.Count];
            for (int i = 0; i < EvaluateTerms.Count; i++)
            {
                args[i] = EvaluateTerms[i].Solve(assignments);
            }
            return customFunction(args);
        }
    }
}
