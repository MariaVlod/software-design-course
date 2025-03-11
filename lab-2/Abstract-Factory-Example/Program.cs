using Abstract_Factory_Example.Factories;
using Abstract_Factory_Example.Devices;
using Abstract_Factory_Example.Client;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("Демонстрація роботи абстрактної фабрики для створення техніки різних брендів:");
        Console.WriteLine("========================================================================");

        IDeviceFactory factory;

        
        Console.WriteLine("\nВикористання фабрики IProne:");
        Client client1 = new Client(new IProneFactory());
        client1.Run();

       

       
        Console.WriteLine("\nВикористання фабрики Kiaomi:");
        Client client2 = new Client(new KiaomiFactory());
        client2.Run();


        Console.WriteLine("\nВикористання фабрики Balaxy:");
        Client client3 = new Client(new BalaxyFactory());
        client3.Run();

    }
}