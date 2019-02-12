using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Program01._09
{
    class Program
    {
        public static void OlaTask()
        {
            Thread.Sleep(1000);
            Console.WriteLine("Olá");
        }

        public static void MundoTask()
        {
            Thread.Sleep(1000);
            Console.WriteLine("Mundo");
        }

        public static void ExceptionTask()
        {
            Thread.Sleep(1000);
            Console.WriteLine("Falha na tarefa!");
        }

        static void Main(string[] args)
        {
            //Task tarefa = Task.Run(() => OlaTask());
            //tarefa.ContinueWith((tarefaAnterior) => MundoTask());
            //Console.WriteLine("Término do processamento. Tecle [ENTER] para terminar.");

            Task task = Task.Run(() => OlaTask());
            task.ContinueWith((tarefaAnterior) => MundoTask(), TaskContinuationOptions.OnlyOnRanToCompletion);
            task.ContinueWith((tarefaAnterior) => ExceptionTask(), TaskContinuationOptions.OnlyOnFaulted);

            Console.ReadLine();
        }
    }
}
