using System.CodeDom;
using AOP.Aspects;
using AOP.Database;
using AOP.Services;
using Autofac;
using Autofac.Extras.DynamicProxy2;

namespace AOP
{
    public class DependencyInjection
    {
        public static IContainer Register()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterType<Context>().AsSelf();

            containerBuilder.RegisterType<ItemService>().As<IItemService>()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(TransactionAspect))
                .InterceptedBy(typeof(ChangeArgumentsAspect));


            containerBuilder.RegisterType<TransactionAspect>();
            containerBuilder.RegisterType<ChangeArgumentsAspect>();

            return containerBuilder.Build();
        }
    }
}