using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Level3
{
    // Номер по списку - 18 ==> Этот файл - решение 6-го номера третьего уровня.
    class Country // Структура ответа на вопрос
    {
        private string text; // Сам ответ
        private int count; // Счетчик голосов за этот ответ
        public string Text { get { return text; } }
        public int Count { get { return count; } set { count = value; } }
        public Country(string text, int a)
        {
            this.text = text;
            count = 1; // При создании нового ответа, ему присваивается один голос.
        }
        public virtual void Choice(int a) { count++; } // Метод, который добавляет голос ответу.
    }
    class Russia : Country
    {
        public Russia(string text, int a) : base(text, a)
        {
        }
    }
    class Japan : Country
    {
        public Japan(string text, int a) : base(text, a)
        {
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] cr = new int[3] { 0, 0, 0 };
            int[] cj = new int[3] { 0, 0, 0 };
            int[] cs = new int[3] { 0, 0, 0 };
            Country[] russia1 = { };
            Country[] russia2 = { };
            Country[] russia3 = { };
            Country[] japan1 = { };
            Country[] japan2 = { };
            Country[] japan3 = { };
            Console.WriteLine("Отвечайте на вопросы за разных людей, если ответа на вопрос нет - просто нажимайте ENTER");

            // Моделирование опроса:
            Console.WriteLine("Сколько человек прошли опрос?");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Человек {i + 1}:");
                Console.WriteLine("Какое животное Вы связываете с Россией и россиянами?");
                string answer = Console.ReadLine();
                if (answer != "")
                {
                    string[] answers = russia1.Select(x => x.Text).ToArray();
                    if (answers.Contains(answer))
                    {
                        russia1[Array.IndexOf(answers, answer)].Choice(1);
                    }
                    else
                    {
                        russia1 = russia1.Append(new Russia(answer, 1)).ToArray();
                    }
                    cr[0]++;
                    cs[0]++;
                }

                Console.WriteLine("Какая черта характера присуща россиянам больше всего?");
                answer = Console.ReadLine();
                if (answer != "")
                {
                    string[] answers = russia2.Select(x => x.Text).ToArray();
                    if (answers.Contains(answer))
                    {
                        russia2[Array.IndexOf(answers, answer)].Choice(2);
                    }
                    else
                    {
                        russia2 = russia2.Append(new Russia(answer, 2)).ToArray();
                    }
                    cr[1]++;
                    cs[1]++;
                }
                Console.WriteLine("Какай неодушевленный предмет или понятие Вы связываете с Россией?");
                answer = Console.ReadLine();
                if (answer != "")
                {
                    string[] answers = russia3.Select(x => x.Text).ToArray();
                    if (answers.Contains(answer))
                    {
                        russia3[Array.IndexOf(answers, answer)].Choice(3);
                    }
                    else
                    {
                        russia3 = russia3.Append(new Russia(answer, 3)).ToArray();
                    }
                    cr[2]++;
                    cs[2]++;
                }
                Console.WriteLine("Какое животное Вы связываете с Японией и японцами?");
                answer = Console.ReadLine();
                if (answer != "")
                {
                    string[] answers = japan1.Select(x => x.Text).ToArray();
                    if (answers.Contains(answer))
                    {
                        japan1[Array.IndexOf(answers, answer)].Choice(1);
                    }
                    else
                    {
                        japan1 = japan1.Append(new Japan(answer, 1)).ToArray();
                    }
                    cj[0]++;
                    cs[0]++;
                }

                Console.WriteLine("Какая черта характера присуща японцам больше всего?");
                answer = Console.ReadLine();
                if (answer != "")
                {
                    string[] answers = japan2.Select(x => x.Text).ToArray();
                    if (answers.Contains(answer))
                    {
                        japan2[Array.IndexOf(answers, answer)].Choice(2);
                    }
                    else
                    {
                        japan2 = japan2.Append(new Japan(answer, 2)).ToArray();
                    }
                    cj[1]++;
                    cs[1]++;
                }
                Console.WriteLine("Какай неодушевленный предмет или понятие Вы связываете с Японцами?");
                answer = Console.ReadLine();
                if (answer != "")
                {
                    string[] answers = japan3.Select(x => x.Text).ToArray();
                    if (answers.Contains(answer))
                    {
                        japan3[Array.IndexOf(answers, answer)].Choice(3);
                    }
                    else
                    {
                        japan3 = japan3.Append(new Japan(answer, 3)).ToArray();
                    }
                    cj[2]++;
                    cs[2]++;
                }
                Console.WriteLine();
            }
            Console.WriteLine("-------------------------");
            Console.WriteLine();
            // Вывод результатов:
            Console.WriteLine("Россия:");
            List<Country[]> russia_all = new List<Country[]> { russia1, russia2, russia3};
            for (int i = 1; i < 4; i++)
            {
                Console.WriteLine($"Вопрос {i}");
                var sorted = russia_all[i - 1].OrderByDescending(ob => ob.Count).ToArray(); // Сортируем номинантов по количеству голосов по убыванию.
                for (int j = 0; j < Math.Min(5, sorted.Length); j++)
                {
                    Console.Write($"{j + 1}. {sorted[j].Text} - {sorted[j].Count * 100 / cr[0]}%");
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
            Console.WriteLine("Япония:");
            List<Country[]> japan_all = new List<Country[]> { japan1, japan2, japan3 };
            for (int i = 1; i < 4; i++)
            {
                Console.WriteLine($"Вопрос {i}");
                var sorted = japan_all[i - 1].OrderByDescending(ob => ob.Count).ToArray(); // Сортируем номинантов по количеству голосов по убыванию.
                for (int j = 0; j < Math.Min(5, sorted.Length); j++)
                {
                    Console.Write($"{j + 1}. {sorted[j].Text} - {sorted[j].Count * 100 / cr[0]}%");
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
            Console.WriteLine("Общее:");
            var all1 = new List<Country>(russia1);
            var temp = russia1.Select(x => x.Text).ToList();
            foreach (var country in japan1)
            {
                if (temp.Contains(country.Text))
                {
                    all1[temp.IndexOf(country.Text)].Count += country.Count;
                }
                else
                {
                    all1.Add(country);
                }
            }
            var all2 = new List<Country>(russia2);
            temp = russia2.Select(x => x.Text).ToList();
            foreach (var country in japan2)
            {
                if (temp.Contains(country.Text))
                {
                    all2[temp.IndexOf(country.Text)].Count += country.Count;
                }
                else
                {
                    all2.Add(country);
                }
            }
            var all3 = new List<Country>(russia3);
            temp = russia3.Select(x => x.Text).ToList();
            foreach (var country in japan3)
            {
                if (temp.Contains(country.Text))
                {
                    all3[temp.IndexOf(country.Text)].Count += country.Count;
                }
                else
                {
                    all3.Add(country);
                }
            }

            Console.WriteLine("Вопрос 1");
            var sorted_all = all1.OrderByDescending(ob => ob.Count).ToArray(); // Сортируем номинантов по количеству голосов по убыванию.
            for (int i = 0; i < Math.Min(5, sorted_all.Length); i++)
            {
                Console.Write($"{i + 1}. {sorted_all[i].Text} - {sorted_all[i].Count * 100 / cs[0]}%");
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Вопрос 2");
            sorted_all = all2.OrderByDescending(ob => ob.Count).ToArray(); // Сортируем номинантов по количеству голосов по убыванию.
            for (int i = 0; i < Math.Min(5, sorted_all.Length); i++)
            {
                Console.Write($"{i + 1}. {sorted_all[i].Text} - {sorted_all[i].Count * 100 / cs[1]}%");
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Вопрос 3");
            sorted_all = all3.OrderByDescending(ob => ob.Count).ToArray(); // Сортируем номинантов по количеству голосов по убыванию.
            for (int i = 0; i < Math.Min(5, sorted_all.Length); i++)
            {
                Console.Write($"{i + 1}. {sorted_all[i].Text} - {sorted_all[i].Count * 100 / cs[2]}%");
                Console.WriteLine();
            }
        }
    }
}
