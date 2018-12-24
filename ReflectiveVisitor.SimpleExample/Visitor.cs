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

            var methodName = "Evaluate";
            var visitableType = visitable.GetType();

            while ((typeof(IVisitable).IsAssignableFrom(visitableType)))
            {
                Type visitorType = GetType();
                while ((typeof(Visitor).IsAssignableFrom(visitorType)))
                {
                    MethodInfo method = visitorType.GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic,
                                                          Type.DefaultBinder,
                                                          new[] { visitableType },
                                                          null);

                    if (method != null)
                        return method;
                    else
                        visitorType = visitorType.GetType().BaseType;
                }
                visitableType = visitableType.GetType().BaseType;
            }

            return null;
        }
    }
}