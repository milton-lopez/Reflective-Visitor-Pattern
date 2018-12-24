using System;
using System.Collections.Generic;

namespace ReflectiveVisitor.SimpleExample.Expressions
{
    public class ArithmeticExpression : Expression
    {
        public Expression Left { get; }
        public Expression Right { get; }

        public ArithmeticExpression(Expression left, Expression right)
        {
            Left = left ?? throw new ArgumentNullException(nameof(left));
            Right = right ?? throw new ArgumentNullException(nameof(right));
        }
    }
}