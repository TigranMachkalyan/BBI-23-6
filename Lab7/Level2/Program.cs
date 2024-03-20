using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Номер по списку - 18 ==> Этот файл - решение 9-го номера второго уровня.
namespace Level2
{
    public abstract class Winter_Game
    {
        protected string name_of_game = "error";
        private string name;
        private float[] marks;
        private int[] places;
        public Winter_Game(string name, float[] marks)
        {
            this.name = name;
            this.marks = marks;
            places = new int[7];
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
            foreach (int i in places)
            {
                k += i;
            }
            return k;
        }
        public void Display()
        {
            Console.WriteLine($"{name}, сумма мест: {PlacesSum()}");
        }
        public void PrintGameName()
        {
            Console.WriteLine(name_of_game);
        }
    }

    class FigSkater: Winter_Game
    {
        public FigSkater(string name, float[] marks): base(name, marks)
        {
            base.name_of_game = "Фигурное катание";
        }
    }

    class SpeedSkater : Winter_Game
    {
        public SpeedSkater(string name, float[] marks) : base(name, marks)
        {
            base.name_of_game = "Конькобежный спорт";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            FigSkater[] fig_skaters = { }; //Массив, содержащий объекты фигуристов

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
                fig_skaters = fig_skaters.Append(new FigSkater(n, ms)).ToArray();
                Console.WriteLine("Введите фамилию фигуриста (ENTER для завершения ввода таблицы):");
                n = Console.ReadLine();
            }

            //Подсчет мест у каждого судьи:
            for (int i = 0; i < 7; i++)
            {
                var sorted = fig_skaters.OrderByDescending(ob => ob.Mark(i)).ToArray();
                for (int j = 0; j < sorted.Length; j++)
                {
                    sorted[j].SetPlace(i, j + 1);
                }
            }
            
            //Подсчет итоговых мест по суммам мест:
            var sorted1 = fig_skaters.OrderBy(ob => ob.PlacesSum()).ToArray();

            SpeedSkater[] speed_skaters = { }; //Массив, содержащий объекты фигуристов

            //Ввод таблицы оценок:
            Console.WriteLine("Введите фамилию конькобежца:");
            n = Console.ReadLine();
            while (n != "")
            {
                Console.WriteLine("Введите через ENTER баллы у семи судей:");
                float[] ms = { };
                for (int i = 0; i < 7; i++)
                {
                    float m = float.Parse(Console.ReadLine());
                    ms = ms.Append(m).ToArray();
                }
                speed_skaters = speed_skaters.Append(new SpeedSkater(n, ms)).ToArray();
                Console.WriteLine("Введите фамилию фигуриста (ENTER для завершения ввода таблицы):");
                n = Console.ReadLine();
            }

            //Подсчет мест у каждого судьи:
            for (int i = 0; i < 7; i++)
            {
                var sorted = speed_skaters.OrderByDescending(ob => ob.Mark(i)).ToArray();
                for (int j = 0; j < sorted.Length; j++)
                {
                    sorted[j].SetPlace(i, j + 1);
                }
            }

            //Подсчет итоговых мест по суммам мест:
            var sorted2 = speed_skaters.OrderBy(ob => ob.PlacesSum()).ToArray();
            sorted1[0].PrintGameName();
            for (int i = 0; i < sorted1.Length; i++)
            {
                Console.Write($"{i + 1}) ");
                sorted1[i].Display();
            }
            Console.WriteLine();
            sorted2[0].PrintGameName();
            for (int i = 0; i < sorted2.Length; i++)
            {
                Console.Write($"{i + 1}) ");
                sorted2[i].Display();
            }
        }
    }
}
