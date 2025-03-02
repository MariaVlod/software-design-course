using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_method_pattern
{
    public class DomesticSubscription : Subscription
    {
        public DomesticSubscription()
        {
            MonthlyFee = 9.99m;
            MinimumPeriod = 1;
            Channels = new List<string> { "Channel A", "Channel B", "Channel C" };
        }
    }
}
