using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Program01._10
{
    class Program
    {
        public static void ExecutarFilha(object state)
        {
            Console.WriteLine("\tTarefa-filha {0} inciando", state);
            Thread.Sleep(2000);
            Console.WriteLine("\tTarefa-filha {0} terminada", state);
        }

        static void Main(string[] args)
        {
            var tarefaMae = Task.Factory.StartNew(() => {
            Console.WriteLine("Tarefa-mãe iniciada");
                for (int i = 0; i < 10; i++)
                {
                    int numeroTarefa = i;
                    Task.Factory.StartNew(
                    (x) => ExecutarFilha(x), // expressão lambda
                    numeroTarefa, // estado
                    TaskCreationOptions.AttachedToParent);
                }
            });
            tarefaMae.Wait(); // aguarda todas as tarefas-filhas terminarem
            Console.WriteLine("Tarefa-mãe terminou. Tecle enter para encerrar.");
            Console.ReadLine();
        }
    }
}
