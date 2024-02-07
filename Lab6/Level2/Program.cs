using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Номер по списку - 18 ==> Этот файл - решение 9-го номера второго уровня.
namespace Level2
{
    struct Skater // Структура фигуриста
    {
        private string name;
        private float[] marks;
        private int[] places;
        public Skater(string name, float[] marks)
        {
            this.name = name;
            this.marks = marks;
            this.places = new int[7];
        }
        public float Mark(int n) // Метод, возвращающий баллы фигуриста у n-ого судьи
        {
            return marks[n];
        }
        public void SetPlace(int referee, int place)
        {
            places[referee] = place;
        }
        public int PlacesSum()
        {
            int k = 0;
            foreach(int i in places)
            {
                k += i;
            }
            return k;
        }
        public void Display()
        {
            Console.WriteLine($"{name}, сумма мест: {PlacesSum()}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Skater[] skaters = { }; //Массив, содержащий объекты фигуристов

            //Ввод таблицы оценок:
            Console.WriteLine("Введите фамилию фигуриста:");
            string n = Console.ReadLine();
            while (n != "")
            {
                Console.WriteLine("Введите через ENTER баллы у семи судей:");
                float[] ms = { };
                for (int i = 0; i < 7; i++)
                {
                    float m = float.Parse(Console.ReadLine());
                    ms = ms.Append(m).ToArray();
                }
                skaters = skaters.Append(new Skater(n, ms)).ToArray();
                Console.WriteLine("Введите фамилию фигуриста (ENTER для завершения ввода таблицы):");
                n = Console.ReadLine();
            }

            //Подсчет мест у каждого судьи:
            for (int i = 0; i < 7; i++)
            {
                var sorted = skaters.OrderByDescending(ob => ob.Mark(i)).ToArray();
                for (int j = 0; j < sorted.Length; j++)
                {
                    sorted[j].SetPlace(i, j + 1);
                }
            }

            //Подсчет итоговых мест по суммам мест:
            var sorted1 = skaters.OrderBy(ob => ob.PlacesSum()).ToArray();
            for (int i = 0; i < sorted1.Length; i++)
            {
                Console.Write($"{i + 1}) ");
                sorted1[i].Display();
            }
        }
    }
}
