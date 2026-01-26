using System;

namespace Delegates
{
    class Program
    {
        public class ArrayProcessor
        {
            public delegate void UnaryAction(double a);

            public static void ProcessArray(double[] array, UnaryAction processor)
            {
                foreach (double item in array)
                {
                    processor(item);
                }
            }
        }
        public class SumCalculator
        {
            public double Sum { get; private set; } = 0;

            public void AddToSum(double a)
            {
                Sum += a;
            }
        }

        public class MaxCalculator
        {
            public double Max { get; private set; } = double.MinValue;

            public void CheckMax(double a)
            {
                if (a > Max)
                    Max = a;
            }
        }
        static void Main(string[] args)
        {
            double[] arr = new double[10];
            Random rnd = new Random();

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(1, 101);
            }

            SumCalculator sumCalc = new SumCalculator();
            MaxCalculator maxCalc = new MaxCalculator();

            ArrayProcessor.ProcessArray(arr, sumCalc.AddToSum);
            ArrayProcessor.ProcessArray(arr, maxCalc.CheckMax);

            Console.WriteLine("Sum: " + sumCalc.Sum);
            Console.WriteLine("Max: " + maxCalc.Max);
            double sum = 0;
            double max = double.MinValue;

            ArrayProcessor.ProcessArray(arr, a => sum += a);
            ArrayProcessor.ProcessArray(arr, a =>
            {
                if (a > max)
                    max = a;
            });

            Console.WriteLine("Sum (lambda): " + sum);
            Console.WriteLine("Max (lambda): " + max);

        }

    }

}

