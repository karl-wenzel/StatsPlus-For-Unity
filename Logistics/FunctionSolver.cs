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

        public static float SolveSimpleLiteral(string Literal)
        {
            return SolveSimpleLiteral(Literal, new VariableAssignments());
        }

        public static float SolveSimpleLiteral(string Literal, VariableAssignments Assignments)
        {
            foreach (SatisfyVariable variableAssignment in Assignments.Data)
            {
                Literal = Literal.Replace(variableAssignment.VariableName, variableAssignment.VariableValue+"");
            }

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


                if (float.TryParse(input, out result)) return result;
                else
                {
                    Debug.LogError("Could not parse symbol: <b>" + input + "</b>. Maybe your input " + Literal + " was formatted wrong?");
                    return 0f;
                }
            }

            return Solve(Literal);
        }

    }
}
