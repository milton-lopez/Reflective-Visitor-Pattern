using ReflectiveVisitor.SimpleExample;
using ReflectiveVisitor.SimpleExample.Expressions;
using ReflectiveVisitor.Structure;
using System;

namespace ReflectiveVisitor.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            //var visitor = new Visitor1();
            //visitor.Visit(new Element1());

            Calculate();

            Console.ReadLine();
        }

        static void Calculate()
        {
            //a=5*b+2
            var expression = new Assignment(new Variable("a"),
                                            new AdditionExpression(new MultiplicationExpression(new Constant(5),
                                                                                                new Variable("b", 2)),
                                                                   new Constant(2)));


            var equationPrintingVisitor = new EquationPrintingVisitor();
            equationPrintingVisitor.Visit(expression);

            var calculationVisitor = new CalculationVisitor();
            calculationVisitor.Visit(expression);

            Console.WriteLine($"Expression: {equationPrintingVisitor.Equation}");
            Console.WriteLine($"The result is: {calculationVisitor.Result}");
        }
    }
}