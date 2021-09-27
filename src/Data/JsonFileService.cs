using System;
using System.IO;

namespace Wasted.Data
{
    public class JsonFileService
    {
        public string ReadJsonFromFile(string filePath)
        {
            using (StreamReader r = new StreamReader(filePath))
            {
                return r.ReadToEnd();
            }
        }
        public void WriteJsonToFile(string json, string filePath)
        {
            File.WriteAllText(filePath, json);
        }
    }
}
