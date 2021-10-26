using System;
using Serilog;
public class FileNotFoundException : Exception
{
    public FileNotFoundException()
    {
        Log.Error("File not found");
    }

    public FileNotFoundException(string filePath)
        : base(String.Format("File not found: {0}", filePath))
    {
    }

}