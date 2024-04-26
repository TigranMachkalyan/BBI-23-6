using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Diagnostics.Tracing;
using System.IO;

namespace KR
{
    internal class Program
    {
        abstract class Task
        {
            protected string text;
            public string Text { get { return text; } }
            protected string result;
            public string Result { get { return result; } }
            public Task(string text)
            {
                this.text = text;
            }
            public override string ToString()
            {
                return result;
            }
        }
        class Task1: Task
        {
            [JsonConstructor]
            public Task1(string text): base(text)
            {
                result = DoTheTask(text);
            }
            private string DoTheTask(string inp)
            {
                int c = 0;
                string[] words = inp.Split(new char[] { ' ', '.', '!', '?', ',', '"', ';', ':', '(', ')'});
                foreach (var word in words)
                {
                    if (IsWord(word))
                    {
                        c++;
                    }
                }
                return c.ToString();
            }
            private bool IsWord(string s)
            {
                if (s == "") { return false; }
                foreach(char x in s)
                {
                    if (char.IsDigit(x))
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        class Task2 : Task
        {
            [JsonConstructor]
            public Task2(string text) : base(text)
            {
                result = DoTheTask(text);
            }
            private string DoTheTask(string inp)
            {
                var open_skobki = new List<char> { '(', '[', '{' };
                var close_skobki = new List<char> { ')', ']', '}' };
                char[] meeted = { };
                foreach (char x in inp)
                {
                    if (open_skobki.Contains(x) | close_skobki.Contains(x))
                    {
                        meeted = meeted.Append(x).ToArray();
                    }
                }
                if (meeted.Length % 2 == 0)
                {
                    char[] lasts = { };
                    int j = 0;
                    foreach (char x in meeted)
                    {
                        if (open_skobki.Contains(x))
                        {
                            lasts = lasts.Append(x).ToArray();
                        }
                        else if (close_skobki.Contains(x))
                        {
                            char last = lasts[lasts.Length - 1 - j];
                            j++;
                            if (x != close_skobki[open_skobki.IndexOf(last)])
                            {
                                return "No";
                            }
                        }
                    }
                    return "Yes";
                }
                return "No";
            }
        }
        class JsonIO
        {
            static public void Write<T> (T obj, string filepath)
            {
                using (var fs = new FileStream(filepath, FileMode.OpenOrCreate))
                {
                    JsonSerializer.Serialize(fs, obj);
                }
            }
            static public T Read<T>(string filepath)
            {
                string s = File.ReadAllText(filepath);
                return JsonSerializer.Deserialize<T>(s);
            }
        }

        static void Main(string[] args)
        {
            Task[] tasks = {
                new Task1("You are my sunshine. My only sunshine! You make 52 me happy, when sky is..."),
                new Task2("You [are my sunshine]. {My only sunshine!( You make }52 me happy}, when sky is...")
            };
            Console.WriteLine(tasks[0]);
            Console.WriteLine(tasks[1]);

            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Answer");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string filepath1 = Path.Combine(path, "task_1.json");
            string filepath2 = Path.Combine(path, "task_2.json");
            if (!File.Exists(filepath1))
            {
                JsonIO.Write<Task1>((Task1)tasks[0], filepath1);
            }
            else
            {
                var res = JsonIO.Read<Task1>(filepath1);
                Console.WriteLine(res);
            }
            if (!File.Exists(filepath2))
            {
                JsonIO.Write<Task2>((Task2)tasks[1], filepath2);
            }
            else
            {
                var res = JsonIO.Read<Task2>(filepath2);
                Console.WriteLine(res.Result);
            }
        }
    }
}
