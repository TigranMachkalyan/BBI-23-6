using System;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp1
{
    internal class Program
    {
        static public void Level1()
        {
            double s = 0;
            
            //1
            for(int i = 2; i <= 35; i += 3) {
                s += i;
            }
            Console.WriteLine("1_1:\n{0}", s);

            //2
            s = 0;
            for (int i = 1; i <= 10; i++)
            {
                s += 1/i;
            }
            Console.WriteLine("1_2:\n{0}", s);
        }
           
        static void Main(string[] args)
        {
            Level1();
        }
    }
}
