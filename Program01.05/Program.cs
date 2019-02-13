using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Program01._06
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task novaTarefa = new Task(() => ExecutaTrabalho());
            //novaTarefa.Start();
            //novaTarefa.Wait();

            //Task novaTarefa = Task.Run(() => ExecutaTrabalho());
            //novaTarefa.Wait();

            Task<int> tarefa = Task.Run(() =>
            {
                return CalcularResultado();
            });

            Console.WriteLine(tarefa.Result);
            Console.WriteLine("Término do processamento. Tecle [ENTER] para terminar.");
            Console.ReadLine();
        }

        public static void ExecutaTrabalho()
        {
            Console.WriteLine("Trabalho iniciado");
            Thread.Sleep(2000);
            Console.WriteLine("Trabalho terminado");
        }

        public static int CalcularResultado()
        {
            Console.WriteLine("Trabalho iniciado");
            Thread.Sleep(2000);
            Console.WriteLine("Trabalho terminado");
            return 55;
        }
    }
}
