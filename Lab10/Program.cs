using System;
using System.IO;

namespace Lab10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
            string data_path = Path.Combine(path, "data");
            string raw_path = Path.Combine(data_path, "Raw datas");
            if (!Directory.Exists(raw_path))
            {
                Directory.CreateDirectory(raw_path);
            }
            string final_path = Path.Combine(data_path, "Final datas");
            if (!Directory.Exists(final_path))
            {
                Directory.CreateDirectory(final_path);
            }
            var json = new MyJsonSerializer();
            var xml = new MyXmlSerializer();
            var binary = new MyBinarySerializer();
            FoodQualityAnalyzer analyzer = new FoodQualityAnalyzer();
            int analysis_i = 1;
            analyzer.Add(new Vegetable("Огурец", 100, "26.05.2024", true, false));
            json.Write(analyzer.GetStat(), Path.Combine(raw_path, $"raw_data_1.json"));
            analysis_i++;
            analyzer.Add(new Fruit("Апельсин", 300, "29.05.2024", "Морокко", true), 2);
            json.Write(analyzer.GetStat(), Path.Combine(raw_path, $"raw_data_{analysis_i}.json"));
            analysis_i++;
            analyzer.Add(new Meat("Говядина", 2000, "19.05.2024", false, true), 3);
            json.Write(analyzer.GetStat(), Path.Combine(raw_path, $"raw_data_{analysis_i}.json"));
            analysis_i++;
            analyzer.Add(new Bakery("Тульский пряник со сгущенкой", 200, "17.05.2024", "Пряники", true), 4);
            json.Write(analyzer.GetStat(), Path.Combine(raw_path, $"raw_data_{analysis_i}.json"));
            json.Write(analyzer.GetStat(), Path.Combine(final_path, $"stat_data_{analysis_i}.json"));
            xml.Write(analyzer.GetStat(), Path.Combine(final_path, $"stat_data_{analysis_i}.xml"));
            int final_i = analysis_i;
            analysis_i++;
            analyzer.Delete(new Vegetable("Огурец", 100, "26.05.2024", true, false));
            xml.Write(analyzer.GetStat(), Path.Combine(raw_path, $"raw_data_{analysis_i}.xml"));
            analysis_i++;
            analyzer.Delete(new Meat("Говядина", 2000, "19.05.2024", false, true), 3);
            xml.Write(analyzer.GetStat(), Path.Combine(raw_path, $"raw_data_{analysis_i}.xml"));
            analysis_i++;
            var res = json.Read<string[]>(Path.Combine(final_path, $"stat_data_{final_i}.json"));
            foreach (var item in res) { Console.WriteLine(item); }
            Console.WriteLine("------------------------");
            res = xml.Read<string[]>(Path.Combine(final_path, $"stat_data_{final_i}.xml"));
            foreach (var item in res) { Console.WriteLine(item); }
            Console.WriteLine("-------------------------");
            Standart s1 = new Standart("EuroPlus", new double[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            Standart s2 = new Standart("GOST", new double[] { 0, 1, 3, 5, 6, 7, 8, 8, 9, 10 });
            analyzer = new FoodQualityAnalyzer();
            analyzer.Add(new FriedMeat("Nuggets", 200, "19.05.2024", true, true, "Deep", true, s1));
            analyzer.Add(new FriedMeat("Beef", 800, "18.05.2024", false, true, "Pan", false, s1));
            analyzer.Add(new FriedMeat("Kebab", 500, "20.05.2024", true, false, "Mangal", false, s2));
            analyzer.Add(new FriedMeat("Sausages", 2000, "25.05.2024", false, false, "Tandoor", false, s2));
            binary.Write(analyzer.GetStat(), Path.Combine(raw_path, $"raw_data.bin"));
            FoodQualityAnalyzer.SortByQualityDesc(analyzer);
            binary.Write(analyzer.GetStat(), Path.Combine(final_path, $"sorted_data.bin"));
            FoodQualityAnalyzer.SortByNameDesc(analyzer);
            foreach (var prod in analyzer) { Console.WriteLine(prod); }
            Console.WriteLine("-------------------------");
            res = binary.Read<string[]>(Path.Combine(raw_path, $"raw_data.bin"));
            foreach (var item in res) { Console.WriteLine(item); }
            Console.WriteLine("------------------------");
            res = binary.Read<string[]>(Path.Combine(final_path, $"sorted_data.bin"));
            foreach (var item in res) { Console.WriteLine(item); }
            Console.WriteLine("------------------------");
        }
    }
}
