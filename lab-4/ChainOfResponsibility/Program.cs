using ChainOfResponsibility;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

       
        var billingSupport = new BillingSupportHandler();
        var internetSupport = new InternetSupportHandler();
        var tvSupport = new TVSupportHandler();
        var phoneSupport = new PhoneSupportHandler();
        var otherSupport = new OtherSupportHandler();

        billingSupport.SetNextHandler(internetSupport);
        internetSupport.SetNextHandler(tvSupport);
        tvSupport.SetNextHandler(phoneSupport);
        phoneSupport.SetNextHandler(otherSupport);

        Console.WriteLine("Ласкаво просимо до системи підтримки користувачів!");

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\nОберіть тип проблеми:");
            Console.WriteLine("1. Проблема з рахунком");
            Console.WriteLine("2. Проблема з інтернетом");
            Console.WriteLine("3. Проблема з телебаченням");
            Console.WriteLine("4. Проблема з телефонією");
            Console.WriteLine("5. Інша проблема");
            Console.WriteLine("0. Вийти");

            Console.Write("Ваш вибір: ");
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                if (choice == 0)
                {
                    exit = true;
                    continue;
                }

                if (choice >= 1 && choice <= 5)
                {
                   
                    billingSupport.HandleRequest(choice);

                    
                    if (!IsRequestHandled(billingSupport))
                    {
                        Console.WriteLine("\nНе вдалося визначити відповідний рівень підтримки.");
                        Console.WriteLine("Будь ласка, спробуйте ще раз.\n");
                    }
                }
                else
                {
                    Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                }
            }
            else
            {
                Console.WriteLine("Будь ласка, введіть число.");
            }
        }

        Console.WriteLine("Дякуємо за звернення! Гарного дня!");
    }

    static bool IsRequestHandled(SupportHandler handler)
    {
        var current = handler;
        while (current != null)
        {
            if (current.RequestHandled)
                return true;
            current = current.GetNextHandler(); 
        }
        return false;
    }
}