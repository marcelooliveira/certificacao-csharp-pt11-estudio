using System;
using System.Collections.Generic;
using System.IO;
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
            //throw new Exception();
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
            task.ContinueWith((tarefaAnterior) =>
            { // Get the antecedent's exception information.
                foreach (var ex in tarefaAnterior.Exception.InnerExceptions)
                {
                    if (ex is FileNotFoundException)
                        Console.WriteLine(ex.Message);
                }
            }, TaskContinuationOptions.OnlyOnFaulted);

            Console.ReadLine();
        }
    }
}
