using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Program01._08
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Término do processamento. Tecle [ENTER] para terminar.");
            Console.ReadLine();
        }

        public static void Correr(int numeroCorredor)
        {
            Console.WriteLine("Corredor {0} largou", numeroCorredor);

            Thread.Sleep(1000);
            Console.WriteLine("Corredor {0} terminou", numeroCorredor);
        }
    }
}
