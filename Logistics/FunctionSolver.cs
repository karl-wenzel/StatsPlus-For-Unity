using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StatsPlus.Functions;

namespace StatsPlus
{
    public class FunctionSolver
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
            public VariableAssignments AddOrReplaceVariable(string variableName, float variableValue)
            {
                if (Data.ContainsKey(variableName))
                {
                    Data[variableName] = variableValue;
                }
                else
                {
                    Data.Add(variableName, variableValue);
                }
                return this;
            }
        }

        /// <summary>
        /// this converter takes a nested term of the form Func1(Func2(3,b),a) and returns some derived class of BaseFunction, which can be solved by calling .Solve on it
        /// </summary>
        /// <param name="input">a string with the term to convert</param>
        public static BaseFunction ConvertNestedTermToClassBasedFormat(string input)
        {
            //prepare input
            input = input.Replace(" ", "");
            return InternConvertNestedTermToClassBasedFormat(input);
        }

        protected static BaseFunction InternConvertNestedTermToClassBasedFormat(string input)
        {
            if (input.Length == 0) return null;
            string funcName = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    funcName = input.Substring(0, i);
                    input = input.Substring(i + 1, input.Length - i - 2);

                    break;
                }
                //go here if no brackets were found
                funcName = "FloatOrVar";
            }
            switch (funcName)
            {
                case "Float":
                    float a = 0f;
                    if (System.Single.TryParse(input, out a))
                    {
                        return new FloatFunction(a);
                    }
                    else
                    {
                        Debug.LogWarning("Warning: Error parsing " + input + " as float, reverting to 0f as default.");
                        return new FloatFunction(0f);
                    }
                case "Var":
                    return new VariableFunction(input);
                case "FloatOrVar":
                    float result = 0f;
                    if (System.Single.TryParse(input, out result))
                    {
                        return new FloatFunction(result);
                    }
                    return new VariableFunction(input);
                default:
                    break;
            }
            //terms need to be constructed for every other function type
            List<string> splitTerms = new List<string>();
            int lastAreaEnd = 0;
            int OpenedBrackets = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == ',' && OpenedBrackets == 0)
                {
                    splitTerms.Add(input.Substring(lastAreaEnd, i - lastAreaEnd));
                    lastAreaEnd = i + 1;
                }
                else if (input[i] == '(') OpenedBrackets++;
                else if (input[i] == ')') OpenedBrackets--;
            }
            splitTerms.Add(input.Substring(lastAreaEnd, input.Length - lastAreaEnd));
            BaseFunction[] terms = new BaseFunction[splitTerms.Count];
            for (int a = 0; a < splitTerms.Count; a++)
            {
                terms[a] = InternConvertNestedTermToClassBasedFormat(splitTerms[a]);
            }

            switch (funcName)
            {
                case "Abs":
                    return new AbsoluteFunction(terms);
                case "Absolute":
                    return new AbsoluteFunction(terms);
                case "Add":
                    return new AddFunction(terms);
                case "+":
                    return new AddFunction(terms);
                case "Div":
                    return new DivideFunction(terms);
                case "Divide":
                    return new DivideFunction(terms);
                case "/":
                    return new DivideFunction(terms);
                case ":":
                    return new DivideFunction(terms);
                case "Log":
                    return new LogFunction(terms);
                case "Multiply":
                    return new MultiplyFunction(terms);
                case "Mul":
                    return new MultiplyFunction(terms);
                case "*":
                    return new MultiplyFunction(terms);
                case "Sub":
                    return new SubtractFunction(terms);
                case "Subtract":
                    return new SubtractFunction(terms);
                case "-":
                    return new SubtractFunction(terms);
                case "Pow":
                    return new PowerFunction(terms);
                case "Power":
                    return new PowerFunction(terms);
                case "^":
                    return new PowerFunction(terms);
                default:
                    break;
            }
            return null;
        }

    }
}
