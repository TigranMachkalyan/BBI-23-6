using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
// Номер по списку - 18 ==> Этот файл - решение 3-го номера первого уровня.
namespace Level1
{
    internal class Program
    {
        // структура Person (человек - номинант, которого выбрал респондент)
        public struct Person
        {
            private string name; // Имя номинанта. Для упрощения проверок не будем вводить фамилию и другие данные - предположим что имя однозначно определяет конкретного номинанта.
            private int count; // Счётчик голосов для каждого номинанта.
            private static int overall_c = 0;
            public string Name { get { return name; } }
            public int Count { get { return count; } }
            public static bool operator >(Person a, Person b) { return a.Count > b.Count; }
            public static bool operator <(Person a, Person b) { return a.Count < b.Count; }
            public Person(string name)
            {
                this.name = name;
                count = 1; // При создании нового номинанта, ему присваивается один голос.
                overall_c++;
            }
            public override string ToString()
            {
                return $"{name} - {count * 100 / overall_c}%";
            }
            public void Choice() { count++; overall_c++; } // Метод, который добавляет голос номинанту.
        }

        static void Main(string[] args)
        {
            Person[] persons = { }; // Массив, содержащий объекты номинантов.

            // Моделирование опроса:
            Console.WriteLine("Кого вы считаете человеком года? (Чтобы завершить опрос и вывести результаты, нажмите ENTER)");
            string response = Console.ReadLine(); // Ответ на вопрос
            while (response != "")
            {
                string[] names = persons.Select(x => x.Name).ToArray();
                if (names.Contains(response)) // Создан ли объект номинанта
                {
                    persons[Array.IndexOf(names, response)].Choice(); // Так как объект уже создан, то вызываем метод Choice, который даст номинанту еще один голос.
                }
                else
                {
                    persons = persons.Append(new Person(response)).ToArray(); // Так как объект еще не создан, то создаем его.
                }
                response = Console.ReadLine();
            }

            // Вывод результатов:
            ShellSortDesc(persons); // Сортируем номинантов по количеству голосов по убыванию.
            for (int i = 0; i < Math.Min(5, persons.Length); i++)
            {
                Console.Write($"{i + 1}. {persons[i]}");
                Console.WriteLine();
            }
        }

        public static void ShellSortDesc(Person[] arr)
        {
            int step = arr.Length / 2;
            while (step >= 1)
            {
                for (int i = step; i < arr.Length; i++)
                {
                    Person temp = arr[i];
                    int j = i;
                    while ((j >= step) && (arr[j - step] < temp))
                    {
                        arr[j] = arr[j - step];
                        j -= step;
                    }
                    arr[j] = temp;
                }
                step /= 2;
            }
        }
    }
}
