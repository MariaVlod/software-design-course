using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_method_pattern
{
    public class PremiumSubscription : ISubscription
    {
        public decimal MonthlyFee => 20m;
        public int MinPeriod => 12;
        public List<string> Channels => new() { "All Channels", "4K Streaming", "Exclusive Content" };
        public List<string> Features => new() { "24/7 Support", "No Ads", "Multi-Device Access" };
    }
}
