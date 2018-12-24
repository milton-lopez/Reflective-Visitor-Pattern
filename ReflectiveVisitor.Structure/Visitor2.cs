using System;

namespace ReflectiveVisitor.Structure
{
    public class Visitor2 : Visitor
    {
        protected void Evaluate(Element2 element) =>
           Console.WriteLine($"{element.GetType().Name} visited by {GetType().Name}");
    }
}
