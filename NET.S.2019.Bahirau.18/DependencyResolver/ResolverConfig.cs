using BLL.Interface.Interfaces;
using BLL.ServiceImplementation;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;
using DAL.Loggers;
using DAL.Repositories;
using Ninject;

namespace DependencyResolver
{
    public static class ResolverConfig
    {
        public static void ConfigurateResolver(this IKernel kernel)
        {
            kernel.Bind<IReadableRepository<string>>()
                .To<TextReadableRepository>().WithConstructorArgument("filePath", "uris.txt");
            kernel.Bind<IWriteableRepository<DTOSimpleURI>>()
                .To<XMLWriteableRepository>().WithConstructorArgument("filePath", "uris.xml");

            kernel.Bind<ILogger>().To<NInfoLogger>();

            kernel.Bind<IExporter>()
                .To<Exporter>()
                .WithConstructorArgument("fromRepository", kernel.Get<IReadableRepository<string>>())
                .WithConstructorArgument("toRepository", kernel.Get<IWriteableRepository<DTOSimpleURI>>())
                .WithConstructorArgument("logger", kernel.Get<NInfoLogger>());
        }
    }
}
