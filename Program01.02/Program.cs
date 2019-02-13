using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Program01._02
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    var items = Enumerable.Range(0, 100);
        //    Console.WriteLine("Iniciando processamento em série");
        //    foreach (var item in items)
        //    {
        //        Processar(item);
        //    }
        //    Console.WriteLine();

        //    Console.WriteLine("Término do processamento. Tecle [ENTER] para terminar.");
        //    Console.ReadLine();
        //}

        //static void Main(string[] args)
        //{
        //    var items = Enumerable.Range(0, 100);
        //    Console.WriteLine("Iniciando processamento em série");
        //    foreach (var item in items)
        //    {
        //        Processar(item);
        //    }
        //    Console.WriteLine();

        //    Console.WriteLine("Iniciando processamento paralelo");
        //    Parallel.ForEach(items, item =>
        //    {
        //        Processar(item);
        //    });

        //    Console.WriteLine("Término do processamento. Tecle [ENTER] para terminar.");
        //    Console.ReadLine();
        //}

        //static void Main(string[] args)
        //{
        //    var items = Enumerable.Range(0, 100);
        //    Stopwatch sw = new Stopwatch();

        //    Console.WriteLine("Iniciando processamento em série");
        //    sw.Start();
        //    foreach(var item in items)
        //    {
        //        Processar(item);
        //    }
        //    sw.Stop();
        //    Console.WriteLine("Tempo decorrido: {0} segundos.", (sw.Elapsed.TotalMilliseconds / 1000.0));
        //    Console.WriteLine();
        //    sw.Restart();

        //    Console.WriteLine("Iniciando processamento paralelo");
        //    Parallel.ForEach(items, item =>
        //    {
        //        Processar(item);
        //    });
        //    sw.Stop();
        //    Console.WriteLine("Tempo decorrido: {0} segundos.", (sw.Elapsed.TotalMilliseconds / 1000.0));

        //    Console.WriteLine("Término do processamento. Tecle [ENTER] para terminar.");
        //    Console.ReadLine();
        //}


        static void Main(string[] args)
        {
            var items = Enumerable.Range(0, 100).ToArray();
            Stopwatch sw = new Stopwatch();

            Console.WriteLine("Iniciando processamento em série");
            sw.Start();
            foreach (var item in items)
            {
                Processar(item);
            }
            sw.Stop();
            Console.WriteLine("Tempo decorrido: {0} segundos.", (sw.Elapsed.TotalMilliseconds / 1000.0));
            Console.WriteLine();
            sw.Restart();

            Console.WriteLine("Iniciando processamento paralelo");
            Parallel.For(0, items.Length, i =>
            {
                Processar(items[i]);
            });
            sw.Stop();
            Console.WriteLine("Tempo decorrido: {0} segundos.", (sw.Elapsed.TotalMilliseconds / 1000.0));

            Console.WriteLine("Término do processamento. Tecle [ENTER] para terminar.");
            Console.ReadLine();
        }

        static void Processar(object item)
        {
            Console.WriteLine("Começando a trabalhar com: " + item);
            Thread.Sleep(100);
            Console.WriteLine("Terminando a trabalhar com: " + item);
        }
    }
}
