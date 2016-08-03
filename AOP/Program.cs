using System;
using System.Transactions;
using AOP.Database;
using AOP.Services;
using Autofac;

namespace AOP
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = DependencyInjection.Register();
            var itemService = container.Resolve<IItemService>();

            var result = itemService.Add(new ItemEntity {Name = "Item7", Quiantity = 10});
          
            Console.ReadKey();
        }
    }
}
