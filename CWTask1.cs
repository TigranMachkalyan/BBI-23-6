using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR
{
    internal class Program
    {
        struct Series
        {
            private string _name;
            private int _dur_min;
            private string _description;
            private bool _watched;
            public static bool operator > (Series a, Series b)
            {
                if (a._name.CompareTo(b._name) == 1)
                {
                    return true;
                }
                return false;
            }
            public static bool operator < (Series a, Series b)
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
            public Series(string name, int dur_min)
            {
                _name = name;
                _dur_min = dur_min;
                _description = $"Для сериала {name} описание не задано";
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
            public void Display()
            {
                Console.WriteLine("-----------------------------");
                Console.WriteLine($"Название: {_name}, средняя продолжительность: {_dur_min} минут, {Watched()}");
                Console.WriteLine($"Описание: {_description}");
                Console.WriteLine("-----------------------------");
            }
            public static void TableHeader()
            {
                Console.WriteLine($"{"Название", 20} | {"Сердняя продолжительность", 25} | {"Просмотрено", 15} | Описание");
                Console.WriteLine("------------------------------------------------------------------------------------------");
            }
            public void PrintRow()
            {
                Console.WriteLine($"{_name,20} | {_dur_min,25} | {Watched(),15} | {_description}");
            }
        }
        static void Main(string[] args)
        {
            Series[] series = { new Series("Gantlemen", 120), new Series("Stranger things", 40), new Series("Breaking Bad", 60), new Series("Sherlock", 90),  new Series("La casa de papel", 120) };
            SortSeries(series);
            series[0].Set_descriprion("Chemistry teacher and one teenager...");
            series[0].Set_watched();
            series[1].Set_descriprion("BlaBla");
            series[2].Set_watched();
            series[3].Set_descriprion("Detective Sherlock Holmes and his friend...");
            Series.TableHeader();
            for(int i = 0; i < series.Length; i++)
            {
                series[i].PrintRow();
            }
        }

        static void SortSeries(Series[] arr)
        {
            int n = arr.Length;
            for(int i = 1; i < n; i++)
            {
                for (int j = 0;  j < n - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        Series temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }
    }
}
