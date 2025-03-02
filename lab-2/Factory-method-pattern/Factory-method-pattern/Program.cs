using Factory_method_pattern;
using System;

class Program
{
    static void Main(string[] args)
    {
        ISubscriptionFactory webSite = new WebSite();
        ISubscriptionFactory mobileApp = new MobileApp();
        ISubscriptionFactory managerCall = new ManagerCall();
       
        Subscription domesticSubscription = webSite.CreateSubscription();
        Subscription premiumSubscription = mobileApp.CreateSubscription();
        Subscription educationalSubscription = managerCall.CreateSubscription();

        Console.WriteLine("Domestic Subscription:");
        Console.WriteLine($"Monthly Fee: {domesticSubscription.MonthlyFee}");
        Console.WriteLine($"Minimum Period: {domesticSubscription.MinimumPeriod} months");
        Console.WriteLine($"Channels: {string.Join(", ", domesticSubscription.Channels)}");

        Console.WriteLine("\nPremium Subscription:");
        Console.WriteLine($"Monthly Fee: {premiumSubscription.MonthlyFee}");
        Console.WriteLine($"Minimum Period: {premiumSubscription.MinimumPeriod} months");
        Console.WriteLine($"Channels: {string.Join(", ", premiumSubscription.Channels)}");

        Console.WriteLine("\nEducational Subscription:");
        Console.WriteLine($"Monthly Fee: {educationalSubscription.MonthlyFee}");
        Console.WriteLine($"Minimum Period: {educationalSubscription.MinimumPeriod} months");
        Console.WriteLine($"Channels: {string.Join(", ", educationalSubscription.Channels)}");
    }
}