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
            string final_path = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
            final_path = Path.Combine(data_path, "Final datas");
            if (!Directory.Exists(final_path))
            {
                Directory.CreateDirectory(final_path);
            }
            var json = new MyJsonSerializer();
            var xml = new MyXmlSerializer();
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
            analyzer.Add(new Bakery("Тульский пряник со сгущенкой", 200, "18.05.2024", "Пряники", true), 4);
            json.Write(analyzer.GetStat(), Path.Combine(raw_path, $"raw_data_{analysis_i}.json"));
            json.Write(analyzer.GetStat(), Path.Combine(final_path, $"stat_data_{analysis_i}.json"));
            xml.Write(analyzer.GetStat(), Path.Combine(final_path, $"stat_data_{analysis_i}.xml"));
            int final_i = analysis_i;
            analysis_i++;
            analyzer.Delete(new Vegetable("Огурец", 100, "26.05.2024", true, false));
            xml.Write(analyzer.GetStat(), Path.Combine(raw_path, $"raw_data_{analysis_i}.json"));
            analysis_i++;
            analyzer.Delete(new Meat("Говядина", 2000, "19.05.2024", false, true), 3);
            xml.Write(analyzer.GetStat(), Path.Combine(raw_path, $"raw_data_{analysis_i}.json"));
            analysis_i++;
            var res = json.Read<string[]>(Path.Combine(final_path, $"stat_data_{final_i}.json"));
            foreach (var item in res) { Console.WriteLine(item); }
            Console.WriteLine("------------------------");
            res = xml.Read<string[]>(Path.Combine(final_path, $"stat_data_{final_i}.xml"));
            foreach (var item in res) { Console.WriteLine(item); }
        }
    }
}
