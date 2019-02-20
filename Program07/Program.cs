﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Program07
{
    class Program
    {
        static long sharedTotal;
        //static object sharedTotalLock = new object();
        // make an array that holds the values 0 to 5000000
        static int[] items = Enumerable.Range(0, 500001).ToArray();
        static void addRangeOfValues(int start, int end)
        {
            while (start < end)
            {
                //lock(sharedTotalLock)
                //{
                    sharedTotal = sharedTotal + items[start];
                //}
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
            Console.ReadLine();
        }
    }
}
