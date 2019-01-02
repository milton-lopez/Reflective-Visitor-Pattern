using ReflectiveVisitor.SimpleExample.Expressions;
using System;
using System.Reflection;

namespace ReflectiveVisitor.SimpleExample
{
    public abstract class Visitor
    {
        public void Visit(IVisitable visitable)
        {
            MethodInfo method = SearchMethod(visitable);

            try
            {
                method?.Invoke(this, new[] { visitable });
            }
            catch (MethodAccessException e)
            {
                //Error Handling ommited!!
            }
            catch (TargetInvocationException e)
            {
                //Error Handling ommited!!
            }
            catch (Exception)
            {
                throw;
            }
        }

        private MethodInfo SearchMethod(IVisitable visitable)
        {
            if (visitable == null)
                throw new ArgumentNullException(nameof(visitable));

            return GetEvaluateMethod(visitable.GetType());
        }

        private MethodInfo GetEvaluateMethod(Type visitableType)
        {
            if (!typeof(IVisitable).IsAssignableFrom(visitableType))
                return null;

            var method = GetEvaluateMethodFromConcreteVisitor(GetType(), visitableType);

            return method != null ? method :
                   GetEvaluateMethod(visitableType.GetType().BaseType);
        }

        private MethodInfo GetEvaluateMethodFromConcreteVisitor(Type visitorType, Type visitableType)
        {
            if (!typeof(Visitor).IsAssignableFrom(visitorType))
                return null;

            MethodInfo method = visitorType.GetMethod("Evaluate",
                                                      BindingFlags.Instance | BindingFlags.NonPublic,
                                                      Type.DefaultBinder,
                                                      new[] { visitableType },
                                                      null);

            return method != null ? method :
                   GetEvaluateMethodFromConcreteVisitor(visitorType.GetType().BaseType, visitableType);

        }
    }
}