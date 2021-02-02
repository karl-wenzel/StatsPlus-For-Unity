using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StatsPlus
{
    class FunctionSolver
    {
        public static float NeutralElementMultiplication = 1f;
        public static float NeutralElementAddition = 0f;


        public class VariableAssignments
        {
            public Dictionary<string, float> Data = new Dictionary<string, float>();
            public VariableAssignments AddVariable(string variableName, float variableValue)
            {
                Data.Add(variableName, variableValue);
                return this;
            }
            public VariableAssignments AddOrReplaceVariable(string variableName, float variableValue) {
                if (Data.ContainsKey(variableName))
                {
                    Data[variableName] = variableValue;
                }
                else {
                    Data.Add(variableName, variableValue);
                }
                return this;
            }
        }

        /// <summary>
        /// Use this to check if your literal doesn't contains parts that are not allowed and won't result in unpredictable behaviour if you try to solve it.
        /// </summary>
        /// <param name="Literal"></param>
        /// <returns></returns>
        public static bool LiteralWellFormatted(string Literal)
        {
            if (Literal.Contains("[") || Literal.Contains("]"))
            {
                Debug.Log(Literal+" Format Info: [ and ] not allowed.");
                return false;
            }
            if (Literal.Contains("--"))
            {
                Debug.Log(Literal+" Format Info: -- not allowed.");
                return false;
            }
            if (Literal.Contains("-(-"))
            {
                Debug.Log(Literal+" Format Info: -(- not allowed.");
                return false;
            }
            int OpenedBrackets = 0;
            for (int i = 0; i < Literal.Length; i++)
            {
                if (Literal[i] == '(')
                {
                    OpenedBrackets++;
                    continue;
                }
                if (Literal[i] == ')')
                {
                    OpenedBrackets--;
                    continue;
                }
            }
            if (OpenedBrackets > 0) {
                Debug.LogError(Literal+" Format Info: Literal not well formatted. Couldn't close all brackets.");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Solves a simple literal. Numeric symbols, brackets () and +,-,*,/ are allowed.
        /// </summary>
        /// <param name="Literal">The simple literal to solve.</param>
        /// <param name="Assignments">Assign the variable values here.</param>
        /// <returns>The result of the evaluated literal.</returns>
        public static float SolveSimpleLiteral(string Literal)
        {
            return SolveSimpleLiteral(Literal, new VariableAssignments());
        }

        /// <summary>
        /// Solves a simple literal. Numeric symbols, brackets () and +,-,*,/ are allowed. If your literal contains variables such as a, x, myVar etc, you can replace them with the VariableAssignments-class.
        /// </summary>
        /// <param name="Literal">The simple literal to solve.</param>
        /// <param name="Assignments">Assign the variable values here.</param>
        /// <returns>The result of the evaluated literal.</returns>
        public static float SolveSimpleLiteral(string Literal, VariableAssignments Assignments)
        {
            foreach (string variableName in Assignments.Data.Keys)
            {
                Literal = Literal.Replace(variableName, Assignments.Data[variableName] + "");
            }

            Literal = Literal.Replace("-", "+[-]").Replace("/", "*[/]");


            int OpenedBrackets = 0;
            int LastOpenBracketIndex = 0;
            for (int i = 0; i < Literal.Length; i++)
            {
                if (Literal[i] == '(')
                {
                    OpenedBrackets++;
                    LastOpenBracketIndex = i;
                    continue;
                }
                if (Literal[i] == ')')
                {
                    if (OpenedBrackets != 0)
                    {
                        float f = Solve(Literal.Substring(LastOpenBracketIndex + 1, i - (LastOpenBracketIndex + 1)));
                        Literal = Literal.Remove(LastOpenBracketIndex, i - LastOpenBracketIndex + 1);
                        Literal = Literal.Insert(LastOpenBracketIndex, f.ToString());
                        OpenedBrackets = 0;
                        LastOpenBracketIndex = 0;
                        i = -1;
                        continue;
                    }
                    else
                    {
                        Debug.LogError("Couldnt parse literal " + Literal + ". You are closing too many brackets.");
                    }
                }
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

                if (input.Length > 2 && input.Substring(0, 3).Equals("[-]"))
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

                if (input.Length > 2 && input.Substring(0, 3).Equals("[/]"))
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
