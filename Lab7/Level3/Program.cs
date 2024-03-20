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
        public static int c1, c2, c3;
        private string text; // Сам ответ
        private int count; // Счетчик голосов за этот ответ
        public string Text { get { return text; } }
        public int Count { get { return count; } }
        public Country(string text, int a)
        {
            this.text = text;
            count = 1; // При создании нового ответа, ему присваивается один голос.
        }
        public virtual void Choice(int a) { count++; } // Метод, который добавляет голос ответу.
    }
    class Russia: Country
    {
        static readonly string name_of_country = "Russia";
        public static int cr1, cr2, cr3;
        public Russia(string text, int a): base(text, a)
        {
            switch (a)
            {
                case 1:
                    cr1++;
                    Country.c1++;
                    break;
                case 2:
                    cr2++;
                    Country.c2++;
                    break;
                case 3:
                    cr3++;
                    Country.c3++;
                    break;
            }
        }
        public override void Choice(int value)
        {
            base.Choice(value);
            switch (value)
            {
                case 1:
                    cr1++;
                    Country.c1++;
                    break;
                case 2:
                    cr2++;
                    Country.c2++;
                    break;
                case 3:
                    cr3++;
                    Country.c3++;
                    break;
            }
        }
    }
    class Japan: Country
    {
        static readonly string name_of_country = "Japan";
        public static int cr1, cr2, cr3;
        public Japan(string text, int a) : base(text, a)
        {
            switch (a)
            {
                case 1:
                    cr1++;
                    Country.c1++;
                    break;
                case 2:
                    cr2++;
                    Country.c2++;
                    break;
                case 3:
                    cr3++;
                    Country.c3++;
                    break;
            }
        }
        public override void Choice(int value)
        {
            base.Choice(value);
            switch (value)
            {
                case 1:
                    cr1++;
                    Country.c1++;
                    break;
                case 2:
                    cr2++;
                    Country.c2++;
                    break;
                case 3:
                    cr3++;
                    Country.c3++;
                    break;
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
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
                if ( answer != "" )
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
                }
                Console.WriteLine();
            }
            Console.WriteLine("-------------------------");
            Console.WriteLine();
            // Вывод результатов:
            Console.WriteLine("Россия:");
            Console.WriteLine("Вопрос 1");
            var sorted = russia1.OrderByDescending(ob => ob.Count).ToArray(); // Сортируем номинантов по количеству голосов по убыванию.
            for (int i = 0; i < Math.Min(5, sorted.Length); i++)
            {
                Console.Write($"{i + 1}. {sorted[i].Text} - {sorted[i].Count * 100 / Russia.cr1}%");
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Вопрос 2");
            sorted = russia2.OrderByDescending(ob => ob.Count).ToArray(); // Сортируем номинантов по количеству голосов по убыванию.
            for (int i = 0; i < Math.Min(5, sorted.Length); i++)
            {
                Console.Write($"{i + 1}. {sorted[i].Text} - {sorted[i].Count * 100 / Russia.cr2}%");
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Вопрос 3");
            sorted = russia3.OrderByDescending(ob => ob.Count).ToArray(); // Сортируем номинантов по количеству голосов по убыванию.
            for (int i = 0; i < Math.Min(5, sorted.Length); i++)
            {
                Console.Write($"{i + 1}. {sorted[i].Text} - {sorted[i].Count * 100 / Russia.cr3}%");
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Япония:");
            Console.WriteLine("Вопрос 1");
            sorted = japan1.OrderByDescending(ob => ob.Count).ToArray(); // Сортируем номинантов по количеству голосов по убыванию.
            for (int i = 0; i < Math.Min(5, sorted.Length); i++)
            {
                Console.Write($"{i + 1}. {sorted[i].Text} - {sorted[i].Count * 100 / Japan.cr1}%");
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Вопрос 2");
            sorted = japan2.OrderByDescending(ob => ob.Count).ToArray(); // Сортируем номинантов по количеству голосов по убыванию.
            for (int i = 0; i < Math.Min(5, sorted.Length); i++)
            {
                Console.Write($"{i + 1}. {sorted[i].Text} - {sorted[i].Count * 100 / Japan.cr2}%");
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Вопрос 3");
            sorted = japan3.OrderByDescending(ob => ob.Count).ToArray(); // Сортируем номинантов по количеству голосов по убыванию.
            for (int i = 0; i < Math.Min(5, sorted.Length); i++)
            {
                Console.Write($"{i + 1}. {sorted[i].Text} - {sorted[i].Count * 100 / Japan.cr3}%");
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Общее:");
            Country[] all1 = { };
            Country[] all2 = { };
            Country[] all3 = { };
            for (int i = 0; i < russia1.Length; i++)
            {
                try
                {
                    all1 = all1.Append(russia1[i]).ToArray();
                    all2 = all2.Append(russia2[i]).ToArray();
                    all3 = all3.Append(russia3[i]).ToArray();
                    all1 = all1.Append(japan1[i]).ToArray();
                    all2 = all2.Append(japan2[i]).ToArray();
                    all3 = all3.Append(japan3[i]).ToArray();
                }
                catch { };
            }
            Console.WriteLine("Вопрос 1");
            sorted = all1.OrderByDescending(ob => ob.Count).ToArray(); // Сортируем номинантов по количеству голосов по убыванию.
            for (int i = 0; i < Math.Min(5, sorted.Length); i++)
            {
                Console.Write($"{i + 1}. {sorted[i].Text} - {sorted[i].Count * 100 / Country.c1}%");
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Вопрос 2");
            sorted = all2.OrderByDescending(ob => ob.Count).ToArray(); // Сортируем номинантов по количеству голосов по убыванию.
            for (int i = 0; i < Math.Min(5, sorted.Length); i++)
            {
                Console.Write($"{i + 1}. {sorted[i].Text} - {sorted[i].Count * 100 / Country.c2}%");
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Вопрос 3");
            sorted = all3.OrderByDescending(ob => ob.Count).ToArray(); // Сортируем номинантов по количеству голосов по убыванию.
            for (int i = 0; i < Math.Min(5, sorted.Length); i++)
            {
                Console.Write($"{i + 1}. {sorted[i].Text} - {sorted[i].Count * 100 / Country.c3}%");
                Console.WriteLine();
            }
        }
    }
}
