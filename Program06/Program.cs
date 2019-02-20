﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Program06
{
    class Program
    {
        //// make an array that holds the values 0 to 50000000
        //static int[] items = Enumerable.Range(0, 50000001).ToArray();
        //static void Main(string[] args)
        //{
        //    long total = 0;
        //    for (int i = 0; i < items.Length; i++)
        //        total = total + items[i];
        //    Console.WriteLine("The total is: {0}", total);
        //    Console.ReadKey();
        //    Console.ReadLine();
        //}





        static long sharedTotal;
        // make an array that holds the values 0 to 5000000
        static int[] items = Enumerable.Range(0, 500001).ToArray();
        static void addRangeOfValues(int start, int end)
        {
            while (start < end)
            {
                sharedTotal = sharedTotal + items[start];
                start++;
            }
        }

        static void Main(string[] args)
        {
            List<Task> tasks = new List<Task>();
            int rangeSize = 1000;
            int rangeStart = 0;


            while (rangeStart < items.Length)
            {
                int rangeEnd = rangeStart + rangeSize;
                if (rangeEnd > items.Length)
                    rangeEnd = items.Length;

                // create local copies of the parameters
                int rs = rangeStart;
                int re = rangeEnd;
                tasks.Add(Task.Run(() => addRangeOfValues(rs, re)));
                rangeStart = rangeEnd;
            }
            Task.WaitAll(tasks.ToArray());
            Console.WriteLine("The total is: {0}", sharedTotal);
            Console.ReadKey();
        }
    }
}
