using System;

namespace Question01
{
    // Class definition - Reference Type
    public class MyClass
    {
        public int Value;
    }

    // Struct definition - Value Type
    public struct MyStruct
    {
        public int Value;
    }

    internal class Program
    {
        // Helper function to demonstrate passing by value vs reference
        static void ChangeValues(MyClass c, MyStruct s)
        {
            // 'c' refers to the original object memory address
            c.Value = 500;

            // 's' is only a local copy of the original struct
            s.Value = 500;
        }

        // Helper function to modify a struct using the 'ref' keyword
        static void UpdateStructWithRef(ref MyStruct s)
        {
            // 'ref' allows us to access the original memory location
            s.Value = 1000;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("--- Part A.a: Assignment Demonstration ---");

            // Class Example
            MyClass c1 = new MyClass { Value = 10 };
            MyClass c2 = c1;
            c2.Value = 20;
            Console.WriteLine($"Class: c1={c1.Value}, c2={c2.Value}");

            // Struct Example
            MyStruct s1 = new MyStruct { Value = 10 };
            MyStruct s2 = s1;
            s2.Value = 20;
            Console.WriteLine($"Struct: s1={s1.Value}, s2={s2.Value}");

            Console.WriteLine("\n--- Part A.b: Function Parameter Demonstration ---");

            ChangeValues(c1, s1);
            Console.WriteLine($"After Function: Class={c1.Value}, Struct={s1.Value}");

            Console.WriteLine("\n--- Part B: Using 'ref' with Struct ---");

            UpdateStructWithRef(ref s1);
            Console.WriteLine($"Struct after 'ref' update: {s1.Value}");

            // Keeps the console window open
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
