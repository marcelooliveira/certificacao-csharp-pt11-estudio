using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Program01._03
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
            Parallel.For(0, items.Length, i =>
            {
                WorkOnItem(items[i]);
            });
            Console.WriteLine("Término do processamento. Tecle [ENTER] para terminar.");
        
            Console.ReadLine();
        }

    }
}



