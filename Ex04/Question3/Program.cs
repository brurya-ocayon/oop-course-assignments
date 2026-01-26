using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<double> row_values = new List<double>();
        List<double> col_values = new List<double>();

        for (int i = 2; i <= 4; i++)
        {
            row_values.Add(1.0 / i);
            col_values.Add(1.0 / i);
        }

        OperationTable<double> table =
            new OperationTable<double>(row_values, col_values, (x, y) => x + y);

        table.Print();
    }
}

class OperationTable<T>
{
    // delegate לפעולה בין שני ערכים מטיפוס T
    public delegate T OpFunc(T x, T y);

    private List<T> rowValues;
    private List<T> colValues;
    private T[,] table;
    private OpFunc op;

    public OperationTable(List<T> row_values, List<T> col_values, OpFunc opFunc)
    {
        rowValues = row_values;
        colValues = col_values;
        op = opFunc;

        table = new T[rowValues.Count, colValues.Count];

        for (int i = 0; i < rowValues.Count; i++)
        {
            for (int j = 0; j < colValues.Count; j++)
            {
                table[i, j] = op(rowValues[i], colValues[j]);
            }
        }
    }

    public void Print()
    {
        Console.Write("\t");
        foreach (var col in colValues)
        {
            Console.Write(col + "\t");
        }
        Console.WriteLine();

        for (int i = 0; i < rowValues.Count; i++)
        {
            Console.Write(rowValues[i] + "\t");
            for (int j = 0; j < colValues.Count; j++)
            {
                Console.Write(table[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}
