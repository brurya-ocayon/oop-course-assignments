using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Fraction> values = new List<Fraction>();

        for (int i = 1; i <= 12; i++)
        {
            values.Add(new Fraction(i, 12));
        }

        OperationTable<Fraction> table =
            new OperationTable<Fraction>(values, values, (x, y) => x + y);

        table.Print();
    }
}

class OperationTable<T>
{
    public delegate T OpFunc(T x, T y);

    private List<T> rowValues;
    private List<T> colValues;
    private T[,] table;
    private OpFunc op;

    public OperationTable(List<T> rowValues, List<T> colValues, OpFunc op)
    {
        this.rowValues = rowValues;
        this.colValues = colValues;
        this.op = op;

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

class Fraction
{
    private int numerator;
    private int denominator;

    public Fraction(int numerator, int denominator)
    {
        if (denominator == 0)
            throw new ArgumentException("Denominator cannot be zero");

        this.numerator = numerator;
        this.denominator = denominator;
        Reduce();
    }

    private int GCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return Math.Abs(a);
    }

    private void Reduce()
    {
        int gcd = GCD(numerator, denominator);
        numerator /= gcd;
        denominator /= gcd;
    }

    public static Fraction operator +(Fraction a, Fraction b)
    {
        return new Fraction(
            a.numerator * b.denominator + b.numerator * a.denominator,
            a.denominator * b.denominator
        );
    }

    public override string ToString()
    {
        return $"{numerator}/{denominator}";
    }
}

