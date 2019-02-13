using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Program01
{
    //Task Parallel com Parallel.For / PLINQ / Tasks
    class Program
    {
        static void Main(string[] args)
        {
            CozinharMacarrao();
            RefogarMolho();
            Console.WriteLine();

            Console.WriteLine("Retire do fogo e arrume sobre o macarrão. Bom apetite! Tecle [ENTER] para terminar.");
            Console.ReadLine();
        }

        //static void Main(string[] args)
        //{
        //    CozinharMacarrao();
        //    RefogarMolho();
        //    Console.WriteLine();

        //    Parallel.Invoke(() => CozinharMacarrao(), () => RefogarMolho());
        //    Console.WriteLine();

        //    Console.WriteLine("Retire do fogo e arrume sobre o macarrão. Bom apetite! Tecle [ENTER] para terminar.");
        //    Console.ReadLine();
        //}

        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Iniciando processamento em série");
        //    CozinharMacarrao();
        //    RefogarMolho();
        //    Console.WriteLine();

        //    Console.WriteLine("Iniciando processamento em paralelo");
        //    Parallel.Invoke(() => CozinharMacarrao(), () => RefogarMolho());
        //    Console.WriteLine();

        //    Console.WriteLine("Retire do fogo e arrume sobre o macarrão. Bom apetite! Tecle [ENTER] para terminar.");
        //    Console.ReadLine();
        //}

        //static void Main(string[] args)
        //{
        //    Stopwatch sw = new Stopwatch();
        //    Console.WriteLine("Iniciando processamento em série");
        //    sw.Start();
        //    CozinharMacarrao();
        //    RefogarMolho();
        //    sw.Stop();
        //    Console.WriteLine("Tempo decorrido: {0} segundos.", (sw.Elapsed.TotalMilliseconds / 1000.0));
        //    Console.WriteLine();
        //    sw.Restart();
        //    Console.WriteLine("Iniciando processamento em paralelo");
        //    Parallel.Invoke(() => CozinharMacarrao(), () => RefogarMolho());
        //    sw.Stop();
        //    Console.WriteLine("Tempo decorrido: {0} segundos.", (sw.Elapsed.TotalMilliseconds / 1000.0));
        //    Console.WriteLine();

        //    Console.WriteLine("Retire do fogo e arrume sobre o macarrão. Bom apetite! Tecle [ENTER] para terminar.");
        //    Console.ReadLine();
        //}

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
