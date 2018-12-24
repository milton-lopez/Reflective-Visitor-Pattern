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
    public class AssignmentTests
    {
        [Theory, AutoMoqData]
        public void SutIsExpression(Assignment sut)
        {
            Assert.IsAssignableFrom<Expression>(sut);
        }

        [Theory, AutoMoqData]
        public void SutConstructorHasAppropiateGuardClauses(GuardClauseAssertion assertion)
        {
            assertion.Verify(typeof(Assignment).GetConstructors());
        }

        [Theory, AutoMoqData]
        public void ValuesReturnCorrectResults(
            [Frozen]Mock<Expression> lValue,
            [Frozen]Mock<Expression> rValue,
            Assignment sut)
        {
            Assert.Equal(lValue.Object, sut.LValue);
            Assert.Equal(rValue.Object, sut.RValue);
        }
    }
}
