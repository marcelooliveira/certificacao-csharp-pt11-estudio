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
            Parallel.Invoke(() => Tarefa1(), () => Tarefa2());
            Console.WriteLine("Fim do processamento. Tecle algo para terminar.");

            Console.ReadLine();
        }

        static void Tarefa1()
        {
            Console.WriteLine("Tarefa 1 iniciando");
            Thread.Sleep(2000);
            Console.WriteLine("Tarefa 1 terminando");
        }

        static void Tarefa2()
        {
            Console.WriteLine("Task 2 iniciando");
            Thread.Sleep(1000);
            Console.WriteLine("Task 2 terminando");
        }
    }
}
