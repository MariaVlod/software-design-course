using Singleton;
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting the program...");
        
        Authenticator authenticator1 = Authenticator.Instance;
        authenticator1.Authenticate("User1");

        Authenticator authenticator2 = Authenticator.Instance;
        authenticator2.Authenticate("User2");

        if (authenticator1 == authenticator2)
        {
            Console.WriteLine("authenticator1 and authenticator2 are the same instance.");
        }
        else
        {
            Console.WriteLine("authenticator1 and authenticator2 are different instances.");
        }

        Console.WriteLine("Program finished.");
    }
}