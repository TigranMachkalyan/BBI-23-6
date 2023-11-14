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

        static public void Level1()
        {
            Console.WriteLine();
            //1
            Console.WriteLine("1_1:");
            double[] ar = newarr(6);
            double sum = ar.Sum();
            for (int i = 0; i < ar.Length; i++)
            {
                ar[i] = ar[i] / sum;
            }
            Console.WriteLine();
            for (int i = 0; i < ar.Length; i++)
            {
                Console.WriteLine(ar[i]);
            }

            Console.WriteLine();
            //2
            Console.WriteLine("1_2:");
            ar = newarr(8);
            double sumforavg = 0;
            double cforavg = 0;
            for (int i = 0; i < ar.Length; i++)
            {
                if (ar[i] > 0)
                {
                    sumforavg += ar[i];
                    cforavg++;
                }
            }
            double avg = sumforavg / cforavg;
            for (int i = 0; i < ar.Length; i++)
            {
                if (ar[i] > 0)
                {
                    ar[i] = avg;
                }
            }
            Console.WriteLine();
            for (int i = 0; i < ar.Length; i++)
            {
                Console.WriteLine(ar[i]);
            }

            Console.WriteLine();
            //3
            Console.WriteLine("1_3:");
            Console.WriteLine("Первый массив:");
            double[] ar1 = newarr(4);
            Console.WriteLine("Второй массив:");
            double[] ar2 = newarr(4);
            double[] ars = new double[] { };
            double[] ard = new double[] { };
            for (int i = 0; i < ar1.Length; i++)
            {
                ars = ars.Append(ar1[i] + ar2[i]).ToArray();
                ard = ard.Append(ar1[i] - ar2[i]).ToArray();
            }
            Console.WriteLine();
            Console.WriteLine("Сумма:");
            for (int i = 0; i < ars.Length; i++)
            {
                Console.WriteLine(ars[i]);
            }
            Console.WriteLine();
            Console.WriteLine("Разность:");
            for (int i = 0; i < ard.Length; i++)
            {
                Console.WriteLine(ard[i]);
            }

            Console.WriteLine();
            //4
            Console.WriteLine("1_4:");
            ar = newarr(5);
            avg = ar.Average();
            for (int i = 0; i < ar.Length; i++)
            {
                ar[i] = ar[i] - avg;
            }
            Console.WriteLine();
            for (int i = 0; i < ar.Length; i++)
            {
                Console.WriteLine(ar[i]);
            }

            Console.WriteLine();
            //5
            Console.WriteLine("1_5:");
            Console.WriteLine("Первый массив:");
            ar1 = newarr(4);
            Console.WriteLine("Второй массив:");
            ar2 = newarr(4);
            double s = 0;
            for (int i = 0; i < ar1.Length; i++)
            {
                s += ar1[i] * ar2[i];
            }
            Console.WriteLine();
            Console.WriteLine("Скалярное произведение:\n{0}", s);


            Console.WriteLine();
            //6
            Console.WriteLine("1_6:");
            ar = newarr(5);
            double l = 0;
            for (int i = 0; i < ar.Length; i++)
            {
                l += ar[i] * ar[i];
            }
            Console.WriteLine("Длина:\n{0}", Math.Sqrt(l));

            Console.WriteLine();
            //7
            Console.WriteLine("1_7:");
            ar = newarr(7);
            avg = ar.Average();
            for (int i = 0; i < ar.Length; i++)
            {
                if (ar[i] > avg)
                {
                    ar[i] = 0;
                }
            }
            Console.WriteLine();
            for (int i = 0; i < ar.Length; i++)
            {
                Console.WriteLine(ar[i]);
            }

            Console.WriteLine();
            //8
            Console.WriteLine("1_8:");
            ar = newarr(6);
            s = 0;
            for (int i = 0; i < ar.Length; i++)
            {
                if (ar[i] < 0)
                {
                    s++;
                }
            }
            Console.WriteLine();
            Console.WriteLine("Количество отрицательных элементов заданного массива: {0}", s);

            Console.WriteLine();
            //9
            Console.WriteLine("1_9:");
            ar = newarr(8);
            s = 0;
            avg = ar.Average();
            for (int i = 0; i < ar.Length; i++)
            {
                if (ar[i] > avg)
                {
                    s++;
                }
            }
            Console.WriteLine();
            Console.WriteLine("Количество элементов заданного массива больше среднего: {0}", s);

            Console.WriteLine();
            //10
            Console.WriteLine("1_10:");
            ar = newarr(10);
            s = 0;
            Console.WriteLine("Введите P:");
            double p = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите Q (P < Q):");
            double q = Convert.ToDouble(Console.ReadLine());
            for (int i = 0; i < ar.Length; i++)
            {
                if (ar[i] > p & ar[i] < q)
                {
                    s++;
                }
            }
            Console.WriteLine();
            Console.WriteLine("Количество элементов заданного массива заключенных между P и Q: {0}", s);

            Console.WriteLine();
            //11
            Console.WriteLine("1_11:");
            ar = newarr(10);
            s = 0;
            for (int i = 0; i < ar.Length; i++)
            {
                if (ar[i] > 0)
                {
                    s++;
                }
            }
            ar1 = new double[] { };
            for (int i = 0; i < ar.Length; i++)
            {
                if (ar[i] > 0)
                {
                    ar1 = ar1.Append(ar[i]).ToArray();
                }
            }
            Console.WriteLine();
            for (int i = 0; i < ar1.Length; i++)
            {
                Console.WriteLine(ar1[i]);
            }


            Console.WriteLine();
            //12
            Console.WriteLine("1_12:");
            ar = newarr(8);
            s = 0;
            int c = 0;
            for (int i = 0; i < ar.Length; i++)
            {
                if (ar[i] < 0)
                {
                    s = ar[i];
                    c = i;
                }
            }
            Console.WriteLine("Значение: {0}, номер: {1} ({2})", s, c, c+1);

            Console.WriteLine();
            //13
            Console.WriteLine("1_13:");
            ar = newarr(10);
            ar1 = new double[] { };
            ar2 = new double[] { };
            for (int i = 0; i < ar.Length; i++)
            {
                if (i % 2 == 0)
                {
                    ar2 = ar2.Append(ar[i]).ToArray();
                }
                else
                    ar1 = ar1.Append(ar[i]).ToArray();
                {
                }
            }
            Console.WriteLine("Первый массив:");
            for (int i = 0; i < ar2.Length; i++)
            {
                Console.WriteLine(ar2[i]);
            }
            Console.WriteLine("Второй массив:");
            for (int i = 0; i < ar1.Length; i++)
            {
                Console.WriteLine(ar1[i]);
            }

            Console.WriteLine();
            //14
            Console.WriteLine("1_14:");
            ar = newarr(11);
            s = 0;
            for (int i = 0; i < ar.Length; i++)
            {
                if (ar[i] >= 0)
                {
                    s += ar[i] * ar[i];
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine("Сумма квадратов элементов, расположенных до первого отрицательного элемента массива: {0}", s);

            Console.WriteLine();
            //15
            Console.WriteLine("1_15:");
            ar = newarr(10);
            ar1 = new double[] { };
            for (int i = 0; i < ar.Length; i++)
            {
                double y = 0.5 * Math.Log(ar[i]);
                ar1 = ar1.Append(y).ToArray();
            }
            Console.WriteLine();
            for (int i = 0; i < ar1.Length; i++)
            {
                Console.WriteLine(ar1[i]);
            }
        }

        static public void Level2()
        {
            //in
            Console.WriteLine("Введите массив для всего второго уровня:");
            Console.WriteLine("Введите количество элементов массива:");
            int n = int.Parse(Console.ReadLine());
            double[] ar1 = newarr(n);

            Console.WriteLine();
            //1
            double[] ar = ar1.Take(ar1.Length).ToArray();
            double min_elem = double.MaxValue;
            int min_ind = 0;
            for (int i = 0; i < ar.Length; i++)
            {
                if (ar[i] < min_elem)
                {
                min_elem = ar[i];
                min_ind = i;
                }
            }
            ar[min_ind] = 2*min_elem;
            Console.WriteLine("2_1:");
            for (int i = 0; i < ar.Length; i++)
            {
                Console.Write($"{ar[i]} ");
            }

            Console.WriteLine("\n");
            //2
            ar = ar1.Take(ar1.Length).ToArray();
            double max_elem = double.MinValue;
            int max_ind = 0;
            for (int i = 0; i < ar.Length; i++)
            {
                if (ar[i] > max_elem)
                {
                    max_elem = ar[i];
                    max_ind = i;
                }
            }
            double s = 0;
            for (int i = 0; i < max_ind; i++)
            {
                s += ar[i];
            }
            Console.WriteLine("2_2:\n{0}", s);

            Console.WriteLine();
            //3
            ar = ar1.Take(ar1.Length).ToArray();
            min_elem = double.MaxValue;
            min_ind = 0;
            for (int i = 0; i < ar.Length; i++)
            {
                if (ar[i] < min_elem)
                {
                    min_elem = ar[i];
                    min_ind = i;
                }
            }
            for (int i = 0; i < min_ind; i++)
            {
                ar[i] = 2 * ar[i];
            }
            Console.WriteLine("2_3:");
            for (int i = 0; i < ar.Length; i++)
            {
                Console.Write($"{ar[i]} ");
            }


            Console.WriteLine("\n");
            //4
            ar = ar1.Take(ar1.Length).ToArray();
            max_elem = double.MinValue;
            max_ind = 0;
            for (int i = 0; i < ar.Length; i++)
            {
                if (ar[i] > max_elem)
                {
                    max_elem = ar[i];
                    max_ind = i;
                }
            }
            double avg = ar.Average();
            for (int i = max_ind + 1; i < ar.Length; i++)
            {
                ar[i] = avg;
            }
            Console.WriteLine("2_4:");
            for (int i = 0; i < ar.Length; i++)
            {
                Console.Write($"{ar[i]} ");
            }

            Console.WriteLine("\n");
            //5
            ar = ar1.Take(ar1.Length).ToArray();
            max_elem = double.MinValue;
            max_ind = 0;
            min_elem = double.MaxValue;
            min_ind = 0;
            for (int i = 0; i < ar.Length; i++)
            {
                if (ar[i] > max_elem)
                {
                    max_elem = ar[i];
                    max_ind = i;
                }
                if (ar[i] < min_elem)
                {
                    min_elem = ar[i];
                    min_ind = i;
                }
            }
            int a;
            int b;
            if (min_ind < max_ind)
            {
                 a = min_ind;
                 b = max_ind;
            }
            else
            {
                a = max_ind;
                b = min_ind;
            }
            double[] ar2 = new double[] { };
            for (int i = a + 1; i < b; i++)
            {
                if (ar[i] < 0)
                {
                    ar2 = ar2.Append(ar[i]).ToArray();
                }
            }
            Console.WriteLine("2_5:");
            for (int i = 0; i < ar2.Length; i++)
            {
                Console.Write($"{ar2[i]} ");
            }

            Console.WriteLine("\n");
            //6
            ar = ar1.Take(ar1.Length).ToArray();
            Console.WriteLine("Введите число P:");
            double p = double.Parse(Console.ReadLine());
            avg = ar.Average();
            double min_dif = double.MaxValue;
            int nearest_ind = 0;
            for (int i = 0; i < ar.Length; i++)
            {
                if (Math.Abs(ar[i]-avg) < min_dif)
                {
                    min_dif = Math.Abs(ar[i] - avg);
                    nearest_ind = i;
                }
            }
            ar = ar.Append(ar[ar.Length - 1]).ToArray();
            for (int i = ar.Length - 1; i > nearest_ind + 1; i--)
            {
                ar[i] = ar[i - 1];
            }
            ar[nearest_ind + 1] = p;
            Console.WriteLine();
            Console.WriteLine("2_6:");
            for (int i = 0; i < ar.Length; i++)
            {
                Console.Write($"{ar[i]} ");
            }

            Console.WriteLine("\n");
            //7
            ar = ar1.Take(ar1.Length).ToArray();
            max_elem = double.MinValue;
            max_ind = 0;
            for (int i = 0; i < ar.Length; i++)
            {
                if (ar[i] > max_elem)
                {
                    max_elem = ar[i];
                    max_ind = i;
                }
            }
            if (max_ind != ar.Length - 1)
            {
                ar[max_ind + 1] = 2 * ar[max_ind + 1];
                Console.WriteLine("2_7:");
                for (int i = 0; i < ar.Length; i++)
                {
                    Console.Write($"{ar[i]} ");
                }
            }
            else
            {
                Console.WriteLine("2_7:\nМаксимальный элемент последний в массиве");
            }
            

            Console.WriteLine("\n");
            //8
            ar = ar1.Take(ar1.Length).ToArray();
            max_elem = double.MinValue;
            max_ind = 0;
            for (int i = 0; i < ar.Length; i++)
            {
                if (ar[i] > max_elem)
                {
                    max_elem = ar[i];
                    max_ind = i;
                }
            }
            min_elem = double.MaxValue;
            min_ind = 0;
            for (int i = max_ind + 1; i < ar.Length; i++)
            {
                if (ar[i] < min_elem)
                {
                    min_elem = ar[i];
                    min_ind = i;
                }
            }
            ar[max_ind] = min_elem;
            ar[min_ind] = max_elem;
            Console.WriteLine("2_8:");
            for (int i = 0; i < ar.Length; i++)
            {
                Console.Write($"{ar[i]} ");
            }

            Console.WriteLine("\n");
            //9
            ar = ar1.Take(ar1.Length).ToArray();
            max_elem = double.MinValue;
            max_ind = 0;
            min_elem = double.MaxValue;
            min_ind = 0;
            for (int i = 0; i < ar.Length; i++)
            {
                if (ar[i] > max_elem)
                {
                    max_elem = ar[i];
                    max_ind = i;
                }
                if (ar[i] < min_elem)
                {
                    min_elem = ar[i];
                    min_ind = i;
                }
            }
            if (min_ind < max_ind)
            {
                a = min_ind;
                b = max_ind;
            }
            else
            {
                a = max_ind;
                b = min_ind;
            }
            s = 0;
            double c = 0;
            for (int i = a + 1; i < b; i++)
            {
                s += ar[i];
                c++;
            }
            avg = s / c;
            Console.WriteLine("2_9:\n{0}", avg);

            Console.WriteLine();
            //10
            ar = ar1.Take(ar1.Length).ToArray();
            min_elem = double.MaxValue;
            min_ind = 0;
            for (int i = 0; i < ar.Length; i++)
            {
                if (ar[i] < min_elem & ar[i] > 0)
                {
                    min_elem = ar[i];
                    min_ind = i;
                }
            }
            ar2 = new double[] { };
            for (int i = 0; i < ar.Length; i++)
            {
                if (i != min_ind)
                {
                    ar2 = ar2.Append(ar[i]).ToArray();
                }
            }
            Console.WriteLine("2_10:");
            for (int i = 0; i < ar2.Length; i++)
            {
                Console.Write($"{ar2[i]} ");
            }

            Console.WriteLine("\n");
            //11
            ar = ar1.Take(ar1.Length).ToArray();
            int last = 0;
            for (int i = 0; i < ar.Length; i++)
            {
                if (ar[i] > 0) { last = i; }
            }
            ar = ar.Append(ar[ar.Length - 1]).ToArray();
            for (int i = ar.Length - 1; i > last + 1; i--)
            {
                ar[i] = ar[i - 1];
            }
            ar[last + 1] = p;
            Console.WriteLine("2_11:");
            for (int i = 0; i < ar.Length; i++)
            {
                Console.Write($"{ar[i]} ");
            }

            Console.WriteLine("\n");
            //12
            ar = ar1.Take(ar1.Length).ToArray();
            max_elem = double.MinValue;
            max_ind = 0;
            for (int i = 0; i < ar.Length; i++)
            {
                if (ar[i] > max_elem)
                {
                    max_elem = ar[i];
                    max_ind = i;
                }
            }
            s = 0;
            for (int i = max_ind; i < ar.Length; i++)
            {
                s += ar[i];
            }
            for (int i = 0; i < ar.Length; i++)
            {
                if (ar[i] < 0) { ar[i] = s; break; }
            }
            Console.WriteLine("2_12:");
            for (int i = 0; i < ar.Length; i++)
            {
                Console.Write($"{ar[i]} ");
            }

            Console.WriteLine("\n");
            //13
            ar = ar1.Take(ar1.Length).ToArray();
            max_elem = double.MinValue;
            max_ind = 0;
            for (int i = 0; i < ar.Length; i+=2)
            {
                if (ar[i] > max_elem)
                {
                    max_elem = ar[i];
                    max_ind = i;
                }
            }
            ar[max_ind] = max_ind;
            Console.WriteLine("2_13:");
            for (int i = 0; i < ar.Length; i++)
            {
                Console.Write($"{ar[i]} ");
            }

            Console.WriteLine("\n");
            //14
            ar = ar1.Take(ar1.Length).ToArray();
            max_elem = double.MinValue;
            max_ind = 0;
            for (int i = 0; i < ar.Length; i++)
            {
                if (ar[i] > max_elem)
                {
                    max_elem = ar[i];
                    max_ind = i;
                }
            }
            for (int i = 0; i < ar.Length; i++)
            {
                if (ar[i] < 0) { ar[max_ind] = ar[i]; ar[i] = max_elem; break; }
            }
            Console.WriteLine("2_14:");
            for (int i = 0; i < ar.Length; i++)
            {
                Console.Write($"{ar[i]} ");
            }

            Console.WriteLine("\n");
            //15
            Console.WriteLine("Введите n:");
            n = int.Parse(Console.ReadLine());
            Console.WriteLine("Массив A:");
            ar2 = newarr(n);
            Console.WriteLine("Введите m:");
            int m = int.Parse(Console.ReadLine());
            Console.WriteLine("Массив B:");
            double[] ar3 = newarr(m);
            Console.WriteLine("Введите k:");
            int k = int.Parse(Console.ReadLine());
            double[] next = new double[] { };
            for(int i = k + 1;i < ar2.Length;i++)
            {
                next = next.Append(ar2[i]).ToArray();
            }
            double[] arres = new double[] { };
            for (int i = 0; i <= k; i++)
            {
                arres = arres.Append(ar2[i]).ToArray();
            }
            for (int i = 0; i < m; i++)
            {
                arres = arres.Append(ar3[i]).ToArray();
            }
            for (int i = 0; i < next.Length; i++)
            {
                arres = arres.Append(next[i]).ToArray();
            }
            Console.WriteLine("2_15:");
            for (int i = 0; i < arres.Length; i++)
            {
                Console.Write($"{arres[i]} ");
            }

            Console.WriteLine("\n");
            //16
            ar = ar1.Take(ar1.Length).ToArray();
            avg = ar.Average();
            int[] arint = new int[] { };
            for (int i = 0; i < ar.Length; i++)
            {
                if (ar[i] < avg)
                {
                    arint = arint.Append(i).ToArray();
                }
            }
            Console.WriteLine("2_16:");
            for (int i = 0; i < arint.Length; i++)
            {
                Console.Write($"{arint[i]} ");
            }

            Console.WriteLine("\n");
            //17
            ar = ar1.Take(ar1.Length).ToArray();
            max_elem = double.MinValue;
            max_ind = 0;
            min_elem = double.MaxValue;
            min_ind = 0;
            for (int i = 0; i < ar.Length; i++)
            {
                if (ar[i] > max_elem)
                {
                    max_elem = ar[i];
                    max_ind = i;
                }
                if (ar[i] < min_elem)
                {
                    min_elem = ar[i];
                    min_ind = i;
                }
            }
            double savg = 0;
            double cavg = 0;
            if (min_ind < max_ind)
            {
                for (int i = 0; i < ar.Length; i++)
                {
                    if (ar[i] < 0)
                    {
                        savg += ar[i];
                        cavg++;
                    }
                }
            }
            else
            {
                for (int i = 0; i < ar.Length; i++)
                {
                    if (ar[i] > 0)
                    {
                        savg += ar[i];
                        cavg++;
                    }
                }
            }
            avg = savg / cavg;
            Console.WriteLine("2_17:\n{0}", avg);

            Console.WriteLine();
            //18
            double max_elem2 = double.MinValue;
            double max_elem1 = double.MinValue;
            for (int i = 0; i < ar.Length; i += 2)
            {
                if (ar[i] > max_elem2)
                {
                    max_elem2 = ar[i];
                }
            }
            for (int i = 1; i < ar.Length; i += 2)
            {
                if (ar[i] > max_elem1)
                {
                    max_elem1 = ar[i];
                }
            }
            if (max_elem2 > max_elem1)
            {
                for (int i = 0; i < ar.Length / 2; i++)
                {
                    ar[i] = 0;
                }
            }
            else
            {
                for (int i = ar.Length / 2 + 1; i < ar.Length; i++)
                {
                    ar[i] = 0;
                }
            }
            Console.WriteLine("2_18:");
            for (int i = 0; i < ar.Length; i++)
            {
                Console.Write($"{ar[i]} ");
            }

            Console.WriteLine("\n");
            //19
            ar = ar1.Take(ar1.Length).ToArray();
            max_elem = double.MinValue;
            max_ind = 0;
            for (int i = 0; i < ar.Length; i++)
            {
                if (ar[i] > max_elem)
                {
                    max_elem = ar[i];
                    max_ind = i;
                }
            }
            if (max_elem > ar.Sum())
            {
                ar[max_ind] = 0;
            }
            else
            {
                ar[max_ind] = 2 * max_elem;
            }
            Console.WriteLine("2_19:");
            for (int i = 0; i < ar.Length; i++)
            {
                Console.Write($"{ar[i]} ");
            }

            Console.WriteLine("\n");
            //20
            ar = ar1.Take(ar1.Length).ToArray();
            min_elem = double.MaxValue;
            min_ind = 0;
            for (int i = 0; i < ar.Length; i++)
            {
                if (ar[i] < min_elem & ar[i] > 0)
                {
                    min_elem = ar[i];
                    min_ind = i;
                }
            }
            for (int i = 0; i < ar.Length; i++)
            {
                if (ar[i] < 0)
                {
                    if (i < min_ind)
                    {
                        k = 0;
                    }
                    else
                    {
                        k = 1;
                    }
                    break;
                }
            }
            s = 0;
            for (int i = k; i < ar.Length; i+=2)
            {
                s += ar[i];
            }
            Console.WriteLine("2_20:\n{0}", s);
        }

        static public void Level3_1()
        {
            //in
            Console.WriteLine("Введите массив для всего третьего уровня:");
            Console.WriteLine("Введите количество элементов массива:");
            int n = int.Parse(Console.ReadLine());
            double[] ar1 = newarr(n);

            //1
            double[] ar = ar1.Take(ar1.Length).ToArray();
            int[] arint = new int[] { };
            double max_elem = double.MinValue;
            for (int i = 0; i < ar.Length; i++)
            {
                if (ar[i] > max_elem)
                {
                    max_elem = ar[i];
                    arint = new int[] { i };
                }
                else if (ar[i] == max_elem)
                {
                    arint = arint.Append(i).ToArray();
                }
            }
            Console.WriteLine();
            Console.WriteLine("3_1:");
            for (int i = 0; i < arint.Length; i++)
            {
                Console.Write($"{arint[i]} ");
            }

            Console.WriteLine("\n");
            //2
            for (int i = 0; i < arint.Length; i++)
            {
                ar[arint[i]] += i + 1;
            }
            Console.WriteLine("3_2:");
            for (int i = 0; i < ar.Length; i++)
            {
                Console.Write($"{ar[i]} ");
            }

            Console.WriteLine("\n");
            //5
            ar = ar1.Take(ar1.Length).ToArray();
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (i % 2 == 0 & j % 2 == 0 & ar[i] > ar[j])
                    {
                        double g = ar[i];
                        ar[i] = ar[j];
                        ar[j] = g;
                    }
                }
            }
            Console.WriteLine("3_5:");
            for (int i = 0; i < ar.Length; i++)
            {
                Console.Write($"{ar[i]} ");
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            LevelSelect();
        }
    }
}