using System.Collections.Generic;
using ReflectiveVisitor.SimpleExample.Expressions;

namespace ReflectiveVisitor.SimpleExample
{
    public class CalculationVisitor : Visitor
    {
        public int Result { get; protected set; }

        protected void Evaluate(Variable variable)
        {
            Result = variable.Value;
        }

        protected void Evaluate(Constant constant)
        {
            Result = constant.Value;
        }

        protected void Evaluate(AdditionExpression addition)
        {
            var left = addition.Left;
            var right = addition.Right;

            Visit(left);

            var leftResult = Result;

            Visit(right);

            Result += leftResult; 
        }

        protected void Evaluate(SubtractionExpression subtraction)
        {
            var left = subtraction.Left;
            var right = subtraction.Right;

            Visit(left);

            var leftResult = Result;

            Visit(right);

            Result = leftResult - Result;
        }

        protected void Evaluate(MultiplicationExpression multiplication)
        {
            var left = multiplication.Left;
            var right = multiplication.Right;

            Visit(left);

            var leftResult = Result;

            Visit(right);

            Result *= leftResult;
        }

        protected void Evaluate(DivisionExpression division)
        {
            var left = division.Left;
            var right = division.Right;

            Visit(left);

            var leftResult = Result;

            Visit(right);

            Result = leftResult / Result;
        }

        protected void Evaluate(Assignment assignment)
        {
            var lValue = assignment.LValue;
            var rValue = assignment.RValue;

            Visit(rValue);

            if (lValue is Variable variable)
                variable.Value = Result;
        }
    }
}