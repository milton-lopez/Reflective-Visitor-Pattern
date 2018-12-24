﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectiveVisitor.SimpleExample.Expressions
{
    public class AdditionExpression : ArithmeticExpression
    {
        public AdditionExpression(Expression left, Expression right) :
            base(left, right) { }
    }
}
