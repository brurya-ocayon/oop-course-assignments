using System;
using System.Collections.Generic; 

namespace Question7
{
    public delegate T GenericOperation<T>(T x, T y);

    public class OperationTable<T>
    {
        
        private List<T> rows;
        private List<T> cols;
        private GenericOperation<T> operation;

        
        public OperationTable(List<T> rows, List<T> cols, GenericOperation<T> op)
        {
            this.rows = rows;
            this.cols = cols;
            this.operation = op;
        }

        public void Print()
        {
            foreach (T r in rows)
            {
                foreach (T c in cols)
                {
                    T result = operation(r, c);
                    Console.Write(result + "\t");
                }
                Console.WriteLine();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
           
            List<int> rows = new List<int> { 1, 2, 3 };
            List<int> cols = new List<int> { 1, 2, 3 };

            OperationTable<int> multTable =
                new OperationTable<int>(rows, cols, (x, y) => x * y);

            Console.WriteLine("Multiplication Table:");
            multTable.Print();

            Console.WriteLine();

            List<double> dRows = new List<double> { 1.5, 2.5 };
            List<double> dCols = new List<double> { 2.0, 3.0 };

            OperationTable<double> addTable =
                new OperationTable<double>(dRows, dCols, (x, y) => x + y);

            Console.WriteLine("Addition Table (double):");
            addTable.Print();
        }
    }
}
