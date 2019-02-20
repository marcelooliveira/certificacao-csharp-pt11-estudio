using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Program05_01
{
    //Gerenciar dados usando coleções simultâneas
    class Program
    {
        static void Mainxxx(string[] args)
        {
            //Queue<int> colecao = new Queue<int>(5);
            //BlockingCollection<int> colecao = new BlockingCollection<int>(5);
            ConcurrentQueue<int> colecao = new ConcurrentQueue<int>();

            var tarefa1 =
            Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    int item = i;
                    colecao.Enqueue(item);
                    //colecao.Add(i);
                    Console.WriteLine("Item {0} adicionado com sucesso.", item);
                }

                //Sinaliza que a BlockingCollection
                //não deve receber mais itens
                //colecao.CompleteAdding();
            });

            //Console.ReadKey();
            Console.WriteLine("Lendo a coleção...");

            Task.Run(() =>
            {
                try
                {
                    for (int i = 0; i < 10; i++)
                    {
                        //Remove um item da BlockingCollection
                        //int v = colecao.Take();
                        colecao.TryDequeue(out int v);
                        Console.WriteLine("Item {0} removido com sucesso.", v);
                    }
                }
                catch (InvalidOperationException exc)
                {
                }
            });

            Console.ReadLine();
        }

        static void Mainyyy()
        {
            // We know how many items we want to insert into the ConcurrentDictionary.
            // So set the initial capacity to some prime number above that, to ensure that
            // the ConcurrentDictionary does not need to be resized while initializing it.
            int NUMITEMS = 64;
            int initialCapacity = 101;

            // The higher the concurrencyLevel, the higher the theoretical number of operations
            // that could be performed concurrently on the ConcurrentDictionary.  However, global
            // operations like resizing the dictionary take longer as the concurrencyLevel rises. 
            // For the purposes of this example, we'll compromise at numCores * 2.
            int numProcs = Environment.ProcessorCount;
            int concurrencyLevel = numProcs * 2;

            // Construct the dictionary with the desired concurrencyLevel and initialCapacity
            //ConcurrentDictionary<int, int> cd = new ConcurrentDictionary<int, int>(concurrencyLevel, initialCapacity);
            Dictionary<int, int> cd = new Dictionary<int, int>(initialCapacity);

            // Initialize the dictionary
            for (int i = 0; i < NUMITEMS; i++) cd[i] = i * i;

            Console.WriteLine("The square of 23 is {0} (should be {1})", cd[23], 23 * 23);

            Console.ReadLine();
        }

        static void Mainzzz()
        {
            // Construct a ConcurrentQueue.
            ConcurrentQueue<int> cq = new ConcurrentQueue<int>();

            // Populate the queue.
            for (int i = 0; i < 10000; i++)
            {
                cq.Enqueue(i);
            }

            // Peek at the first element.
            int result;
            if (!cq.TryPeek(out result))
            {
                Console.WriteLine("CQ: TryPeek failed when it should have succeeded");
            }
            else if (result != 0)
            {
                Console.WriteLine("CQ: Expected TryPeek result of 0, got {0}", result);
            }

            int outerSum = 0;
            // An action to consume the ConcurrentQueue.
            Action action = () =>
            {
                int localSum = 0;
                int localValue;
                while (cq.TryDequeue(out localValue)) localSum += localValue;
                Interlocked.Add(ref outerSum, localSum);
            };

            // Start 4 concurrent consuming actions.
            Parallel.Invoke(action, action, action, action);

            Console.WriteLine("outerSum = {0}, should be 49995000", outerSum);
            Console.ReadLine();

        }

        static async Task Main()
        {
            int items = 10000;

            ConcurrentStack<int> stack = new ConcurrentStack<int>();

            // Create an action to push items onto the stack
            Action pusher = () =>
            {
                for (int i = 0; i < items; i++)
                {
                    stack.Push(i);
                }
            };

            // Run the action once
            pusher();

            if (stack.TryPeek(out int result))
            {
                Console.WriteLine($"TryPeek() saw {result} on top of the stack.");
            }
            else
            {
                Console.WriteLine("Could not peek most recently added number.");
            }

            // Empty the stack
            stack.Clear();

            if (stack.IsEmpty)
            {
                Console.WriteLine("Cleared the stack.");
            }

            // Create an action to push and pop items
            Action pushAndPop = () =>
            {
                Console.WriteLine($"Task started on {Task.CurrentId}");

                int item;
                for (int i = 0; i < items; i++)
                    stack.Push(i);
                for (int i = 0; i < items; i++)
                    stack.TryPop(out item);

                Console.WriteLine($"Task ended on {Task.CurrentId}");
            };

            // Spin up five concurrent tasks of the action
            var tasks = new Task[5];
            for (int i = 0; i < tasks.Length; i++)
                tasks[i] = Task.Factory.StartNew(pushAndPop);

            // Wait for all the tasks to finish up
            await Task.WhenAll(tasks);

            if (!stack.IsEmpty)
            {
                Console.WriteLine("Did not take all the items off the stack");
            }

            Console.ReadLine();
        }
    }
}
