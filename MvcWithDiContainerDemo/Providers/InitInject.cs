using MvcWithDiContainerDemo.Data.Entities;
using MvcWithDiContainerDemo.Data.Infrastructure;

namespace MvcWithDiContainerDemo.Providers
{
    public class InitInject
    {
        public static void iocInit()
        {
            Ioc.Init((ker) =>
            {
                ker.Bind<IUnitOfWork>().To<UnitOfWork>().WithConstructorArgument("context", new ApplicationDbContext());
            });
        }
    }
}