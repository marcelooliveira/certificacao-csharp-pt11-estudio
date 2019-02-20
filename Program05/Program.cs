﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Program05_01
{
    //Gerenciar dados usando coleções simultâneas
    class Program
    {
        static void Main(string[] args)
        {
            //Queue<int> colecao = new Queue<int>(5);
            BlockingCollection<int> colecao = new BlockingCollection<int>(5);

            var tarefa1 =
            Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    //colecao.Enqueue(i);
                    colecao.Add(i);
                    Console.WriteLine("Item {0} adicionado com sucesso.", i);
                }

                //Sinaliza que a BlockingCollection
                //não deve receber mais itens
                colecao.CompleteAdding();
            });

            Console.ReadKey();
            Console.WriteLine("Lendo a coleção...");

            Task.Run(() =>
            {
                try
                {
                    for (int i = 0; i < 10; i++)
                    {
                        //Remove um item da BlockingCollection
                        int v = colecao.Take();
                        //int v = colecao.Dequeue();
                        Console.WriteLine("Item {0} removido com sucesso.", v);
                    }
                }
                catch (InvalidOperationException exc)
                {
                }
            });

            Console.ReadLine();
        }
    }
}
