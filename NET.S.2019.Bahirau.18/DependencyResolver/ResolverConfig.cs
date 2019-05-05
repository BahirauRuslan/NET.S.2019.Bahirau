/*using BLL.Interface.Interfaces;
using BLL.ServiceImplementation;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;
using DAL.Repositories;*/
using Ninject;

namespace DependencyResolver
{
    public static class ResolverConfig
    {
        public static void ConfigurateResolver(this IKernel kernel)
        {/*
            kernel.Bind<IRepository<DTOAccount>>()
                .To<AccountBinaryFileRepository>().WithConstructorArgument("filePath", "accounts.bin");
            kernel.Bind<IRepository<DTOHolder>>()
                .To<HolderBinaryFileRepository>().WithConstructorArgument("filePath", "holders.bin");

            kernel.Bind<IAccountIdService>().To<AccountIdService>();
            kernel.Bind<IHolderIdService>().To<HolderIdService>();

            kernel.Bind<IAccountService>()
                .To<AccountService>().WithConstructorArgument("accountIdService", kernel.Get<IAccountIdService>())
                .WithConstructorArgument("repository", kernel.Get<IRepository<DTOAccount>>());
            kernel.Bind<IHolderService>()
                .To<HolderService>().WithConstructorArgument("holderIdService", kernel.Get<IHolderIdService>())
                .WithConstructorArgument("repository", kernel.Get<IRepository<DTOHolder>>());*/
        }
    }
}
