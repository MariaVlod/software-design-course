using Factory_method_pattern;
using System;

class Program
{
    static void Main()
    {
        List<SubscriptionCreator> creators = new()
        {
            new WebSite(),
            new MobileApp(),
            new ManagerCall()
        };

        foreach (var creator in creators)
        {
            creator.ProcessSubscription();
        }
    }
}