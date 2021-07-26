using System;
using System.Collections.Generic;
using StatsPlus;

namespace StatsPlus.Functions
{
    public abstract class BaseFunction
    {
        public List<BaseFunction> EvaluateTerms = new List<BaseFunction>();

        public BaseFunction(params BaseFunction[] Terms) {
            if (Terms.Length > 0)
            {
                EvaluateTerms.AddRange(Terms);
            }
        }

        /// <summary>
        /// Adds a Term to the evaluation
        /// </summary>
        public BaseFunction AddTerm(BaseFunction Term) {
            EvaluateTerms.Add(Term);
            return this;
        }

        /// <summary>
        /// Removes a Term from the evaluation
        /// </summary>
        /// <param name="Term"></param>
        /// <returns></returns>
        public BaseFunction RemoveTerm(BaseFunction Term) {
            EvaluateTerms.Remove(Term);
            return this;
        }

        /// <summary>
        /// Tries to solve the function without any variable assignements. Will log an error and/or return unexpected results if there are unassigned variables in the function
        /// </summary>
        /// <returns>The calculation result</returns>
        public float SimpleSolve() {
            return Solve(null);
        }

        /// <summary>
        /// Tries to solve the function with a given set of variable assignements. Will log an error and/or return unexpected results if there are unassigned variables in the function
        /// </summary>
        /// <param name="assignments">The variable assignements, in which assignements for every unassigned variable in the function should be saved</param>
        /// <returns>The calculation result</returns>
        public abstract float Solve(FunctionSolver.VariableAssignments assignments);
    }
}
