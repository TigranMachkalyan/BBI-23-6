using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR
{
    internal class Program
    {
        abstract class Watching
        {
            protected string _name;
            protected string _description;
            protected bool _watched;
            public static bool operator >(Watching a, Watching b)
            {
                if (a._name.CompareTo(b._name) == 1)
                {
                    return true;
                }
                return false;
            }
            public static bool operator <(Watching a, Watching b)
            {
                if (a._name.CompareTo(b._name) == -1)
                {
                    return true;
                }
                return false;
            }
            public void Set_descriprion(string s)
            {
                if (s.Length >= 20 && s.Length <= 200)
                {
                    _description = s;
                }
                else
                {
                    Console.WriteLine("Описание должно быть от 20 до 200 символов!!!");
                }
            }
            public void Set_watched() { _watched = true; }
            public Watching(string name)
            {
                _name = name;
                _description = $"Для фильма/сериала {name} описание не задано";
                _watched = false;
            }
            public string Watched()
            {
                switch (_watched)
                {
                    case true: return "Просмотрено";
                    case false: return "Не просмотрено";
                    default: return "Не просмотрено";
                }
            }
            public virtual void Display()
            {
                Console.WriteLine("-----------------------------");
                Console.WriteLine($"Название: {_name}, {Watched()}");
                Console.WriteLine($"Описание: {_description}");
                Console.WriteLine("-----------------------------");
            }
            public static void TableHeader()
            {
                Console.WriteLine($"{"Название",20} | {"Продолжительность",25} | {"Возраст", 10} | {"Просмотрено",15} | Описание");
                Console.WriteLine("------------------------------------------------------------------------------------------");
            }
            public virtual void PrintRow()
            {
                Console.WriteLine($"{_name,20} | {"",25} | {"",10} | {Watched(),15} | {_description}");
            }
        }
        class Series: Watching
        {
            public Series(string name): base(name)
            {
                base._description = $"Для сериала {name} описание не задано";
            }
            public override void Display()
            {
                Console.WriteLine("-----------------------------");
                Console.WriteLine($"Название: {_name}, {Watched()}");
                Console.WriteLine($"Описание: {_description}");
                Console.WriteLine("-----------------------------");
            }
        }
        class Movie: Watching
        {
            private string _age;
            private int _dur_min;
            public Movie(string name, string age, int dur_min):base(name)
            {
                _age = age;
                _dur_min = dur_min;
                base._description = $"Для фильма {name} описание не задано";
            }
            public override void Display()
            {
                Console.WriteLine("-----------------------------");
                Console.WriteLine($"Название: {_name}, продолжительность: {_dur_min}, минут, {Watched()}");
                Console.WriteLine($"Описание: {_description}");
                Console.WriteLine("-----------------------------");
            }
            public override void PrintRow()
            {
                Console.WriteLine($"{_name,20} | {_dur_min,25} | {_age,10} | {Watched(),15} | {_description}");
            }
        }
        static void Main(string[] args)
        {
            Series[] series = { new Series("Gantlemen"), new Series("Stranger things"), new Series("Breaking Bad"), new Series("Sherlock"), new Series("La casa de papel") };
            SortWatching(series);
            series[0].Set_descriprion("Chemistry teacher and one teenager...");
            series[1].Set_descriprion("BlaBla");
            series[3].Set_descriprion("Detective Sherlock Holmes and his friend...");
            Console.WriteLine("СЕРИАЛЫ:");
            Watching.TableHeader();
            for (int i = 0; i < series.Length; i++)
            {
                series[i].PrintRow();
            }
            Movie[] movies = { new Movie("Home Alone", "6+", 120), new Movie("Avengers", "16+", 160), new Movie("Interstellar", "16+", 180), new Movie("Snatch", "18+", 130), new Movie("Back to the future", "12+", 90)};
            SortWatching(movies);
            Console.WriteLine();
            Console.WriteLine("ФИЛЬМЫ:");
            for (int i = 0; i < series.Length; i++)
            {
                movies[i].PrintRow();
            }
            series[1].Set_watched();
            series[3].Set_watched();
            movies[0].Set_watched();
            movies[3].Set_watched();
            movies[4].Set_watched();
            Watching[] watchings = { };
            for(int i = 0;i < series.Length;i++)
            {
                watchings = watchings.Append(series[i]).ToArray();
            }
            for (int i = 0; i < movies.Length; i++)
            {
                watchings = watchings.Append(movies[i]).ToArray();
            }
            SortWatching(watchings);
            Console.WriteLine();
            Console.WriteLine("ОБЩЕЕ:");
            for (int i = 0; i < watchings.Length; i++)
            {
                watchings[i].PrintRow();
            }
        }

        static void SortWatching(Watching[] arr)
        {
            int n = arr.Length;
            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < n - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        Watching temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }
    }
}
