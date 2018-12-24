using System;

namespace ReflectiveVisitor.SimpleExample.Expressions
{
    public class Assignment : Expression
    {
        public Expression LValue { get; }
        public Expression RValue { get; }

        public Assignment(Expression lValue, Expression rValue)
        {
            LValue = lValue ?? throw new ArgumentNullException(nameof(lValue));
            RValue = rValue ?? throw new ArgumentNullException(nameof(rValue));
        }
    }
}