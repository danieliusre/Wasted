using System;
using System.IO;
using Serilog;

namespace Wasted.Data
{
    public class JsonFileService
    {
        public string ReadJsonFromFile(string filePath)
        {
            try
            {
                CheckFile(filePath);
                var fileContents = File.ReadAllText(filePath);
                return fileContents;
            }
            catch(FileNotFoundException)
            {
                throw;
            }
            catch(Exception e)
            {
                Log.Error("Error reading file: {0} \\n Exception details: {1} ", filePath,e);
                throw;
            }
            
        }
        public void WriteJsonToFile(string json, string filePath="")
        {
            try
            {
                if(String.IsNullOrEmpty(filePath))
                {
                    filePath="DefaultFileDirectory/" + DateTime.Now.ToString();
                }
                File.WriteAllText(filePath, json);
            }
            catch(Exception e)
            {
                Log.Error("Error writing to file: {0} \\n Exception details: {1} ", filePath,e);
            }
        }
        public bool CheckFile(string filePath)
        {
           return File.Exists(filePath) ? true : throw new FileNotFoundException(filePath);
        }
    }
}
