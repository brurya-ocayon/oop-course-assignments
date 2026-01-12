using System;
using System.Diagnostics;


Exercise1.Run();

public static class Exercise1
{
    public static void Run()
    {
        Console.WriteLine("Info:");
        Console.WriteLine($"  Int32.MaxValue = {Int32.MaxValue:N0}");
        Console.WriteLine($"  Process is 64-bit: {Environment.Is64BitProcess}");
        Console.WriteLine($"  OS is 64-bit: {Environment.Is64BitOperatingSystem}");
        Console.WriteLine();

        TryAllocate("small", 10_000);
        TryAllocate("medium", 10_000_000);
        TryAllocate("large-ish", 200_000_000);
        TryAllocate("very-large", Int32.MaxValue);
    }

    static void TryAllocate(string name, int length)
    {
        Console.WriteLine($"Attempting allocation '{name}' length = {length:N0} ...");
        try
        {
            var sw = Stopwatch.StartNew();
            int[] a = new int[length];
            sw.Stop();
            Console.WriteLine($"  Allocated {length:N0} ints (approx {length * 4L / (1024 * 1024)} MB) in {sw.Elapsed.TotalMilliseconds} ms");
            a[0] = 1;
            a[a.Length - 1] = 1;
        }
        catch (OutOfMemoryException)
        {
            Console.WriteLine("  OutOfMemoryException: cannot allocate.");
        }
        catch (OverflowException oe)
        {
            Console.WriteLine($"  OverflowException: {oe.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"  Exception: {ex.GetType().Name} - {ex.Message}");
        }
        Console.WriteLine();
    }
}





