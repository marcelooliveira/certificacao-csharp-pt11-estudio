using System;
using System.Threading;
using System.Threading.Tasks;

namespace Program01
{
    //Task Parallel com Parallel.For / PLINQ / Tasks
    class Program
    {
        static void Main(string[] args)
        {
            Parallel.Invoke(() => CozinharMacarrao(), () => RefogarMolho());
            Console.WriteLine("Retire do fogo e arrume sobre o macarrão. Bom apetite! Tecle [ENTER] para terminar.");

            Console.ReadLine();
        }

        static void CozinharMacarrao()
        {
            Console.WriteLine("Cozinhando macarrão...");
            Thread.Sleep(1000);
            Console.WriteLine("Macarrão já está cozido!");
        }

        static void RefogarMolho()
        {
            Console.WriteLine("Refogando molho...");
            Thread.Sleep(2000);
            Console.WriteLine("Molho já está refogado!");
        }
    }
}
