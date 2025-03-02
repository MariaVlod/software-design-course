using Abstract_Factory_Example.Factories;
using Abstract_Factory_Example.Devices;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("Демонстрація роботи абстрактної фабрики для створення техніки різних брендів:");
        Console.WriteLine("========================================================================");

        IDeviceFactory factory;

        
        Console.WriteLine("\nВикористання фабрики IProne:");
        factory = new IProneFactory();
        var iproneLaptop = factory.CreateLaptop();
        var iproneNetbook = factory.CreateNetbook();
        var iproneEBook = factory.CreateEBook();
        var iproneSmartphone = factory.CreateSmartphone();

        iproneLaptop.DisplayInfo();
        iproneNetbook.DisplayInfo();
        iproneEBook.DisplayInfo();
        iproneSmartphone.DisplayInfo();

       
        Console.WriteLine("\nВикористання фабрики Kiaomi:");
        factory = new KiaomiFactory();
        var kiaomiLaptop = factory.CreateLaptop();
        var kiaomiNetbook = factory.CreateNetbook();
        var kiaomiEBook = factory.CreateEBook();
        var kiaomiSmartphone = factory.CreateSmartphone();

        kiaomiLaptop.DisplayInfo();
        kiaomiNetbook.DisplayInfo();
        kiaomiEBook.DisplayInfo();
        kiaomiSmartphone.DisplayInfo();

       
        Console.WriteLine("\nВикористання фабрики Balaxy:");
        factory = new BalaxyFactory();
        var balaxyLaptop = factory.CreateLaptop();
        var balaxyNetbook = factory.CreateNetbook();
        var balaxyEBook = factory.CreateEBook();
        var balaxySmartphone = factory.CreateSmartphone();

        balaxyLaptop.DisplayInfo();
        balaxyNetbook.DisplayInfo();
        balaxyEBook.DisplayInfo();
        balaxySmartphone.DisplayInfo();

    }
}