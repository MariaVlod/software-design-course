using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedoneComposer
{
    internal class FileImageLoadingStrategy : IImageLoadingStrategy
    {
        public void LoadImage(string href)
        {
            Console.WriteLine($"Завантаження зображення з файлової системи: {href}");
        }

        public string GetLoadingInfo()
        {
            return "Використано стратегію завантаження з файлової системи";
        }
    }
}
