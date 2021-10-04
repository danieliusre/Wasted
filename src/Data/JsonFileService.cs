using System;
using System.IO;

namespace Wasted.Data
{
    public class JsonFileService
    {
        public string ReadJsonFromFile(string filePath)
        {
            return File.ReadAllText(filePath);
        }
        public void WriteJsonToFile(string json, string filePath)
        {
            File.WriteAllText(filePath, json);
        }
    }
}
