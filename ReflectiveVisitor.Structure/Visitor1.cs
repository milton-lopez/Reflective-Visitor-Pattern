using System;
using System.Collections.Generic;
using System.Text;

namespace ReflectiveVisitor.Structure
{
    public class Visitor1 : Visitor
    {
        protected void Evaluate(Element1 element) =>
            Console.WriteLine($"{element.GetType().Name} visited by {GetType().Name}");
    }
}
