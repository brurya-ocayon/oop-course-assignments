using Ex02Solution;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

Exercise4.Run();
namespace Ex02Solution
{
    internal class Exercise4
    {




        public static void Run()
        {
            int n = 50_000_000;
            int[] arr = new int[n];

            // Scenario A: two tasks write to disjoint halves
            var sw = Stopwatch.StartNew();
            Task t1 = Task.Run(() => { for (int i = 0; i < n / 2; i++) arr[i]++; });
            Task t2 = Task.Run(() => { for (int i = n / 2; i < n; i++) arr[i]++; });
            Task.WaitAll(t1, t2);
            sw.Stop();
            Console.WriteLine($"Disjoint halves: {sw.ElapsedMilliseconds} ms");

            // Scenario B: two tasks write over entire array (interleaved regions)
            sw.Restart();
            Task t3 = Task.Run(() => { for (int i = 0; i < n; i += 2) arr[i]++; });
            Task t4 = Task.Run(() => { for (int i = 1; i < n; i += 2) arr[i]++; });
            Task.WaitAll(t3, t4);
            sw.Stop();
            Console.WriteLine($"Interleaved (every other): {sw.ElapsedMilliseconds} ms");

            // Scenario C: both tasks scan full array and write the same positions (simulate contention)
            sw.Restart();
            Task t5 = Task.Run(() => { for (int i = 0; i < n; i++) arr[i]++; });
            Task t6 = Task.Run(() => { for (int i = 0; i < n; i++) arr[i]++; });
            Task.WaitAll(t5, t6);
            sw.Stop();
            Console.WriteLine($"Both full-scan (high contention): {sw.ElapsedMilliseconds} ms");
        }
    }

}


