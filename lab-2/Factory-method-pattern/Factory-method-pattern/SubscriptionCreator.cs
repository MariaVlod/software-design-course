using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_method_pattern
{
    public abstract class SubscriptionCreator
    {
        public abstract ISubscription CreateSubscription();

        public void ProcessSubscription()
        {
            var subscription = CreateSubscription();
            Console.WriteLine("Processing new subscription...");
            subscription.GetDetails();
        }
    }
}
