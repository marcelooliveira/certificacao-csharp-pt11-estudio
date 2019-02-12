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
            //Task novaTarefa = new Task(() => DoWork());
            //novaTarefa.Start();
            //novaTarefa.Wait();

            Task novaTarefa = Task.Run(() => ExecutaTrabalho());
            novaTarefa.Wait();
        }

        public static void ExecutaTrabalho()
        {
            Console.WriteLine("Trabalho iniciado");
            Thread.Sleep(2000);
            Console.WriteLine("Trabalho terminado");
        }
    }
}
