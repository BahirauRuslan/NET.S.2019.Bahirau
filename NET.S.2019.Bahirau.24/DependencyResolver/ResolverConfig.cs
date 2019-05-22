using System.Collections.Generic;
using BLL.Interface.Interfaces;
using BLL.ServiceImplementation;
using DAL.DB;
using DAL.DB.Repositories;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;
using DAL.Repositories;
using Ninject;

namespace DependencyResolver
{
    public static class ResolverConfig
    {
        private static readonly UnitOfWork UnitOfWork = new UnitOfWork();

        public static void ConfigurateResolver(this IKernel kernel)
        {
            UnitOfWork.Holders.Add(new DTOHolder()
            {
                Id = 1,
                Name = "Ruslan",
                Surname = "Borisov",
                Accounts = new List<long>()
            });
            kernel.Bind<IRepository<DTOAccount>>().ToConstant(UnitOfWork.Accounts);
            kernel.Bind<IRepository<DTOHolder>>().ToConstant(UnitOfWork.Holders);

            kernel.Bind<IAccountIdService>().To<AccountIdService>();
            kernel.Bind<IHolderIdService>().To<HolderIdService>();

            kernel.Bind<IAccountService>()
                .To<AccountService>().WithConstructorArgument("accountIdService", kernel.Get<IAccountIdService>())
                .WithConstructorArgument("repository", kernel.Get<IRepository<DTOAccount>>());
            kernel.Bind<IHolderService>()
                .To<HolderService>().WithConstructorArgument("holderIdService", kernel.Get<IHolderIdService>())
                .WithConstructorArgument("repository", kernel.Get<IRepository<DTOHolder>>());
        }
    }
}
