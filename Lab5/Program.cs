using System;
using System.Security.Cryptography.X509Certificates;

namespace Lab5
{
    internal class Program
    {
        public static double[] pop(double[] data, int x)
        {
            double[] result = new double[data.Length - 1];
            int k = 0;
            for (int i = 0; i < data.Length; i++)
            {
                if (i != x) { result[i - k] = data[i]; }
                else if (i == x) { k++; }
            }
            return result;
        }

        public static int max_col_ind(double[,] data)
        {
            int result = 0;
            double ma = data[0, 0];
            for (int j = 0; j < data.GetLength(1); j++)
            {
                for (int i = 0; i < data.GetLength(0); i++)
                {
                    if (data[i, j] > ma) { result = j; ma = data[i, j]; }
                }
            }
            return result;
        }

        public static double[,] diag_sort(double[,] data)
        {
            double[] diag = new double[data.GetLength(0)];
            for (int i = 0; i < data.GetLength(0); i++) { diag[i] = data[i, i]; }
            for (int i = 0; i < diag.Length - 1; i++)
            {
                for (int j = i + 1; j < diag.Length; j++)
                {
                    if (diag[i] > diag[j])
                    {
                        double temp = diag[i];
                        diag[i] = diag[j];
                        diag[j] = temp;
                    }
                }
            }
            for (int i = 0; i < data.GetLength(0); i++) { data[i, i] = diag[i]; }
            return data;
        }

        static void Main(string[] args)
        {
            //6
            double[] a = { 4, 5, 3, -12, 3, -2, 6 };
            double[] b = { 23, 4, 3, 12, -23, 4, -12, 3 };
            int indma = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] > a[indma]) { indma = i; }
            }
            a = pop(a, indma);
            indma = 0;
            for (int i = 0; i < b.Length; i++)
            {
                if (b[i] > b[indma]) { indma = i; }
            }
            b = pop(b, indma);
            for (int i = 0; i < b.Length; i++)
            {
                a = a.Append(b[i]).ToArray();
            }
            Console.WriteLine("6:");
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write($"{a[i]} ");
            }
            Console.WriteLine();

            Console.WriteLine();
            //12
            double[,] arr1 = { { -12, 16, 74, -42, -2},
                                {15, 50, 15, -27, -92},
                                {- 37, 16, 81, 10, 45},
                                {39, 91, -77, -92, 63},
                                {72, 51, -52, -47, 11}
                             };
            double[,] arr2 = { { -51, 49, -20, -56, -22},
                                {-89, -15, 54, -61, 16},
                                {4, 73, 78, -65, 3},
                                {4, -34, -62, 10, 43},
                                {-56, -6, -24, -51, 2}
                             };
            int ind1 = max_col_ind(arr1);
            int ind2 = max_col_ind(arr2);
            for (int i = 0; i < arr1.GetLength(0); i++)
            {
                double temp = arr1[i, ind1];
                arr1[i, ind1] = arr2[i, ind2];
                arr2[i, ind2] = temp;
            }
            Console.WriteLine("12:");
            for (int i = 0; i < arr1.GetLength(0); i++)
            {
                for (int j = 0; j < arr1.GetLength(1); j++)
                {
                    Console.Write($"{arr1[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("-----------------");
            for (int i = 0; i < arr2.GetLength(0); i++)
            {
                for (int j = 0; j < arr2.GetLength(1); j++)
                {
                    Console.Write($"{arr2[i, j]} ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            //18
            double[,] res1 = diag_sort(arr1);
            double[,] res2 = diag_sort(arr2);
            Console.WriteLine("18:");
            for (int i = 0; i < res1.GetLength(0); i++)
            {
                for (int j = 0; j < res1.GetLength(1); j++)
                {
                    Console.Write($"{res1[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("-----------------");
            for (int i = 0; i < res2.GetLength(0); i++)
            {
                for (int j = 0; j < res2.GetLength(1); j++)
                {
                    Console.Write($"{res2[i, j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}