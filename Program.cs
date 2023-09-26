using System;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp1
{
    internal class Program
    {
        static public void Level1(double x)
        {
            double s = 0;

            Console.WriteLine();
            //1
            for (int i = 2; i <= 35; i += 3)
            {
                s += i;
            }
            Console.WriteLine("1_1:\n{0}", s);

            Console.WriteLine();
            //2
            s = 0;
            for (double i = 1; i <= 10; i++)
            {
                s += 1 / i;
            }
            Console.WriteLine("1_2:\n{0}", s);

            Console.WriteLine();
            //3
            s = 0;
            for (double i = 2; i <= 112; i++)
            {
                s += i / (i + 1);
            }
            Console.WriteLine("1_3:\n{0}", s);

            Console.WriteLine();
            //4
            s = 0;
            for (double i = 0; i <= 8; i++)
            {
                s += Math.Cos((i + 1) * x) / Math.Pow(x, i);
            }
            Console.WriteLine("1_4:\n{0}", s);

            Console.WriteLine();
            //5
            s = 0;
            Console.WriteLine("Enter p for 1_5: (DOUBLE ONLY!!!)");
            double p = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter h for 1_5: (DOUBLE ONLY!!!)");
            double h = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine();
            for (double i = 0; i <= 9; i++)
            {
                s += (p + i * h) * (p + i * h);
            }
            Console.WriteLine("1_5:\n{0}", s);

            Console.WriteLine();
            //6
            s = 0;
            double y;
            Console.WriteLine("1_6:");
            Console.WriteLine("  x   |  y");
            for (double i = -4; i <= 4; i += 0.5)
            {
                y = 0.5 * i * i - 7 * i;
                if (i < 0)
                {
                    if (i % 1 == 0)
                    {
                        Console.WriteLine(" {0}   | {1}", i, y);
                    }
                    else
                    {
                        Console.WriteLine(" {0} | {1}", i, y);
                    }
                }
                else
                {
                    if (i % 1 == 0)
                    {
                        Console.WriteLine(" {0}    | {1}", i, y);
                    }
                    else
                    {
                        Console.WriteLine(" {0}  | {1}", i, y);
                    }
                }
            }

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
            for (double i = 1; i <= 6; i++)
            {
                k *= i;
                s += Math.Pow(-1, i)*Math.Pow(5, i)/k;
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
            s = 0;
            Console.WriteLine("1_13:");
            Console.WriteLine("  x   |  y");
            for (double i = -1.5; i <= 1.5; i+= 0.1)
            {
                if (i <= - 1)
                {
                    y = 1;
                }
                else if (i > -1 & i <= 1)
                {
                    y = -i;
                }
                else
                {
                    y = -1;
                }
                i = Math.Round(i, 1);
                y = Math.Round(y, 1);
                if (i < 0)
                {
                    if (i % 1 == 0)
                    {
                        Console.WriteLine(" {0}   | {1}", i, y);
                    }
                    else
                    {
                        Console.WriteLine(" {0} | {1}", i, y);
                    }
                }
                else
                {
                    if (i % 1 == 0)
                    {
                        Console.WriteLine(" {0}    | {1}", i, y);
                    }
                    else
                    {
                        Console.WriteLine(" {0}  | {1}", i, y);
                    }
                }
            }

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
            s = a1/b1 + a2/b2;
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
        static void Main(string[] args)
        {
            Console.WriteLine("Select Level: (1)");
            int level_of_lab = Convert.ToInt32(Console.ReadLine());
            if (level_of_lab == 1)
            {
                Console.WriteLine("Enter x: (DOUBLE ONLY!!!)");
                double x = Convert.ToDouble(Console.ReadLine());
                Level1(x);
            }   
        }
    }
}