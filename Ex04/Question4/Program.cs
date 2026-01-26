using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction f1 = new Fraction(8, 12);
        Fraction f2 = new Fraction(1, 3);

        Console.WriteLine(f1);       
        Console.WriteLine(f2);        
        Console.WriteLine(f1 + f2);  
        Console.WriteLine(f1 * f2);   
        Console.WriteLine(f1 / f2);   
        Console.WriteLine(f1 > f2);    
        Console.WriteLine(f1 == f2);  
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

    // מציאת מחלק משותף מקסימלי
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

    // צמצום השבר
    private void Reduce()
    {
        int gcd = GCD(numerator, denominator);
        numerator /= gcd;
        denominator /= gcd;

        if (denominator < 0)
        {
            numerator *= -1;
            denominator *= -1;
        }
    }

    // אופרטורים חשבוניים
    public static Fraction operator +(Fraction a, Fraction b)
    {
        return new Fraction(
            a.numerator * b.denominator + b.numerator * a.denominator,
            a.denominator * b.denominator
        );
    }

    public static Fraction operator *(Fraction a, Fraction b)
    {
        return new Fraction(
            a.numerator * b.numerator,
            a.denominator * b.denominator
        );
    }

    public static Fraction operator /(Fraction a, Fraction b)
    {
        return new Fraction(
            a.numerator * b.denominator,
            a.denominator * b.numerator
        );
    }
    public static Fraction operator -(Fraction a, Fraction b)
    {
        return new Fraction(
            a.numerator * b.denominator - b.numerator * a.denominator,
            a.denominator * b.denominator
        );
    }

    // אופרטורי השוואה
    public static bool operator >(Fraction a, Fraction b)
    {
        return a.numerator * b.denominator > b.numerator * a.denominator;
    }

    public static bool operator <(Fraction a, Fraction b)
    {
        return a.numerator * b.denominator < b.numerator * a.denominator;
    }

    public static bool operator ==(Fraction a, Fraction b)
    {
        return a.numerator == b.numerator && a.denominator == b.denominator;
    }

    public static bool operator !=(Fraction a, Fraction b)
    {
        return !(a == b);
    }

    public override bool Equals(object obj)
    {
        if (obj is Fraction other)
            return this == other;
        return false;
    }

    public override int GetHashCode()
    {
        return numerator.GetHashCode() ^ denominator.GetHashCode();
    }

    public override string ToString()
    {
        return $"{numerator}/{denominator}";
    }
}

