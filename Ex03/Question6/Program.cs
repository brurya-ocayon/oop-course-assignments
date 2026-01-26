using System;

namespace Question6
{

    public delegate int IntOperation(int x, int y);

    public class OperationTable
    {
        private int startRow;
        private int endRow;
        private int startCol;
        private int endCol;
        private IntOperation operation;

     
        public OperationTable(int start_row, int end_row,
                              int start_col, int end_col,
                              IntOperation op)
        {
            startRow = start_row;
            endRow = end_row;
            startCol = start_col;
            endCol = end_col;
            operation = op;
        }


        public void Print()
        {
            for (int i = startRow; i <= endRow; i++)
            {
                for (int j = startCol; j <= endCol; j++)
                {
                    int result = operation(i, j);
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
        
            OperationTable multTable =
                new OperationTable(1, 5, 1, 5, (x, y) => x * y);

            Console.WriteLine("Multiplication Table:");
            multTable.Print();

            Console.WriteLine();

        
            OperationTable addTable =
                new OperationTable(1, 5, 1, 5, (x, y) => x + y);

            Console.WriteLine("Addition Table:");
            addTable.Print();
        }
    }
}


