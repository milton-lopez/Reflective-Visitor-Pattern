using AutoFixture.Idioms;
using AutoFixture.Xunit2;
using ReflectiveVisitor.SimpleExample.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ReflectiveVisitor.SimpleExample.Tests
{
    public class CalculationVisitorTests
    {
        [Theory, AutoData]
        public void SutIsVisitor(CalculationVisitor sut)
        {
            Assert.IsAssignableFrom<Visitor>(sut);
        }

        [Theory, AutoMoqData]
        public void SutHasAppropiateGuardClauses(GuardClauseAssertion assertion)
        {
            assertion.Verify(typeof(CalculationVisitor));
        }

        [Theory, AutoData]
        public void VisitVariableReturnsCorrectResult(Variable variable, CalculationVisitor sut)
        {
            sut.Visit(variable);
            Assert.Equal(variable.Value, sut.Result);
        }

        [Theory, AutoData]
        public void VisitConstantReturnsCorrectResult(Constant constant, CalculationVisitor sut)
        {
            sut.Visit(constant);
            Assert.Equal(constant.Value, sut.Result);
        }

        [Theory, InlineAutoData]
        public void VisitAdditionExpressionReturnsCorrectResult(int x, int y, CalculationVisitor sut)
        {
            var left = new Constant(x);
            var right = new Constant(y);
            var addition = new AdditionExpression(left, right);

            sut.Visit(addition);
            var expected = x + y;

            Assert.Equal(expected, sut.Result);
        }

        [Theory, InlineAutoData]
        public void VisitSubtractionExpressionReturnsCorrectResult(int x, int y, CalculationVisitor sut)
        {
            var left = new Constant(x);
            var right = new Constant(y);
            var subtraction = new SubtractionExpression(left, right);

            sut.Visit(subtraction);
            var expected = x - y;

            Assert.Equal(expected, sut.Result);
        }

        [Theory, InlineAutoData]
        public void VisitMultiplicationExpressionReturnsCorrectResult(int x, int y, CalculationVisitor sut)
        {
            var left = new Constant(x);
            var right = new Constant(y);
            var multiplication = new MultiplicationExpression(left, right);

            sut.Visit(multiplication);
            var expected = x * y;

            Assert.Equal(expected, sut.Result);
        }

        [Theory, InlineAutoData]
        public void VisitDivisionExpressionReturnsCorrectResult(int x, int y, CalculationVisitor sut)
        {
            var left = new Constant(x);
            var right = new Constant(y);
            var division = new DivisionExpression(left, right);

            sut.Visit(division);
            var expected = x / y;

            Assert.Equal(expected, sut.Result);
        }

        [Theory, InlineAutoData]
        public void VisitAssignmentReturnsCorrectResult(int y, CalculationVisitor sut)
        {
            var left = new Variable("x");
            var right = new Constant(y);
            var assignment = new Assignment(left, right);

            sut.Visit(assignment);
            var expected = y;

            Assert.Equal(expected, sut.Result);
        }
    }
}
