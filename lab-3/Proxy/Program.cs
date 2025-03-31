using Proxy.Proxies;
using Proxy;
using System.Text;
using System;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        string allowedPath = "allowed_file.txt";
        string restrictedPath = "restricted_file.txt";

        File.WriteAllText(allowedPath, "Hello\nThis is a test file.");
        File.WriteAllText(restrictedPath, "You should not be able to read this.");

        IService baseReader = new SmartTextReader();
        IService loggingProxy = new SmartTextChecker(baseReader);
        IService accessProxy = new SmartTextReaderLocker(baseReader, @".*restricted.*");
        IService combinedProxy = new SmartTextChecker(new SmartTextReaderLocker(baseReader, @".*restricted.*"));

        Console.WriteLine("\n______ Base Reader Test ______");
        PrintContent(baseReader.ReadFile(allowedPath));

        Console.WriteLine("\n______ Logging Proxy Test ______");
        PrintContent(loggingProxy.ReadFile(allowedPath));

        Console.WriteLine("\n______ Access Restriction Proxy Test (Allowed File) ______");
        PrintContent(accessProxy.ReadFile(allowedPath));

        Console.WriteLine("\n______ Access Restriction Proxy Test (Restricted File) ______");
        PrintContent(accessProxy.ReadFile(restrictedPath));

        Console.WriteLine("\n______ Combined Proxy Test (Allowed File) ______");
        PrintContent(combinedProxy.ReadFile(allowedPath));

        Console.WriteLine("\n______ Combined Proxy Test (Restricted File) ______");
        PrintContent(combinedProxy.ReadFile(restrictedPath));
    }

    static void PrintContent(char[][] content)
    {
        if (content == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Access denied: You do not have permission to read this file.");
            Console.ResetColor();
            return;
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("File content:");
        Console.ResetColor();

        foreach (var line in content)
        {
            Console.WriteLine(new string(line));
        }
    }
}