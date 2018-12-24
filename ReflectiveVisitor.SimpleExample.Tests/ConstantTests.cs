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
    public class ConstantTests
    {
        [Theory, AutoMoqData]
        public void SutIsExpression(Constant sut)
        {
            Assert.IsAssignableFrom<Expression>(sut);
        }

        [Theory, AutoData]
        public void ValueReturnsCorrectResult([Frozen]int value, Constant sut)
        {
            Assert.Equal(value, sut.Value);
        }
    }
}
