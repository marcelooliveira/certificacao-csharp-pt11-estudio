using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Program01._04
{
    class Program
    {
        static void Main(string[] args)
        {
            var items = Enumerable.Range(0, 100).ToArray();
            ParallelLoopResult result = Parallel.For(0, items.
            Count(), (int i, ParallelLoopState loopState) =>
            {
                if (i == 75)
                    loopState.Stop();

                Processar(items[i]);
            });
            Console.WriteLine("Completado? " + result.IsCompleted);
            Console.WriteLine("No. de itens processados: " + result.LowestBreakIteration);
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


