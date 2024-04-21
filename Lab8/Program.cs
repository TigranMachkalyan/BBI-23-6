using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

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
                for (i  = 0; i < slices.Length; i++)
                {
                    if (slices[i].Length < 50)
                    {
                        slices[i] += new string(' ', 50 - slices[i].Length); ;
                    }
                }
                foreach (string slice in slices)
                {
                    res = res + slice + "|";
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
        class Task_12
        {

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
            Console.WriteLine("Задание 8:");
            var example_8 = new Task_8("После многолетних исследований ученые обнаружили тревожную тенденцию в вырубке лесов Амазонии. Анализ данных показал, что основной участник разрушения лесного покрова – человеческая деятельность. За последние десятилетия рост объема вырубки достиг критических показателей. Главными факторами, способствующими этому, являются промышленные рубки, производство древесины, расширение сельскохозяйственных угодий и незаконная добыча древесины. Это приводит к серьезным экологическим последствиям, таким как потеря биоразнообразия, ухудшение климата и угроза вымирания многих видов животных и растений.");
            Console.WriteLine(example_8);
            Console.WriteLine();

            Console.WriteLine("Задание 9:");
            var example_9 = new Task_9("Двигатель самолета – это сложная инженерная конструкция, обеспечивающая подъем, управление и движение в воздухе. Он состоит из множества компонентов, каждый из которых играет важную роль в общей работе механизма. Внутреннее устройство двигателя включает в себя компрессор, камеру сгорания, турбину и системы управления и охлаждения. Принцип работы основан на воздушно-топливной смеси, которая подвергается сжатию, воспламенению и расширению, обеспечивая движение воздушного судна.");
            Console.WriteLine(example_9);
            Console.WriteLine();

            Console.WriteLine("Задание 10:");
            var example_10 = new Task_10("1 июля 2015 года Греция объявила о дефолте по государственному долгу, став первой развитой страной в истории, которая не смогла выплатить свои долговые обязательства в полном объеме. Сумма дефолта составила порядка 1,6 миллиарда евро. Этому предшествовали долгие переговоры с международными кредиторами, такими как Международный валютный фонд (МВФ), Европейский центральный банк (ЕЦБ) и Европейская комиссия (ЕК), о программах финансовой помощи и реструктуризации долга. Основными причинами дефолта стали недостаточная эффективность реформ, направленных на улучшение финансовой стабильности страны, а также политическая нестабильность, что вызвало потерю доверия со стороны международных инвесторов и кредиторов. Последствия дефолта оказались глубокими и долгосрочными: сокращение кредитного рейтинга страны, увеличение затрат на заемный капитал, рост стоимости заимствований и утрата доверия со стороны международных инвесторов.");
            Console.WriteLine(example_10);
            Console.WriteLine();

            /*Console.WriteLine("Задание 12:");
            var example_12 = new Task_12("Фьорды – это ущелья, формирующиеся ледниками и заполняющиеся морской водой. Название происходит от древнескандинавского слова "fjǫrðr". Эти глубокие заливы, окруженные высокими горами, представляют захватывающие виды и природную красоту. Они популярны среди туристов и известны под разными названиями: в Норвегии – "фьорды", в Шотландии – "фьордс", в Исландии – "фьордар". Фьорды играют важную роль в культуре и туризме региона, продолжая вдохновлять людей со всего мира.");
            Console.WriteLine(example_12);
            Console.WriteLine();*/

            Console.WriteLine("Задание 13:");
            var example_13 = new Task_13("William Shakespeare, widely regarded as one of the greatest writers in the English language, authored a total of 37 plays, along with numerous poems and sonnets. He was born in Stratford-upon-Avon, England, in 1564, and died in 1616. Shakespeare's most famous works, including \"Romeo and Juliet,\" \"Hamlet,\" \"Macbeth,\" and \"Othello,\" were written during the late 16th and early 17th centuries. \"Romeo and Juliet,\" a tragic tale of young love, was penned around 1595. \"Hamlet,\" one of his most celebrated tragedies, was written in the early 1600s, followed by \"Macbeth,\" a gripping drama exploring themes of ambition and power, around 1606. \"Othello,\" a tragedy revolving around jealousy and deceit, was also composed during this period, believed to be around 1603.");
            Console.WriteLine(example_13);
            Console.WriteLine();

            Console.WriteLine("Задание 15:");
            var example_15 = new Task_15("Первое кругосветное путешествие было осуществлено флотом, возглавляемым португальским исследователем Фернаном Магелланом. Путешествие началось 20 сентября 1519 года, когда флот, состоящий из пяти кораблей и примерно 270 человек, отправился из порту Сан-Лукас в Испании. Хотя Магеллан не закончил свое путешествие из-за гибели в битве на Филиппинах в 1521 году, его экспедиция стала первой, которая успешно обогнула Землю и доказала ее круглую форму. Это путешествие открыло новые морские пути и имело огромное значение для картографии и географических открытий.");
            Console.WriteLine(example_15);
            Console.WriteLine();
        }
    }
}
