using ReflectiveVisitor.SimpleExample.Expressions;
using System.Collections.Generic;

namespace ReflectiveVisitor.SimpleExample
{
    public class EquationPrintingVisitor : Visitor
    {
        public string Equation { get; protected set; }

        protected void Evaluate(Variable variable)
        {
            Equation = variable.Name;
        }

        protected void Evaluate(Constant constant)
        {
            Equation = constant.Value.ToString();
        }

        protected void Evaluate(AdditionExpression addition)
        {
            var left = addition.Left;
            var right = addition.Right;

            Visit(left);

            var tempEquation = "(" + Equation + " + ";

            Visit(right);

            Equation = tempEquation + Equation + ")";
        }

        protected void Evaluate(SubtractionExpression subtraction)
        {
            var left = subtraction.Left;
            var right = subtraction.Right;

            Visit(left);

            var tempEquation = "(" + Equation + " - ";

            Visit(right);

            Equation = tempEquation + Equation + ")";
        }

        protected void Evaluate(MultiplicationExpression multiplication)
        {
            var left = multiplication.Left;
            var right = multiplication.Right;

            Visit(left);

            var tempEquation = "(" + Equation + " * ";

            Visit(right);

            Equation = tempEquation + Equation + ")";
        }

        protected void Evaluate(DivisionExpression division)
        {
            var left = division.Left;
            var right = division.Right;

            Visit(left);

            var tempEquation = "(" + Equation + " / ";

            Visit(right);

            Equation = tempEquation + Equation + ")";
        }

        protected void Evaluate(Assignment assignment)
        {
            var lValue = assignment.LValue;
            var rValue = assignment.RValue;

            Visit(lValue);

            var tempEquation = Equation + " = ";

            Visit(rValue);

            Equation = tempEquation + Equation;
        }
    }
}