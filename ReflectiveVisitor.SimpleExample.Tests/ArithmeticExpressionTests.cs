using AutoFixture.Idioms;
using AutoFixture.Xunit2;
using Moq;
using ReflectiveVisitor.SimpleExample.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ReflectiveVisitor.SimpleExample.Tests
{
    public class ArithmeticExpressionTests
    {
        [Theory, AutoMoqData]
        public void SutIsVisitable(ArithmeticExpression sut)
        {
            Assert.IsAssignableFrom<IVisitable>(sut);
        }

        [Theory, AutoMoqData]
        public void SutIsExpression(ArithmeticExpression sut)
        {
            Assert.IsAssignableFrom<Expression>(sut);
        }

        [Theory, AutoMoqData]
        public void SutConstructorHasAppropiateGuardClauses(GuardClauseAssertion assertion)
        {
            assertion.Verify(typeof(ArithmeticExpression).GetConstructors());
        }

        [Theory, AutoMoqData]
        public void ValuesReturnCorrectResults(
            [Frozen]Mock<Expression> left,
            [Frozen]Mock<Expression> right,
            ArithmeticExpression sut)
        {
            Assert.Equal(left.Object, sut.Left);
            Assert.Equal(right.Object, sut.Right);
        }
    }
}
