using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Program01._08
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("System.Diagnostics.Process.GetCurrentProcess().Threads: {0}", System.Diagnostics.Process.GetCurrentProcess().Threads.Count); ;

            Task[] Tarefas = new Task[10];
            for (int i = 0; i < 10; i++)
            {
                int numeroTarefa = i; // cria uma cópia local do contador de loop, para que o
                                      // número da tarefa seja passado para a expressão lambda

                Tarefas[i] = Task.Run(() => ExecutarTrabalho(numeroTarefa));
            }

            Task.WaitAll(Tarefas);

            Console.WriteLine("System.Diagnostics.Process.GetCurrentProcess().Threads: {0}", System.Diagnostics.Process.GetCurrentProcess().Threads.Count); ;
            Console.ReadLine();

            Console.WriteLine("Término do processamento. Tecle [ENTER] para terminar.");
            Console.ReadLine();
        }

        public static void ExecutarTrabalho(int i)
        {
            Console.WriteLine("Tarefa {0} iniciando", i);

            Thread.Sleep(1000);
            Console.WriteLine("Tarefa {0} terminada", i);
        }
    }
}
