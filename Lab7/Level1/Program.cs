using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
// Номер по списку - 18 ==> Этот файл - решение 3-го номера первого уровня.
namespace Level1
{
    internal class Program
    {
        // структура Person (человек - номинант, которого выбрал респондент)
        public abstract class Person
        {
            protected string name; // Имя номинанта. Для упрощения проверок не будем вводить фамилию и другие данные - предположим что имя однозначно определяет конкретного номинанта.
            protected int count; // Счётчик голосов для каждого номинанта.
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
            public virtual void Display()
            {
                Console.WriteLine($"{name} - {count * 100 / overall_c}%");
            }
            public virtual void Choice() { count++; overall_c++; } // Метод, который добавляет голос номинанту.
            static Person[] MergeSort(Person[] arr, int left, int right)
            {
                if (left < right)
                {
                    int middle = left + (right - left) / 2;
                    MergeSort(arr, left, middle);
                    MergeSort(arr, middle + 1, right);
                    MergeArray(arr, left, middle, right);
                }
                return arr;
            }
            static void MergeArray(Person[] array, int left, int middle, int right)
            {
                var leftArrayLength = middle - left + 1;
                var rightArrayLength = right - middle;
                var leftTempArray = new Person[leftArrayLength];
                var rightTempArray = new Person[rightArrayLength];
                int i, j;
                for (i = 0; i < leftArrayLength; ++i)
                    leftTempArray[i] = array[left + i];
                for (j = 0; j < rightArrayLength; ++j)
                    rightTempArray[j] = array[middle + 1 + j];
                i = 0;
                j = 0;
                int k = left;
                while (i < leftArrayLength && j < rightArrayLength)
                {
                    if (leftTempArray[i] > rightTempArray[j])
                    {
                        array[k++] = leftTempArray[i++];
                    }
                    else
                    {
                        array[k++] = rightTempArray[j++];
                    }
                }
                while (i < leftArrayLength)
                {
                    array[k++] = leftTempArray[i++];
                }
                while (j < rightArrayLength)
                {
                    array[k++] = rightTempArray[j++];
                }
            }

        class Man_of_The_Year: Person
        {
            private static int c;
            public Man_of_The_Year(string name): base(name)
            {
                c++;
            }
            public override void Display() { Console.WriteLine($"{name} - {count * 100 / c}%"); }
            public override void Choice()
            {
                base.Choice();
                c++;
            }
        }

        class Discovery_of_The_Year : Person
        {
            private static int c;
            public Discovery_of_The_Year(string name) : base(name)
            {
                c++;
            }
            public override void Display() { Console.WriteLine($"{name} - {count * 100 / c}%"); }
            public override void Choice()
            {
                base.Choice();
                c++;
            }
        }

        static void Main(string[] args)
        {
            Man_of_The_Year[] persons1 = { }; // Массив, содержащий объекты номинантов.

            // Моделирование опроса:
            Console.WriteLine("Кого вы считаете человеком года? (Чтобы перейти к следующему вопросу, нажмите ENTER)");
            string response = Console.ReadLine(); // Ответ на вопрос
            while (response != "")
            {
                string[] names = persons1.Select(x => x.Name).ToArray();
                if (names.Contains(response)) // Создан ли объект номинанта
                {
                    persons1[Array.IndexOf(names, response)].Choice(); // Так как объект уже создан, то вызываем метод Choice, который даст номинанту еще один голос.
                }
                else
                {
                    persons1 = persons1.Append(new Man_of_The_Year(response)).ToArray(); // Так как объект еще не создан, то создаем его.
                }
                response = Console.ReadLine();
            }

            Discovery_of_The_Year[] persons2 = { }; // Массив, содержащий объекты номинантов.

            // Моделирование опроса:
            Console.WriteLine("Кого вы считаете открытием года? (Чтобы завершить опрос и вывести результаты, нажмите ENTER)");
            response = Console.ReadLine(); // Ответ на вопрос
            while (response != "")
            {
                string[] names = persons2.Select(x => x.Name).ToArray();
                if (names.Contains(response)) // Создан ли объект номинанта
                {
                    persons2[Array.IndexOf(names, response)].Choice(); // Так как объект уже создан, то вызываем метод Choice, который даст номинанту еще один голос.
                }
                else
                {
                    persons2 = persons2.Append(new Discovery_of_The_Year(response)).ToArray(); // Так как объект еще не создан, то создаем его.
                }
                response = Console.ReadLine();
            }



            // Вывод результатов:
            Person.MergeSort(persons1, 0, persons1.Length-1); // Сортируем номинантов по количеству голосов по убыванию.
            Person.MergeSort(persons2, 0, persons2.Length-1); // Сортируем номинантов по количеству голосов по убыванию.
            Console.WriteLine("Человек года:");
            for (int i = 0; i < Math.Min(5, persons1.Length); i++)
            {
                Console.Write($"{i + 1}. ");
                persons1[i].Display();
            }
            Console.WriteLine();
            Console.WriteLine("Открытие года:");
            for (int i = 0; i < Math.Min(5, persons2.Length); i++)
            {
                Console.Write($"{i + 1}. ");
                persons2[i].Display();
            }
        }       
        }
    }
}
