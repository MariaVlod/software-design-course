using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_method_pattern
{
    public class DomesticSubscription : ISubscription
    {
        public decimal MonthlyFee => 10m;
        public int MinPeriod => 1;
        public List<string> Channels => new() { "News", "Entertainment", "Sports" };
        public List<string> Features => new() { "Basic Support", "HD Quality" };
    }
}
