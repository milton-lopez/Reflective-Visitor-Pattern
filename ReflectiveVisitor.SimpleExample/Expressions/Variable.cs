using System;
using System.Collections.Generic;

namespace ReflectiveVisitor.SimpleExample.Expressions
{
    public class Variable : Expression
    {
        public string Name { get; }
        public int Value { get; set; }

        public Variable(string name) : this(name, 0) { }

        public Variable(string name, int value)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Value = value;
        }
    }
}