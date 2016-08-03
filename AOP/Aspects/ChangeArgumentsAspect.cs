using AOP.Database;
using Castle.DynamicProxy;

namespace AOP.Aspects
{
    public class ChangeArgumentsAspect : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var arguments = invocation.Arguments;

            foreach (var argument in arguments)
            {
                ItemEntity itemEntity;

                if ((itemEntity = argument as ItemEntity) != null)
                    itemEntity.Name += "| Name changed by interceptor";
            }

            invocation.Proceed();

            var result = invocation.ReturnValue as ItemEntity;

            if (result != null) result.Quiantity = 420;
        }
    }
}