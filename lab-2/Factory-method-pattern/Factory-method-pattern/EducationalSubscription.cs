using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_method_pattern
{
    public class EducationalSubscription : Subscription
    {
        public EducationalSubscription()
        {
            MonthlyFee = 14.99m;
            MinimumPeriod = 3;
            Channels = new List<string> { "Channel D", "Channel E", "Channel F" };
        }
    }
}
