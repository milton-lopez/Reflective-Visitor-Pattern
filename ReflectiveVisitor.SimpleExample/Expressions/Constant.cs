namespace ReflectiveVisitor.SimpleExample.Expressions
{
    public class Constant : Expression
    {
        public int Value { get; }

        public Constant(int value)
        {
            Value = value;
        }
    }
}