using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

Exercise2.Run();
public static class Exercise2
{
    
    public static void Run()
    {


        int n = 50_000_000; // 50M ints -> ~200MB
        Console.WriteLine($"Allocating array of {n:N0} ints (~{n * 4L / (1024 * 1024)} MB)");
        int[] arr = new int[n];
        // Initialize to ensure pages committed
        for (int i = 0; i < n; i += 4096) arr[i] = i;

        WarmUp();

        Console.WriteLine("Sequential access test:");
        MeasureSequential(arr);

        Console.WriteLine("Strided access tests:");
        foreach (int stride in new int[] { 1, 8, 64, 1024, 4096 })
        {
            MeasureStride(arr, stride);
        }
    }

    static void WarmUp()
    {
        // Small warm-up to load JIT etc.
        int[] tmp = new int[1024 * 16];
        for (int i = 0; i < tmp.Length; i++) tmp[i] = i;
    }

    static void MeasureSequential(int[] arr)
    {
        var sw = Stopwatch.StartNew();
        long sum = 0;
        for (int i = 0; i < arr.Length; i++)
            sum += arr[i];
        sw.Stop();
        Console.WriteLine($"  Time sequential: {sw.Elapsed.TotalMilliseconds:N0} ms, sum={sum}");
    }

    static void MeasureStride(int[] arr, int stride)
    {
        var sw = Stopwatch.StartNew();
        long sum = 0;
        int n = arr.Length;
        for (int i = 0; i < n; i += stride)
            sum += arr[i];
        sw.Stop();
        Console.WriteLine($"  Stride {stride,5}: {sw.Elapsed.TotalMilliseconds:N0} ms, sum={sum}");
    }
}




