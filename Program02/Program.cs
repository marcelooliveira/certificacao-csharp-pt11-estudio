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
            thread1.Join();

            //2. Thread com expressão lambda

            Thread thread2 = new Thread(() => Executar());
            thread2.Start();
            thread2.Join();
            //3. Passando parâmetro para thread

            ParameterizedThreadStart ps =
                new ParameterizedThreadStart((p) => 
                ExecutarComParametro(p));

            Thread thread3 = new Thread(ps);
            thread3.Start(123);
            thread3.Join();
            //4. Interrompendo um relógio

            bool relogioFuncionando = true;
            Thread thread4 = new Thread(() => 
            {
                while (relogioFuncionando)
                {
                    Console.WriteLine("tic");
                    Thread.Sleep(1000);
                    Console.WriteLine("tac");
                    Thread.Sleep(1000);
                }
            });
            thread4.Start();
            
            Console.WriteLine("Tecle algo para interromper.");
            Console.ReadKey();
            relogioFuncionando = false;
            thread4.Join();

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
