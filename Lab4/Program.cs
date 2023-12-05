using System;
using System.Security.Cryptography.X509Certificates;

namespace Lab3
{
    internal class Program
    {
        static public void LevelSelect()
        {
            Console.WriteLine();
            Console.WriteLine("Select Level: (1, 2, 3)");
            int level_of_lab = Convert.ToInt32(Console.ReadLine());
            if (level_of_lab == 1)
            {
                Level1();
                LevelSelect();
            }
            if (level_of_lab == 2)
            {
                Level2();
                LevelSelect();
            }
            if (level_of_lab == 3)
            {
                Level3_1();
                LevelSelect();
            }
        }

        public static double[] newarr(int k)
        {
            double[] r = new double[] { };
            for (int i = 0; i < k; i++)
            {
                Console.WriteLine("Введите значение элемента под с индексом {0}", i);
                r = r.Append(Convert.ToDouble(Console.ReadLine())).ToArray();
            }
            return r;
        }

        public static double[,] newmat(int k, int l)
        {
            double[,] m = new double[k, l];
            for (int i = 0; i < k; i++)
            {
                Console.WriteLine("Строка с индексом {0}:", i);
                for (int j = 0; j < l; j++)
                {
                    Console.WriteLine("Введите значение элемента с индексом {0}", j);
                    m[i, j] = Convert.ToDouble(Console.ReadLine());
                }
            }
            return m;
        }

        static public void Level1()
        {

            Console.WriteLine();
            //2
            Console.WriteLine("1_2:");
            double[,] m = newmat(5, 7);
            double s = 0;
            double c = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (m[i, j] > 0)
                    {
                        s += m[i, j];
                        c++;
                    }
                }
            }
            double res = s / c;
            Console.WriteLine("Ответ: {0}", res);

            Console.WriteLine();
            //6
            Console.WriteLine("1_6:");
            m = newmat(4, 7);
            int[] inds = new int[] { };
            int ind_min_row;
            double min_row;
            for (int i = 0; i < 4; i++)
            {
                ind_min_row = 0;
                min_row = m[i, 0];
                for (int j = 0; j < 7; j++)
                {
                    if (m[i, j] < min_row)
                    {
                        ind_min_row = j;
                        min_row = m[i, j];
                    }
                }
                inds = inds.Append(ind_min_row).ToArray();
            }
            Console.WriteLine("Ответ:");
            for (int i = 0; i < inds.Length; i++)
            {
                Console.Write($"{inds[i]} ");
            }
            Console.WriteLine();

            Console.WriteLine();
            //10
            Console.WriteLine("1_10:");
            m = newmat(5, 7);
            ind_min_row = 0;
            min_row = m[0, 2];
            for (int i = 0; i < 5; i++)
            {
                if (m[i, 2] > min_row)
                {
                    ind_min_row = i;
                    min_row = m[i, 2];
                }
            }
            if (ind_min_row != 3)
            {
                for (int j = 0; j < 7; j++)
                {
                    double temp = m[ind_min_row, j];
                    m[ind_min_row, j] = m[3, j];
                    m[3, j] = temp;
                }
            }
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Console.Write($"{m[i, j]} ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            //14
            Console.WriteLine("1_14:");
            m = newmat(4, 3);
            inds = new int[3];
            for (int j = 0; j < 3; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (m[i, j] < 0)
                    {
                        inds[j]++;
                    }
                }
            }
            Console.WriteLine("Ответ:");
            for (int i = 0; i < inds.Length; i++)
            {
                Console.Write($"{inds[i]} ");
            }
            Console.WriteLine();

            Console.WriteLine();
            //18
            Console.WriteLine("1_18:");
            Console.WriteLine("Введите число n:");
            int n_ = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите число m");
            int m_ = Convert.ToInt32(Console.ReadLine());
            m = newmat(n_, m_);
            for (int i = 0; i < n_; i++)
            {
                min_row = double.MinValue;
                ind_min_row = -1;
                int ind_last = -1;
                for (int j = 0; j < m_; j++)
                {
                    if (m[i, j] < 0) { break; }
                    else
                    {
                        if (m[i, j] > min_row)
                        {
                            ind_min_row = j;
                            min_row = m[i, j];
                        }
                    }
                }
                for (int j = 0; j < m_; j++)
                {
                    if (m[i, j] < 0)
                    { 
                        ind_last = j;
                    }
                }
                if (ind_min_row != -1 & ind_last != -1) {
                    double temp = m[i, ind_min_row];
                    m[i, ind_min_row] = m[i, ind_last];
                    m[i, ind_last] = temp;
                }
            }
            for (int i = 0; i < n_; i++)
            {
                for (int j = 0; j < m_; j++)
                {
                    Console.Write($"{m[i, j]} ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            //22
            Console.WriteLine("1_22:");
            m = newmat(6, 8);
            s = 0;
            c = 0;
            int ind_i = 0;
            int ind_j = 0;
            min_row = 0;
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (m[i, j] > 0)
                    {
                        s += m[i, j];
                        c++;
                    }
                    if (m[i, j] > min_row)
                    {
                        min_row = m[i, j];
                        ind_i = i; ind_j = j;
                    }
                }
            }
            res = s / c;
            m[ind_i, ind_j] = res;
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Console.Write($"{m[i, j]} ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            //26
            Console.WriteLine("1_26:");
            m = newmat(5, 7);
            Console.WriteLine("Массив B:");
            double[] b = newarr(7);
            ind_min_row = 0;
            min_row = double.MinValue;
            for (int i = 0; i < 5; i++)
            {
                if (m[i, 5] > min_row)
                {
                    ind_min_row = i;
                    min_row = m[i, 5];
                }
            }
            for (int i = 0; i < 7; i++)
            {
                m[ind_min_row, i] = b[i];
            }
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Console.Write($"{m[i, j]} ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            //30
            Console.WriteLine("1_30:");
            m = newmat(5, 5);
            min_row = double.MinValue;
            ind_min_row = 0;
            for (int i = 0; i < 5; i++)
            {
                if (m[i, i] > min_row)
                {
                    ind_min_row = i;
                    min_row = m[i, i];
                }
            }
            int ind_first = 0;
            for (int i = 0; i < 5; i++)
            {
                if (m[i, 2] < 0)
                {
                    ind_first = i;
                    break;
                }
            }
            for (int j = 0; j < 5; j++)
            {
                double temp = m[ind_min_row, j];
                m[ind_min_row, j] = m[ind_first, j];
                m[ind_first, j] = temp;
            }
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write($"{m[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        static public void Level2()
        {

            Console.WriteLine();
            //2
            double[,] m = newmat(7, 5);
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write($"{m[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("----------------------");
            for (int j = 0; j < 5; j++)
            {
                int cpos = 0;
                int cneg = 0;
                double ma = double.MinValue;
                int maind = -1;
                for (int i = 0; i < 7; i++)
                {
                    if (m[i, j] > 0) { cpos++; }
                    else { cneg++; }
                    if (m[i, j] > ma)
                    {
                        ma = m[i, j];
                        maind = i;
                    }
                }
                if (cpos > cneg)
                {
                    m[maind, j] = 0;
                }
                else
                {
                    m[maind, j] = maind + 1;
                }
            }
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write($"{m[i, j]} ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("");
            //6
            Console.WriteLine("Введите число n:");
            int n = Convert.ToInt32(Console.ReadLine());
            m = new double[n, 3 * n];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    m[j, j + i*n] = 1;
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < 3*n; j++)
                {
                    Console.Write($"{m[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        static public void Level3_1()
        {
            
        }

        static void Main(string[] args)
        {
            LevelSelect();
        }
    }
}