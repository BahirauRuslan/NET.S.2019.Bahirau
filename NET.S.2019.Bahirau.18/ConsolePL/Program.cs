using System;
using System.IO;
using System.Xml.Linq;
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
            var exporter = Resolver.Get<IExporter>();

            exporter.ExportAll();

            Console.WriteLine("Text file:");
            using (var reader = new StreamReader(File.OpenRead("uris.txt")))
            {
                string uri;
                while ((uri = reader.ReadLine()) != null)
                {
                    Console.WriteLine(uri);
                }
            }

            Console.WriteLine();
            Console.WriteLine(XDocument.Load("uris.xml"));

            Console.ReadKey();
        }
    }
}
