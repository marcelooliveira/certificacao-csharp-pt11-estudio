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
        public static void ExecutarTrabalho(int i)
        {
            Console.WriteLine("Tarefa {0} iniciando", i);

            Thread.Sleep(2000);
            Console.WriteLine("Tarefa {0} terminada", 1);
        }

        static void Main(string[] args)
        {
            Task[] Tarefas = new Task[10];
            for (int i = 0; i < 10; i++)
            {
                int numeroTarefa = i; // cria uma cópia local do contador de loop, para que o
                                // número da tarefa seja passado para a expressão lambda

                Tarefas[i] = Task.Run(() => ExecutarTrabalho(numeroTarefa));
            }

            Task.WaitAll(Tarefas);
            Console.WriteLine("Término do processamento. Tecle algo para terminar.");
            Console.ReadKey();
        }
    }
}
