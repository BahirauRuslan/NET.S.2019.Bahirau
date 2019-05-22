using System;
using BLL.Interface.Interfaces;
using DependencyResolver;
using Ninject;

namespace ConsolePL
{
    internal class Program
    {
        private static readonly IKernel Resolver;

        static Program()
        {
            Resolver = new StandardKernel();
            Resolver.ConfigurateResolver();
        }

        internal static void Main()
        {
            var accountService = Resolver.Get<IAccountService>();
            var holderService = Resolver.Get<IHolderService>();

            holderService.AddHolder("Ruslan", "Bahirau");

            foreach (var holder in holderService.GetAllHolders())
            {
                Console.WriteLine(holder);
                accountService.AddAccount(holder, "Gold");
            }

            foreach (var holder in holderService.GetAllHolders())
            {
                Console.WriteLine(holder);
            }

            accountService.UpdateAll();
            holderService.UpdateAll();

            Console.ReadKey();
        }
    }
}
