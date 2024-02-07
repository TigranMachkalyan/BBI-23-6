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
    // структура Person (человек - номинант, которого выбрал респондент)
    struct Person
    {
        private string name; // Имя номинанта. Для упрощения проверок не будем вводить фамилию и другие данные - предположим что имя однозначно определяет конкретного номинанта.
        private int count; // Счётчик голосов для каждого номинанта.
        public string Name { get { return name; } }
        public int Count { get { return count; } }
        public Person(string name)
        {
            this.name = name;
            count = 1; // При создании нового номинанта, ему присваивается один голос.
        }
        public void Choice() { count++; } // Метод, который добавляет голос номинанту.
    }
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Person[] persons = { }; // Массив, содержащий объекты номинантов.

            // Моделирование опроса:
            Console.WriteLine("Кого вы считаете человеком года? (Чтобы завершить опрос и вывести результаты, нажмите ENTER)");
            string response = Console.ReadLine(); // Ответ на вопрос
            int c = 0; // Счетчик ответов для подсчета процентов
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
                c++;
                response = Console.ReadLine();
            }

            // Вывод результатов:
            var sorted = persons.OrderByDescending(ob => ob.Count).ToArray(); // Сортируем номинантов по количеству голосов по убыванию.
            for (int i = 0; i < Math.Min(5, sorted.Length); i++)
            {
                Console.Write($"{i + 1}. {sorted[i].Name} - {sorted[i].Count*100/c}%");
                Console.WriteLine();
            }
        }
    }
}
