using UnityEngine;
using StatsPlus.Functions;

namespace StatsPlus
{
    public class FactFunction : FactFloat
    {
        public BaseFunction function;
        public FunctionSolver.VariableAssignments assignements;

        public FactFunction(string Identifier, string function) : base(Identifier, 0f)
        {
            this.function = FunctionSolver.ConvertNestedTermToClassBasedFormat(function);
        }

        public FactFunction(string Identifier, BaseFunction function) : base(Identifier, 0f)
        {
            this.function = function;
        }

        public FactFunction SetFunction(string function)
        {
            this.function = FunctionSolver.ConvertNestedTermToClassBasedFormat(function);
            return this;
        }

        public override FactFloat Add(float value)
        {
            function = new AddFunction(function, new FloatFunction(value));
            return this;
        }

        public override FactFloat Substract(float value)
        {
            function = new SubtractFunction(function, new FloatFunction(value));
            return this;
        }

        public override FactFloat Multiply(float factor)
        {
            function = new MultiplyFunction(function, new FloatFunction(factor));
            return this;
        }

        public FactFunction ReplaceAssignements(FunctionSolver.VariableAssignments newAssignements) {
            assignements = newAssignements;
            return this;
        }

        public override object getValueAsObject()
        {
            return function.Solve(assignements);
        }

    }
}
