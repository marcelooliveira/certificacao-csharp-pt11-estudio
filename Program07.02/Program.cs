using System;
using System.Threading;
using System.Threading.Tasks;

namespace Program07._02
{
    //Lançando uma exceção quando a tarefa é cancelada
    class Program
    {
        static void Relogio(CancellationToken cancellationToken)
        {
            int tiques = 0;

            while (!cancellationToken.IsCancellationRequested 
                && tiques < 20)
            {
                tiques++;
                Console.WriteLine("Tic");
                Thread.Sleep(500);
                Console.WriteLine("Tac");
                Thread.Sleep(500);
            }
            cancellationToken.ThrowIfCancellationRequested();
        }

        static void Main(string[] args)
        {
            CancellationTokenSource cancellationTokenSource
                = new CancellationTokenSource();

            Task relogio = Task.Run(() => Relogio(cancellationTokenSource.Token));

            Console.WriteLine("Tecle algo para parar o relógio");
            Console.ReadKey();

            if (relogio.IsCompleted)
            {
                Console.WriteLine("Tarefa do relógio foi completada.");
            }
            else
            {
                try
                {
                    cancellationTokenSource.Cancel();
                    relogio.Wait();
                }
                catch (AggregateException ex)
                {
                    Console.WriteLine("Relógio parou: {0}", 
                        ex.InnerExceptions[0].ToString());
                }
            }

            Console.ReadLine();
        }
    }
}
