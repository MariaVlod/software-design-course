using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_method_pattern
{
    public class ManagerCall : SubscriptionCreator
    {
        public override ISubscription CreateSubscription() => new PremiumSubscription();
    }
}
