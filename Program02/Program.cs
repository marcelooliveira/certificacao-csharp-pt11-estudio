using System;
using System.Threading;

namespace Program02
{
    class Program
    {
        //Criando uma Thread
        static void Main(string[] args)
        {
            Thread thread = new Thread(Ola);
            thread.Start();
            Console.ReadLine();
        }

        static void Ola()
        {
            Console.WriteLine("Olá, eu sou uma thread!");
            Thread.Sleep(2000);
        }



        //expressão lambda
        //static void Main(string[] args)
        //{
        //    Thread thread = new Thread(() =>
        //    {
        //        Console.WriteLine("Olá, eu sou uma thread!");
        //        Thread.Sleep(1000);
        //    });
        //    thread.Start();
        //    Console.ReadLine();
        //}



        //Passando parâmetros para Threads
        //static void Executar(object data)
        //{
        //    Console.WriteLine("Dados: {0}", data);
        //    Thread.Sleep(1000);
        //}

        //thread parametrizada
        //static void Main(string[] args)
        //{
        //    ParameterizedThreadStart ps = 
        //        new ParameterizedThreadStart(Executar);
        //    Thread thread = new Thread(ps);
        //    thread.Start("Eu sou o parâmetro para a thread!");
        //    Console.ReadLine();
        //}




        //Parâmetros com expressão lambda
        //static void Main(string[] args)
        //{
        //    Thread thread = new Thread((data) =>
        //    {
        //        Executar(data);
        //    });
        //    thread.Start(99);
        //}









        //static bool tickRunning; // flag variable
        //static void Main(string[] args)
        //{
        //    tickRunning = true;
        //    Thread tickThread = new Thread(() =>
        //    {
        //        while (tickRunning)
        //        {
        //            Console.WriteLine("Tick");
        //            Thread.Sleep(1000);
        //        }
        //    });
        //    tickThread.Start();
        //    Console.WriteLine("Press a key to stop the clock");
        //    Console.ReadKey();
        //    tickRunning = false;
        //    Console.WriteLine("Press a key to exit");
        //    Console.ReadKey();
        //}


        //static void Main(string[] args)
        //{
        //    Thread threadToWaitFor = new Thread(() =>
        //    {
        //        Console.WriteLine("Thread starting");
        //        Thread.Sleep(2000);
        //        Console.WriteLine("Thread done");
        //    });
        //    threadToWaitFor.Start();
        //    Console.WriteLine("Joining thread");
        //    threadToWaitFor.Join();
        //    Console.WriteLine("Press a key to exit");
        //    Console.ReadKey();
        //}






        //public static ThreadLocal<Random> RandomGenerator =
        //new ThreadLocal<Random>(() =>
        //{
        //    return new Random(2);
        //});

        //static void Main(string[] args)
        //{
        //    Thread t1 = new Thread(() =>
        //    {
        //        for (int i = 0; i < 5; i++)
        //        {
        //            Console.WriteLine("t1: {0}", RandomGenerator.Value.Next(10));
        //            Thread.Sleep(500);
        //        }
        //    });
        //    Thread t2 = new Thread(() =>
        //    {
        //        for (int i = 0; i < 5; i++)
        //        {
        //            Console.WriteLine("t2: {0}", RandomGenerator.Value.Next(10));
        //            Thread.Sleep(500);
        //        }
        //    });
        //    t1.Start();
        //    t2.Start();
        //    Console.ReadKey();
        //}



        //static void Main(string[] args)
        //{
        //    Thread.CurrentThread.Name = "Main method";
        //    Thread t1 = Thread.CurrentThread;
        //    ExibeThread(t1);
        //    Thread t2 = new Thread(() =>
        //    {
        //        Console.WriteLine("Olá, Mundo");
        //    });
        //    ExibeThread(t2);

        //    Console.ReadLine();
        //}

        //private static void ExibeThread(Thread t)
        //{
        //    Console.WriteLine("Name: {0}", t.Name);
        //    Console.WriteLine("Culture: {0}", t.CurrentCulture);
        //    Console.WriteLine("Priority: {0}", t.Priority);
        //    Console.WriteLine("Contaxt: {0}", t.ExecutionContext);
        //    Console.WriteLine("IsBackground?: {0}", t.IsBackground);
        //    Console.WriteLine("IsPool?: {0}", t.IsThreadPoolThread);
        //}





        //static void DoWork(object state)
        //{
        //    Console.WriteLine("Doing work: {0}", state);
        //    Thread.Sleep(500);
        //    Console.WriteLine("Work finished: {0}", state);
        //}

        //static void Main(string[] args)
        //{
        //    for (int i = 0; i < 50; i++)
        //    {
        //        int stateNumber = i;
        //        ThreadPool.QueueUserWorkItem(state =>
        //        DoWork(stateNumber));
        //    }
        //    Console.ReadKey();
        //}
    }
}
