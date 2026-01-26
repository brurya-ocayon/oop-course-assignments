using System;

namespace DelegatesExample
{
    class Program
    {
       
        public delegate double BinaryOperation(double x, double y);

        public static double Add(double x, double y)
        {
            return x + y;
        }

        public static double Subtract(double x, double y)
        {
            return x - y;
        }

        public static double Multiply(double x, double y)
        {
            return x * y;
        }

      
        public static double ApplyOperation(BinaryOperation bOp, double a, double b)
        {
            return bOp(a, b);
        }

      
        static void Main(string[] args)
        {
            double r1 = ApplyOperation(Add, 5, 3);
            double r2 = ApplyOperation(Subtract, 5, 3);
            double r3 = ApplyOperation(Multiply, 5, 3);

            Console.WriteLine(r1); 
            Console.WriteLine(r2);
            Console.WriteLine(r3); 
        }
    }
}
