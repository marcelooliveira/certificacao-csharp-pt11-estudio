using System;
using System.Threading;
using System.Threading.Tasks;

namespace Program07_01
{
    //Cancelar uma tarefa de execução longa
    class Program
    {
        static CancellationTokenSource cancellationTokenSource =
            new CancellationTokenSource();

        static void Relogio()
        {
            while (!cancellationTokenSource.IsCancellationRequested)
            {
                Console.WriteLine("Tic");
                Thread.Sleep(500);
                Console.WriteLine("Tac");
                Thread.Sleep(500);
            }
        }

        static void Main(string[] args)
        {
            Task relogio = Task.Run(() => Relogio());
            Console.WriteLine("Tecle algo para parar o relógio");
            Console.ReadKey();
            cancellationTokenSource.Cancel();
            relogio.Wait();
            Console.WriteLine("O relógio parou.");

            Console.ReadLine();
        }
    }
}
