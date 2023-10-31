using System;
using System.Security.Cryptography.X509Certificates;

namespace Lab2
{
    internal class Program
    {
        static public void LevelSelect()
        {
            Console.WriteLine();
            Console.WriteLine("Select Level: (1, 2)");
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
        }

        static public void Level1()
        {
            Console.WriteLine();
            //3
            Console.WriteLine("Enter a:");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter b:");
            double b = Convert.ToDouble(Console.ReadLine());
            double c = 0;
            if (a > 0)
            {
                c = Math.Max(a, b);
            }
            else
            {
                c = Math.Min(a, b);
            }
            Console.WriteLine("1_3:\n{0}", c);

            Console.WriteLine();
            //6
            double r;
            double s;
            //6.1
            r = 3.2;
            s = 3.5;
            if (r*2 <= Math.Sqrt(s))
            {
                Console.WriteLine("1_6_1:\nYes");
            }
            else
            {
                Console.WriteLine("1_6_1:\nNo");
            }
            //6.2
            r = 3.2;
            s = 4;
            if (r * 2 <= Math.Sqrt(s))
            {
                Console.WriteLine("1_6_1:\nYes");
            }
            else
            {
                Console.WriteLine("1_6_1:\nNo");
            }
            //6.3
            r = 6;
            s = 9;
            if (Math.Sqrt(r)/Math.PI <= Math.Sqrt(s))
            {
                Console.WriteLine("1_6_1:\nYes");
            }
            else
            {
                Console.WriteLine("1_6_1:\nNo");
            }

            Console.WriteLine();
            //9
            Console.WriteLine("Enter x:");
            double x = Convert.ToDouble(Console.ReadLine());
            if (x <= -1)
            {
                Console.WriteLine("1_9:\ny = 0");
            }
            else if (x <= 0 & x > -1) {
                Console.WriteLine("1_9:\ny = {0}", 1 + x);
            }
            else { Console.WriteLine("1_9:\ny = 1"); }
        }

        static public void Level2()
        {
            Console.WriteLine();
            //3
            Console.WriteLine("Enter n:");
            int n = Convert.ToInt32(Console.ReadLine());
            double r = 0;
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Enter weight:");
                double w = Convert.ToDouble(Console.ReadLine());
                if (w < 30)
                {
                    r += 0.2;
                }
            }
            Console.WriteLine("2_3:\n{0}", Math.Round(r, 1));

            Console.WriteLine();
            //6
            Console.WriteLine("Enter n:");
            n = Convert.ToInt32(Console.ReadLine());
            r = 0;
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Enter x:");
                double x = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter y:");
                double y = Convert.ToDouble(Console.ReadLine());
                if ((x >= 0 & x <= Math.PI) & (y >= 0 & y <= Math.Sin(x)))
                {
                    r++;
                }
            }
            Console.WriteLine("2_6:\n{0}", r);

            Console.WriteLine();
            //9
            Console.WriteLine("Enter n:");
            n = Convert.ToInt32(Console.ReadLine());
            r = Double.MaxValue;
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Enter time:");
                double t = Convert.ToDouble(Console.ReadLine());
                if (t < r)
                {
                    r = t;
                }
            }
            Console.WriteLine("2_9:\n{0}", r);
        }

        static void Main(string[] args)
        {
            LevelSelect();
        }
    }
}