using System.Collections.Generic;
using BLL.Interface.Interfaces;
using BLL.ServiceImplementation;
using DAL.DB;
using DAL.DB.Repositories;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;
using Ninject;

namespace DependencyResolver
{
    public static class ResolverConfig
    {
        private static readonly UnitOfWork UnitOfWork = new UnitOfWork();

        public static void ConfigurateResolver(this IKernel kernel)
        {
            kernel.Bind<IRepository<DTOAccount>>().ToConstant(UnitOfWork.Accounts);
            kernel.Bind<IRepository<DTOHolder>>().ToConstant(UnitOfWork.Holders);
            kernel.Bind<IRepository<DTOAccountType>>().ToConstant(UnitOfWork.AccountTypes);
            kernel.Bind<IRepository<DTONotification>>().ToConstant(UnitOfWork.Notifications);

            kernel.Bind<IAccountService>()
                .To<AccountService>().WithConstructorArgument("repository", kernel.Get<IRepository<DTOAccount>>());
            kernel.Bind<IAccountTypeService>()
                .To<AccountTypeService>().WithConstructorArgument("repository", kernel.Get<IRepository<DTOAccountType>>());
            kernel.Bind<IHolderService>()
                .To<HolderService>().WithConstructorArgument("repository", kernel.Get<IRepository<DTOHolder>>());
            kernel.Bind<INotificationService>()
                .To<NotificationService>().WithConstructorArgument("repository", kernel.Get<IRepository<DTONotification>>());
        }
    }
}
