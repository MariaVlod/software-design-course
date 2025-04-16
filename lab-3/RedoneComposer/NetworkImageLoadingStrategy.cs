using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedoneComposer
{
    internal class NetworkImageLoadingStrategy : IImageLoadingStrategy
    {
        public void LoadImage(string href)
        {
            Console.WriteLine($"Завантаження зображення з мережі: {href}");
        }

        public string GetLoadingInfo()
        {
            return "Використано стратегію мережного завантаження";
        }
    }

}
