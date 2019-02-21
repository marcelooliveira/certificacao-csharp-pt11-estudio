using System;
using System.Threading;
using System.Threading.Tasks;

namespace Program07._02
{
    //Lançando uma exceção quando a tarefa é cancelada
    class Program
    {
        static CancellationTokenSource cancellationTokenSource
            = new CancellationTokenSource();

        static void Main(string[] args)
        {
            Console.WriteLine("Tecle algo para parar o relógio");
            Task relogio = new Task(() => Relogio(), cancellationTokenSource.Token);
            relogio.Start();
            Console.ReadKey();
            Console.WriteLine("O relógio parou.");
            cancellationTokenSource.Cancel();
            Console.ReadLine();
        }

        static void Relogio()
        {
            while (true)
            {
                Console.WriteLine("Tic");
                Thread.Sleep(500);
                Console.WriteLine("Tac");
                Thread.Sleep(500);
            }
        }

    }
}