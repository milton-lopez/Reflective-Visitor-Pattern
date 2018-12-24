using AutoFixture;
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
    public class VariableTests
    {
        [Theory, AutoMoqData]
        public void SutIsExpression(Variable sut)
        {
            Assert.IsAssignableFrom<Expression>(sut);
        }

        [Theory, AutoMoqData]
        public void SutConstructorHasAppropiateGuardClauses(GuardClauseAssertion assertion)
        {
            assertion.Verify(typeof(Variable).GetConstructors());
        }

        [Theory, AutoData]
        public void ValuesReturnCorrectResults([Frozen]string name, [Frozen]int value, Variable sut)
        {
            Assert.Equal(name, sut.Name);
            Assert.Equal(value, sut.Value);
        }
    }
}
