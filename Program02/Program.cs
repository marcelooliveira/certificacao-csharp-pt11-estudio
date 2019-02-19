using System;
using System.Threading;

namespace Program02
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. Task X Thread

            Thread thread1 = new Thread(Executar);
            thread1.Start();

            //2. Thread com expressão lambda

            Thread thread2 = new Thread(() => Executar());
            thread2.Start();

            //3. Passando parâmetro para thread

            ParameterizedThreadStart ps =
                new ParameterizedThreadStart((p) => 
                ExecutarComParametro(p));

            Thread thread3 = new Thread(ps);
            thread3.Start(123);

            //4. Interrompendo um relógio

            //5. Sincronizando uma thread

            //6. Dados da Thread: Nome, cultura, prioridade, contexto, background, pool

            //7. Usando Thread Pool
            
            Console.ReadLine();
        }

        static void Executar()
        {
            Console.WriteLine("Início da execução");
            Thread.Sleep(1000);
            Console.WriteLine("Fim da execução");
        }


        static void ExecutarComParametro(object param)
        {
            Console.WriteLine("Início da execução: {0}", param);
            Thread.Sleep(1000);
            Console.WriteLine("Fim da execução: {0}", param);
        }
    }
}
