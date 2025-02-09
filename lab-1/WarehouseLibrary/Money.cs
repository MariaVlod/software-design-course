using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseLibrary
{
    public class USD : Money
    {
        public USD(int dollars, int cents) : base(dollars, cents) { }
    }

    public class EUR : Money
    {
        public EUR(int euros, int cents) : base(euros, cents) { }
    }

    public class Money
    {
        public int Dollars { get; set; }
        public int Cents { get; set; }

        public Money(int dollars, int cents)
        {
            if (dollars < 0 || cents < 0)
                throw new ArgumentException("Dollars and cents cannot be negative.");

            Dollars = dollars;
            Cents = cents;
            Normalize();
        }

        private void Normalize()
        {
            if (Cents >= 100 || Cents < 0)
            {
                Dollars += Cents / 100;
                Cents %= 100;
                if (Cents < 0)
                {
                    Dollars--;
                    Cents += 100;
                }
            }
        }

        public void Display()
        {
            Console.WriteLine($"${Dollars}.{Cents:00}");
        }

        public void SetAmount(int dollars, int cents)
        {
            Dollars = dollars;
            Cents = cents;
            Normalize();
        }
    }
}
