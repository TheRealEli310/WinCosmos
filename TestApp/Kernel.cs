using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sys = Cosmos.System;

namespace TestApp
{
    class Kernel : Sys.Kernel
    {
        #region Boilerplate Code
        static void Main(string[] args)
        {
            Kernel kernel = new Kernel();
            kernel.Start();
        }
        protected override void AfterRun()
        {
            Environment.Exit(0);
        }
        #endregion
        protected override void BeforeRun()
        {
            Console.WriteLine("Cosmos booted successfully. Type a line of text to get it echoed back.");

        }
        protected override void Run()
        {
            Console.Write("Input: ");
            var input = Console.ReadLine();
            Console.Write("Text typed: ");
            Console.WriteLine(input);
        }
    }
}
