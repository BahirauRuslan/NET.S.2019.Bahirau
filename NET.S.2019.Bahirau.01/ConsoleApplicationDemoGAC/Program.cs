using System;
using ClassLibraryDemoStrongName;

namespace ConsoleApplicationDemoGAC
{
    class Program
    {
        static void Main(string[] args)
        {
            var product = new Product(25, "Pink hat");
            Console.WriteLine(product);
            Console.ReadKey();
        }
    }
}
