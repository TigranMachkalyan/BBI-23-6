using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Lab8
{
    internal class Program
    {
        abstract class Task
        {
            protected string _text;
            protected string _res;
            protected Task(string text)
            {
                _text = text;
            }
            public override string ToString()
            {
                return _res;
            }
        }

        class Task_8: Task
        {
            
            public Task_8(string text): base(text)
            {
                Do_The_Task(_text, out _res);
            }
            private void Do_The_Task(string text, out string res)
            {
                string[] words = text.Split(new char[] { ' ' });
                res = "";
                string[] slices = { };
                int i = 0;
                while (i < words.Length - 1)
                {
                    string sub = "";
                    int lastlen = 0;
                    while (sub.Length <= 50 & i < words.Length)
                    {
                        sub = sub + words[i] + " ";
                        lastlen = words[i].Length + 1;
                        i++;
                    }
                    i--;
                    sub = sub.Remove(sub.Length - lastlen);
                    slices = slices.Append(sub).ToArray();
                }
                slices[slices.Length - 1] += words[words.Length - 1];
                for (i = 0; i < slices.Length; i++)
                {
                    slices[i] = slices[i].Substring(0, slices[i].Length - 1);
                    int count_spaces = slices[i].Count(x => (x == ' '));
                    if (count_spaces > 0)
                    {
                        slices[i] = slices[i].Replace(" ", new string(' ', 1 + (49 - slices[i].Length) / count_spaces));
                    }
                    int ost = (49 - slices[i].Length) % count_spaces;
                    int j = 0;
                    while(ost > 0)
                    {
                        if (slices[i][j] == ' ' & slices[i][j + 1] != ' ')
                        {
                            slices[i] = slices[i].Substring(0, j + 1) + ' ' + slices[i].Substring(j + 1);
                            j++;
                            ost--;
                        }
                        j++;
                    }
                    slices[i] += new string(' ', 50 - slices[i].Length);
                    res = res + slices[i] + "\n";
                }
            }
        }
        class Task_9: Task
        {
            protected string res_text;
            protected Dictionary<string, string> decode_table;
            public Task_9(string text) : base(text)
            {
                Do_The_Task(_text, out res_text, out decode_table);
                _res += res_text + "\n\n";
                foreach (var pair in decode_table)
                {
                    _res += $"{pair.Key}: {pair.Value}\n";
                }
            }
            private void Do_The_Task(string text, out string res, out Dictionary<string, string> decode)
            {
                res = text;
                string[] codes = { "¢", "¤", "¦", "§", "©", "ª", "¬", "®", "°", "²", "³", "µ", "¶", "¹", "º" };
                decode = new Dictionary<string, string>();
                var pairs = new Dictionary<string, int>();
                for (int i = 0; i < res.Length - 1; i++)
                {
                    if (res[i] == res[i + 1])
                    {
                        if (pairs.ContainsKey($"{res[i]}{res[i + 1]}"))
                        {
                            pairs[$"{res[i]}{res[i + 1]}"]++;
                        }
                        else
                        {
                            pairs.Add($"{res[i]}{res[i + 1]}", 1);
                        }
                    }
                }
                int j = 0;
                foreach (var pair in pairs)
                {
                    res = res.Replace(pair.Key, codes[j]);
                    decode.Add(codes[j], pair.Key);
                    j++;
                }
            }
        }
        class Task_10 : Task_9
        {
            public Task_10(string text) : base(text)
            {
                Do_The_Task(res_text, decode_table, out _res);
            }
            private void Do_The_Task(string text, Dictionary<string, string> table, out string res)
            {
                res = text;
                foreach (var pair in table)
                {
                    res = res.Replace(pair.Key, pair.Value);
                }
            }
        }
        class Task_12: Task
        {
            public Task_12(string text) : base(text)
            {
                Do_The_Task(_text, out _res);
            }
            private void Do_The_Task(string text, out string res)
            {
                res = "";
                string res1 = text;
                string[] words = text.Split(new char[] { ' ', ',', '.' });
                var codes = new Dictionary<string, int>();
                int c = 0;
                codes.Add(words[0], c);
                res1 = $"~{codes[words[0]]}~" + res1.Substring(words[0].Length);
                c++;
                foreach (var word in words)
                {
                    if (word != "")
                    {
                        if (codes.ContainsKey(word))
                        {
                            foreach (char delimeter in new char[] { ' ', ',', '.'})
                            {
                                res1 = res1.Replace($" {word}{delimeter}", $" ~{codes[word]}~{delimeter}");
                            }
                        }
                        else
                        {
                            codes.Add(word, c);
                            foreach (char delimeter in new char[] { ' ', ',', '.' })
                            {
                                res1 = res1.Replace($" {word}{delimeter}", $" ~{codes[word]}~{delimeter}");
                            }
                            c++;
                        }
                    }
                }
                res += res1 + "\n------------------------\n";
                string res2 = res1;
                foreach (var code in codes)
                {
                    res2 = res2.Replace($"~{code.Value}~", code.Key);
                }
                res += res2;
            }
        }
        class Task_13: Task
        {
            public Task_13(string text) : base(text)
            {
                Do_The_Task(_text, out _res);
            }
            private void Do_The_Task(string text, out string res)
            {
                res = "";
                string[] words = text.Split(new char[] { ' ' });
                var starts = new Dictionary<char, int>();
                foreach (var word in words)
                {
                    char s = char.ToLower(word[0]);
                    if (starts.ContainsKey(s))
                    {
                        starts[s]++;
                    }
                    else
                    {
                        starts.Add(s, 1);
                    }
                }
                foreach (var start in starts)
                {
                    res += $"{start.Key}: {start.Value * 100/words.Length}%\n";
                }
            }
        }
        class Task_15: Task
        {
            public Task_15(string text) : base(text)
            {
                Do_The_Task(_text, out _res);
            }
            private void Do_The_Task(string text, out string res)
            {
                res = "";
                decimal res_dec = 0;
                int i = 0;
                while (i < text.Length)
                {
                    string sub = "";
                    while ((char.IsDigit(text[i]) | ((text[i] == ',') & sub != "" & sub.Count(f => (f == ',')) == 0)) & i < text.Length)
                    {
                        if (text[i] == '-')
                        {
                            if (i == text.Length - 1)
                            {
                                break;
                            }
                            else
                            {
                                if (!(char.IsDigit(text[i + 1]) & (sub == "") & sub.Count(f => (f == '-')) == 0))
                                {
                                    break;
                                }
                            }
                        }
                        sub += text[i];
                        i++;
                    }
                    if (sub != "")
                    {
                        res_dec += decimal.Parse(sub);
                    }
                    else { i++; }
                }
                res = res_dec.ToString();
            }
        }

        static void Main(string[] args)
        {
            string t = "Первое кругосветное путешествие было осуществлено флотом, возглавляемым португальским исследователем Фернаном Магелланом. Путешествие началось 20 сентября 1519 года, когда флот, состоящий из пяти кораблей и примерно 270 человек, отправился из порту Сан-Лукас в Испании. Хотя Магеллан не закончил свое путешествие из-за гибели в битве на Филиппинах в 1521 году, его экспедиция стала первой, которая успешно обогнула Землю и доказала ее круглую форму. Это путешествие открыло новые морские пути и имело огромное значение для картографии и географических открытий.";

            Console.WriteLine("Задание 8:");
            var example_8 = new Task_8(t);
            Console.WriteLine(example_8);
            Console.WriteLine();

            Console.WriteLine("Задание 9:");
            var example_9 = new Task_9(t);
            Console.WriteLine(example_9);
            Console.WriteLine();

            Console.WriteLine("Задание 10:");
            var example_10 = new Task_10(t);
            Console.WriteLine(example_10);
            Console.WriteLine();

            Console.WriteLine("Задание 12:");
            var example_12 = new Task_12(t);
            Console.WriteLine(example_12);
            Console.WriteLine();

            Console.WriteLine("Задание 13:");
            var example_13 = new Task_13(t);
            Console.WriteLine(example_13);
            Console.WriteLine();

            Console.WriteLine("Задание 15:");
            var example_15 = new Task_15(t);
            Console.WriteLine(example_15);
            Console.WriteLine();
        }
    }
}
