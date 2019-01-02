using System.Collections.Generic;
using ReflectiveVisitor.SimpleExample.Expressions;

namespace ReflectiveVisitor.SimpleExample
{
    public class CalculationVisitor : Visitor
    {
        public int Result { get; protected set; }

        protected void Evaluate(Variable variable) =>
            Result = variable.Value;

        protected void Evaluate(Constant constant) =>
            Result = constant.Value;

        protected void Evaluate(AdditionExpression addition)
        {
            Visit(addition.Left);
            var leftResult = Result;
            Visit(addition.Right);
            Result += leftResult;
        }

        protected void Evaluate(SubtractionExpression subtraction)
        {
            Visit(subtraction.Left);
            var leftResult = Result;
            Visit(subtraction.Right);
            Result = leftResult - Result;
        }

        protected void Evaluate(MultiplicationExpression multiplication)
        {
            Visit(multiplication.Left);
            var leftResult = Result;
            Visit(multiplication.Right);
            Result *= leftResult;
        }

        protected void Evaluate(DivisionExpression division)
        {
            Visit(division.Left);
            var leftResult = Result;
            Visit(division.Right);
            Result = leftResult / Result;
        }

        protected void Evaluate(Assignment assignment)
        {
            Visit(assignment.RValue);

            if (assignment.LValue is Variable variable)
                variable.Value = Result;
        }
    }
}