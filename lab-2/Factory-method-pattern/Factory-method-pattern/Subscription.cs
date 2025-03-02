using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_method_pattern
{
    public abstract class Subscription
    {
        public decimal MonthlyFee { get; protected set; }
        public int MinimumPeriod { get; protected set; }
        public List<string> Channels { get; protected set; }

        public Subscription()
        {
            Channels = new List<string>();
        }
    }
}
