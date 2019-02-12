using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Program01._07
{
    class Program
    {
        public static int CalcularResultado()
        {
            Console.WriteLine("Trabalho iniciado");
            Thread.Sleep(2000);
            Console.WriteLine("Trabalho terminado");
            return 55;
        }

        static void Main(string[] args)
        {
            Task<int> tarefa = Task.Run(() =>
            {
                return CalcularResultado();
            });

            Console.WriteLine(tarefa.Result);
            Console.WriteLine("Término do processamento. Tecle [ENTER] para terminar.");
            Console.ReadLine();
        }
    }
}
