using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectiveVisitor.SimpleExample.Expressions
{
    public class MultiplicationExpression : ArithmeticExpression
    {
        public MultiplicationExpression(Expression left, Expression right) :
            base(left, right) { }
    }
}
