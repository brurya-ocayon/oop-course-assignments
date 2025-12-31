using System;

struct SmallStruct
{
    public int A;
}

struct LargeStruct
{
    public int A;
    public double B;
    public long C;
}

class SmallClass
{
    public int A;
}

class LargeClass
{
    public int A;
    public double B;
    public long C;
}

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Section 6(a): Primitive Arrays ===");
        PrimitiveArrays();

        Console.WriteLine("\n=== Section 6(b): Struct Arrays ===");
        StructArrays();

        Console.WriteLine("\n=== Section 6(c): Class Arrays ===");
        ClassArrays();
    }

    static void PrimitiveArrays()
    {
        long before = GC.GetAllocatedBytesForCurrentThread();

        int[] intArray = new int[10000];
        long afterInt = GC.GetAllocatedBytesForCurrentThread();

        double[] doubleArray = new double[10000];
        long afterDouble = GC.GetAllocatedBytesForCurrentThread();

        Console.WriteLine($"int[] allocation: {afterInt - before} bytes");
        Console.WriteLine($"double[] allocation: {afterDouble - afterInt} bytes");
    }

    static void StructArrays()
    {
        long before = GC.GetAllocatedBytesForCurrentThread();

        SmallStruct[] small = new SmallStruct[10000];
        long afterSmall = GC.GetAllocatedBytesForCurrentThread();

        LargeStruct[] large = new LargeStruct[10000];
        long afterLarge = GC.GetAllocatedBytesForCurrentThread();

        Console.WriteLine($"SmallStruct[] allocation: {afterSmall - before} bytes");
        Console.WriteLine($"LargeStruct[] allocation: {afterLarge - afterSmall} bytes");
    }

    static void ClassArrays()
    {
        long before = GC.GetAllocatedBytesForCurrentThread();

        SmallClass[] small = new SmallClass[10000];
        for (int i = 0; i < small.Length; i++)
            small[i] = new SmallClass();

        long afterSmall = GC.GetAllocatedBytesForCurrentThread();

        LargeClass[] large = new LargeClass[10000];
        for (int i = 0; i < large.Length; i++)
            large[i] = new LargeClass();

        long afterLarge = GC.GetAllocatedBytesForCurrentThread();

        Console.WriteLine($"SmallClass[] allocation: {afterSmall - before} bytes");
        Console.WriteLine($"LargeClass[] allocation: {afterLarge - afterSmall} bytes");
    }
}

