using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectiveVisitor.SimpleExample.Expressions
{
    public class DivisionExpression : ArithmeticExpression
    {
        public DivisionExpression(Expression left, Expression right) :
            base(left, right) { }
    }
}
