using System;
using System.Transactions;
using Castle.DynamicProxy;

namespace AOP.Aspects
{
    public class TransactionAspect : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine($"{invocation.Method.Name} method invoked");

            using (var transaction = new TransactionScope())
            {
                try
                {
                    invocation.Proceed();
                    transaction.Complete();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error has occured: {ex.Message}");
                }
            }

            Console.WriteLine($"{invocation.Method.Name} method finished");
        }
    }
}