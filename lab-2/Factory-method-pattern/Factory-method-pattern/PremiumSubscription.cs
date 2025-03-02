using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_method_pattern
{
    public class PremiumSubscription : Subscription
    {
        public PremiumSubscription()
    {
        MonthlyFee = 29.99m;
        MinimumPeriod = 6;
        Channels = new List<string> { "Channel G", "Channel H", "Channel I" };
    }
    }
}
