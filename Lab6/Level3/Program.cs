using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Level3
{
    // Номер по списку - 18 ==> Этот файл - решение 6-го номера третьего уровня.
    struct Response // Структура ответа на вопрос
    {
        private string text; // Сам ответ
        private int count; // Счетчик голосов за этот ответ
        public string Text { get { return text; } }
        public int Count { get { return count; } }
        public Response(string text)
        {
            this.text = text;
            count = 1; // При создании нового ответа, ему присваивается один голос.
        }
        public void Choice() { count++; } // Метод, который добавляет голос ответу.
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Response[] responses1 = { };
            Response[] responses2 = { };
            Response[] responses3 = { };
            Console.WriteLine("Отвечайте на вопросы за разных людей, если ответа на вопрос нет - просто нажимайте ENTER");

            // Моделирование опроса:
            Console.WriteLine("Сколько человек прошли опрос?");
            int n = int.Parse(Console.ReadLine());
            int c1 = 0; int c2 = 0; int c3 = 0;
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Человек {i + 1}:");
                Console.WriteLine("Какое животное Вы связываете с Японией и японцами?");
                string answer = Console.ReadLine();
                if ( answer != "" )
                {
                    string[] answers = responses1.Select(x => x.Text).ToArray();
                    if (answers.Contains(answer))
                    {
                        responses1[Array.IndexOf(answers, answer)].Choice();
                    }
                    else
                    {
                        responses1 = responses1.Append(new Response(answer)).ToArray();
                    }
                    c1++;
                }
                
                Console.WriteLine("Какая черта характера присуща японцам больше всего?");
                answer = Console.ReadLine();
                if (answer != "")
                {
                    string[] answers = responses2.Select(x => x.Text).ToArray();
                    if (answers.Contains(answer))
                    {
                        responses2[Array.IndexOf(answers, answer)].Choice();
                    }
                    else
                    {
                        responses2 = responses2.Append(new Response(answer)).ToArray();
                    }
                    c2++;
                }
                Console.WriteLine("Какай неодушевленный предмет или понятие Вы связываете с Японией?");
                answer = Console.ReadLine();
                if (answer != "")
                {
                    string[] answers = responses3.Select(x => x.Text).ToArray();
                    if (answers.Contains(answer))
                    {
                        responses3[Array.IndexOf(answers, answer)].Choice();
                    }
                    else
                    {
                        responses3 = responses3.Append(new Response(answer)).ToArray();
                    }
                    c3++;
                }
                Console.WriteLine();
            }
            Console.WriteLine("-------------------------");
            Console.WriteLine();
            // Вывод результатов:
            Console.WriteLine("Какое животное Вы связываете с Японией и японцами?");
            var sorted = responses1.OrderByDescending(ob => ob.Count).ToArray(); // Сортируем номинантов по количеству голосов по убыванию.
            for (int i = 0; i < Math.Min(5, sorted.Length); i++)
            {
                Console.Write($"{i + 1}. {sorted[i].Text} - {sorted[i].Count * 100 / c1}%");
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Какая черта характера присуща японцам больше всего?");
            sorted = responses2.OrderByDescending(ob => ob.Count).ToArray(); // Сортируем номинантов по количеству голосов по убыванию.
            for (int i = 0; i < Math.Min(5, sorted.Length); i++)
            {
                Console.Write($"{i + 1}. {sorted[i].Text} - {sorted[i].Count * 100 / c1}%");
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Какай неодушевленный предмет или понятие Вы связываете с Японией?");
            sorted = responses3.OrderByDescending(ob => ob.Count).ToArray(); // Сортируем номинантов по количеству голосов по убыванию.
            for (int i = 0; i < Math.Min(5, sorted.Length); i++)
            {
                Console.Write($"{i + 1}. {sorted[i].Text} - {sorted[i].Count * 100 / c1}%");
                Console.WriteLine();
            }
        }
    }
}
