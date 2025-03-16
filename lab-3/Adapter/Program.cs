using Adapter;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        ILogger consoleLogger = new ConsoleLogger();
        consoleLogger.Log("Це інформаційне повідомлення");
        consoleLogger.Error("Це повідомлення про помилку");
        consoleLogger.Warn("Це попередження");

        
        FileWriter fileWriter = new FileWriter();
        ILogger fileLogger = new FileLogger(fileWriter);
        fileLogger.Log("Лог у файл");
        fileLogger.Error("Помилка у файлі");
        fileLogger.Warn("Попередження у файлі");
      
        Console.WriteLine("Логування завершено. Перевірте файл log.txt.");
        Console.WriteLine("Знайдіть файл у: lab-3\\Adapter\\bin\\Debug\\net7.0\\log.txt");
    }
}