using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_method_pattern
{
    public interface ISubscription
    {
        decimal MonthlyFee { get; }
        int MinPeriod { get; }
        List<string> Channels { get; }
        List<string> Features { get; }

        void GetDetails()
        {
            Console.WriteLine($"Type: {GetType().Name}");
            Console.WriteLine($"- Monthly Fee: ${MonthlyFee}");
            Console.WriteLine($"- Min Period: {MinPeriod} months");
            Console.WriteLine($"- Channels: {string.Join(", ", Channels)}");
            Console.WriteLine($"- Features: {string.Join(", ", Features)}");
            Console.WriteLine();
        }
    }
}
