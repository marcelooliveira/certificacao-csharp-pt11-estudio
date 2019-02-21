using System;
using System.Threading;

namespace Program08
{
    //Implementar métodos thread-safe
    class Program
    {
        class Contador
        {
            public int Numero { get; private set; } = 0;

            public void Incrementar()
            {
                Numero++;
            }
        }

        static void Main(string[] args)
        {
            var contador = new Contador();

            Console.WriteLine("contador: {0}", contador.Numero);

            Thread thread1 = new Thread(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    contador.Incrementar();
                    Thread.Sleep(i);
                }
            });
            thread1.Start();

            Thread thread2 = new Thread(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    contador.Incrementar();
                    Thread.Sleep(i);
                }
            });
            thread2.Start();

            thread1.Join();
            thread2.Join();

            Console.WriteLine("contador: {0}", contador.Numero);

            Console.ReadLine();
        }
    }
}
