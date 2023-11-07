using System;
using System.Security.Cryptography.X509Certificates;

namespace Lab1
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
                r = r.Append(Convert.ToInt32(Console.ReadLine())).ToArray();
            }
            return r;
        }

        static public void Level1()
        {
            double x = 0;

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
            for (int i = 0; i < ar1.Length; i++)
            {
                ar[i] = ar[i] - ar.Average();
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
            s = 1;
            for (double i = 1; i <= 6; i++)
            {
                s *= i;
            }
            Console.WriteLine("1_7:\n{0}", s);

            Console.WriteLine();
            //8
            s = 0;
            double k = 1;
            for (double i = 1; i <= 6; i++)
            {
                k *= i;
                s += k;
            }
            Console.WriteLine("1_8:\n{0}", s);

            Console.WriteLine();
            //9
            s = 0;
            k = 1;
            int z = -1;
            for (double i = 1; i <= 6; i++)
            {
                k *= i;
                s += z * Math.Pow(5, i) / k;
                z *= -1;
            }
            Console.WriteLine("1_9:\n{0}", s);

            Console.WriteLine();
            //10
            s = 1;
            for (double i = 1; i <= 7; i++)
            {
                s *= 3;
            }
            Console.WriteLine("1_10:\n{0}", s);

            Console.WriteLine();
            //11
            Console.WriteLine("1_11:");
            for (double i = 1; i <= 6; i++)
            {
                Console.Write("{0} ", i);
            }
            Console.Write("\n");
            for (double i = 1; i <= 6; i++)
            {
                Console.Write("5 ");
            }

            Console.WriteLine("\n");
            //12
            s = 0;
            for (double i = 0; i <= 10; i++)
            {
                s += 1 / Math.Pow(x, i);
            }
            Console.WriteLine("1_12:\n{0}", s);

            Console.WriteLine();
            //13
            

            Console.WriteLine();
            //14
            Console.WriteLine("1_14:");
            double a = 1;
            double b = 1;
            double c;
            Console.Write("1 1 ");
            for (double i = 1; i <= 6; i++)
            {
                c = a + b;
                a = b;
                b = c;
                Console.Write("{0} ", b);
            }

            Console.WriteLine();
            //15
            double a1 = 1;
            double b1 = 1;
            double a2 = 2;
            double b2 = 1;
            double a3;
            double b3;
            s = a1 / b1 + a2 / b2;
            for (double i = 1; i <= 3; i++)
            {
                a3 = a1 + a2;
                b3 = b1 + b2;
                s += a3 / b3;
                a1 = a2;
                b1 = b2;
                a2 = a3;
                b2 = b3;
            }
            Console.WriteLine("1_15:\n{0}", s);
        }

        static public void Level2()
        {
            double s = 0;
            double x = 0;
            Console.WriteLine();
            //1
            double m = Math.Cos(x);
            double i = 1;
            while (Math.Abs(m) >= 0.0001)
            {
                s += m;
                i++;
                m = Math.Cos(i * x) / (i * i);
            }
            s += m;
            Console.WriteLine("2_1:\n{0}", s);

            Console.WriteLine();
            //2
            double p = 1;
            double n = 1;
            while (p <= 30000)
            {
                p *= n;
                n += 3;
            }
            n -= 3;
            p /= n;
            Console.WriteLine("2_2:\n{0}", n - 3);

            Console.WriteLine();
            //3
            s = 0;
            n = 0;
            Console.WriteLine("Enter a for 2_3: (DOUBLE ONLY!!!)");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter h for 2_3: (DOUBLE ONLY!!!)");
            double h = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine();
            while (s <= p)
            {
                s += a + h * n;
                n++;
            }
            n--;
            Console.WriteLine("2_3:\n{0}", n);

            Console.WriteLine();
            //4
            s = 0;
            Console.WriteLine("Enter x for 2_4: (|x| < 1 ONLY!!!)");
            double x1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine();
            i = 1;
            while (i >= 0.0001)
            {
                s += i;
                i *= x1 * x1;
            }
            Console.WriteLine("2_4:\n{0}", s);

            Console.WriteLine();
            //5
            Console.WriteLine("Enter N for 2_5: (INT ONLY!!!)");
            n = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter M for 2_5: (INT ONLY!!!)");
            m = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine();
            double ch = 0;
            while (n >= m)
            {
                ch++;
                n -= m;
            }
            Console.WriteLine("2_5:\nЧастное: {0}, остаток: {1}", ch, n);

            Console.WriteLine();
            //6
            string except = "---";
            Console.WriteLine("2_6:\n{0}", except);

            Console.WriteLine();
            //7
            double dayly = 10;
            double day = 1;
            s = 10;
            bool flag1, flag2, flag3;
            flag1 = flag2 = flag3 = false;
            double a1, a2, a3;
            a1 = a2 = a3 = 1;
            while ((flag1 & flag2 & flag3) == false)
            {
                day++;
                dayly *= 1.1;
                s += dayly;
                if (day == 7 & flag1 == false)
                {
                    flag1 = true;
                    a1 = s;
                }
                if (s >= 100 & flag2 == false)
                {
                    flag2 = true;
                    a2 = day;
                }
                if (dayly > 20 & flag3 == false)
                {
                    flag3 = true;
                    a3 = day;
                }
            }
            Console.WriteLine("2_7:\nа) {0}\nб) {1}\nв){2}", a1, a2, a3);

            Console.WriteLine();
            //8
            s = 10000;
            i = 0;
            while (s < 20000)
            {
                s *= 1.08;
                i++;
            }
            Console.WriteLine("2_8:\n{0}", i);
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