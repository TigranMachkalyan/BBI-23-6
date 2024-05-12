using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Xml.Serialization;
using System.IO;

namespace Lab10
{
    abstract class MySerializer
    {
        public abstract T Read<T>(string filepath);
        public abstract void Write<T>(T obj, string filepath);
    }
    class MyJsonSerializer : MySerializer
    {
        public override T Read<T>(string filepath)
        {
            string s = File.ReadAllText(filepath);
            return JsonSerializer.Deserialize<T>(s);
        }
        public override void Write<T>(T obj, string filepath)
        {
            using (var fs = new FileStream(filepath, FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize(fs, obj);
            }
        }
    }
    class MyXmlSerializer : MySerializer
    {
        public override T Read<T>(string filepath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (var fs = new FileStream(filepath, FileMode.Open))
            {
                return (T)serializer.Deserialize(fs);
            }
        }
        public override void Write<T>(T obj, string filepath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (var fs = new FileStream(filepath, FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, obj);
            }
        }
    }
}
