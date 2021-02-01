using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StatsPlus
{
    class FunctionSolver
    {
        public static float NeutralElementMultiplication = 1f;
        public static float NeutralElementAddition = 0f;

        public struct SatisfyVariable
        {
            public string VariableName;
            public float VariableValue;
        }

        public class VariableAssignments
        {
            public List<SatisfyVariable> Data = new List<SatisfyVariable>();
            public VariableAssignments AddVariable(string variableName, float variableValue)
            {
                Data.Add(new SatisfyVariable { VariableName = variableName, VariableValue = variableValue });
                return this;
            }
        }

        /// <summary>
        /// Solves a simple literal. Numeric symbols and +,-,*,/ are allowed. If your literal contains variables such as a,x,myVar etc, consider using the overload SolveSimpleLiteral(string, VariableAssignments) to assign them to their values.
        /// </summary>
        /// <param name="Literal">The simple literal to solve.</param>
        /// <param name="Assignments">Assign the variable values here.</param>
        /// <returns>The result of the evaluated literal.</returns>
        public static float SolveSimpleLiteral(string Literal)
        {
            return SolveSimpleLiteral(Literal, new VariableAssignments());
        }

        /// <summary>
        /// Solves a simple literal. Numeric symbols and +,-,*,/ are allowed. If your literal contains variables such as a,x,myVar etc, you can replace them with the VariableAssignments-class.
        /// </summary>
        /// <param name="Literal">The simple literal to solve.</param>
        /// <param name="Assignments">Assign the variable values here.</param>
        /// <returns>The result of the evaluated literal.</returns>
        public static float SolveSimpleLiteral(string Literal, VariableAssignments Assignments)
        {
            foreach (SatisfyVariable variableAssignment in Assignments.Data)
            {
                Literal = Literal.Replace(variableAssignment.VariableName, variableAssignment.VariableValue+"");
            }

            Literal = Literal.Replace("-", "+(-)").Replace("/", "*(/)");

            float Solve(string input)
            {

                float result;
                string[] sums = input.Split('+');
                if (sums.Length != 1)
                {
                    result = NeutralElementAddition;
                    for (int i = 0; i < sums.Length; i++)
                    {
                        result = Solve(sums[i]) + result;
                    }
                    return result;
                }

                if (input.Length > 2 && input.Substring(0, 3).Equals("(-)"))
                {
                    return -1f * Solve(input.Remove(0, 3));
                }

                string[] factors = input.Split('*');
                if (factors.Length != 1)
                {
                    result = NeutralElementMultiplication;
                    for (int i = 0; i < factors.Length; i++)
                    {
                        result = Solve(factors[i]) * result;
                    }
                    return result;
                }

                if (input.Length > 2 && input.Substring(0, 3).Equals("(/)"))
                {
                    return 1f / Solve(input.Remove(0, 3));
                }

                string[] exponential = input.Split('^');
                if (exponential.Length != 1)
                {
                    result = Solve(exponential[0]);
                    for (int i = 1; i < exponential.Length; i++)
                    {
                        result = Mathf.Pow(result, Solve(exponential[i]));
                    }
                    return result;
                }

                if (float.TryParse(input, out result)) return result;
                else
                {
                    Debug.LogError("Could not parse symbol: <b>" + input + "</b>. Value unknown. Maybe your input " + Literal + " was formatted wrong or you are missing variable assignments.");
                    return 0f;
                }
            }

            return Solve(Literal);
        }

    }
}
