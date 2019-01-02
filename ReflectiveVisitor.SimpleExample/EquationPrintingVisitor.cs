using ReflectiveVisitor.SimpleExample.Expressions;
using System.Collections.Generic;

namespace ReflectiveVisitor.SimpleExample
{
    public class EquationPrintingVisitor : Visitor
    {
        public string Equation { get; protected set; }

        protected void Evaluate(Variable variable) =>
            Equation = variable.Name;

        protected void Evaluate(Constant constant) =>
            Equation = constant.Value.ToString();

        protected void Evaluate(AdditionExpression addition)
        {
            Visit(addition.Left);
            var tempEquation = "(" + Equation + " + ";
            Visit(addition.Right);
            Equation = tempEquation + Equation + ")";
        }

        protected void Evaluate(SubtractionExpression subtraction)
        {
            Visit(subtraction.Left);
            var tempEquation = "(" + Equation + " - ";
            Visit(subtraction.Right);
            Equation = tempEquation + Equation + ")";
        }

        protected void Evaluate(MultiplicationExpression multiplication)
        {
            Visit(multiplication.Left);
            var tempEquation = "(" + Equation + " * ";
            Visit(multiplication.Right);
            Equation = tempEquation + Equation + ")";
        }

        protected void Evaluate(DivisionExpression division)
        {
            Visit(division.Left);
            var tempEquation = "(" + Equation + " / ";
            Visit(division.Right);
            Equation = tempEquation + Equation + ")";
        }

        protected void Evaluate(Assignment assignment)
        {
            Visit(assignment.LValue);
            var tempEquation = Equation + " = ";
            Visit(assignment.RValue);
            Equation = tempEquation + Equation;
        }
    }
}