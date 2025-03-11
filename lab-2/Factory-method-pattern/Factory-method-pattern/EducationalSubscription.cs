using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_method_pattern
{
    public class EducationalSubscription : ISubscription
    {
        public decimal MonthlyFee => 5m;
        public int MinPeriod => 6;
        public List<string> Channels => new() { "Education", "Science", "Kids" };
        public List<string> Features => new() { "Parental Control", "Offline Access" };
    }
}
