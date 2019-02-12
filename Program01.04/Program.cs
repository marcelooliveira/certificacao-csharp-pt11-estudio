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
        static void WorkOnItem(object item)
        {
            Console.WriteLine("Começando a trabalhar com: " + item);
            Thread.Sleep(100);
            Console.WriteLine("Terminando a trabalhar com: " + item);
        }

        static void Main(string[] args)
        {
            var items = Enumerable.Range(0, 500).ToArray();
            ParallelLoopResult result = Parallel.For(0, items.
            Count(), (int i, ParallelLoopState loopState) =>
            {
                if (i == 200)
                    loopState.Stop();

                WorkOnItem(items[i]);
            });
            Console.WriteLine("Completado? " + result.IsCompleted);
            Console.WriteLine("No. de itens: " + result.LowestBreakIteration);
            Console.WriteLine("Término do processamento. Tecle algo para terminar.");
            Console.ReadLine();
        }
    }
}


