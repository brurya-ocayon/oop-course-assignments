using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

Exercise3.Run();
public static class Exercise3
{
    public static void Run()
    {

        void SwapInArray(int[] arr, int i, int j)
        {
            int tmp = arr[i];
            arr[i] = arr[j];
            arr[j] = tmp;
        }
        void SwapGeneric<T>(ref T a, ref T b)
        {
            T tmp = a;
            a = b;
            b = tmp;


        }
    }
}

