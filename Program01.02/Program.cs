using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Program01._02
{
    class Program
    {
        static void WorkOnItem(object item)
        {
            Console.WriteLine("Começando a trabalhar com: " + item);
            Thread.Sleep(100);
            Console.WriteLine("Terminando a trabalhar com: " + item);
        }

        static void Main(string[] args)
        {
            var items = Enumerable.Range(0, 100);
            Stopwatch sw = new Stopwatch();

            Console.WriteLine("Iniciando processamento em série");
            sw.Start();
            foreach(var item in items)
            {
                WorkOnItem(item);
            }
            sw.Stop();
            Console.WriteLine("Tempo decorrido: {0} segundos.", (sw.Elapsed.TotalMilliseconds / 1000.0));
            Console.WriteLine();
            sw.Restart();

            Console.WriteLine("Iniciando processamento paralelo");
            Parallel.ForEach(items, item =>
            {
                WorkOnItem(item);
            });
            sw.Stop();
            Console.WriteLine("Tempo decorrido: {0} segundos.", (sw.Elapsed.TotalMilliseconds / 1000.0));

            Console.WriteLine("Término do processamento. Tecle [ENTER] para terminar.");
            Console.ReadLine();
        }
    }
}
