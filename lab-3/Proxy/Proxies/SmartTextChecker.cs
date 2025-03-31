using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Proxies
{
    public class SmartTextChecker : IService
    {

        private readonly IService _service;

        public SmartTextChecker(IService service)
        {
            _service = service;
        }

        public char[][] ReadFile(string path)
        {
            Console.WriteLine($"[LOG] Attempting to open file: {path}");
            char[][] content = _service.ReadFile(path);

            if (content.Length > 0) 
            {
                int lines = content.Length;
                int characters = 0;
                foreach (var line in content)
                {
                    characters += line.Length;
                }

                Console.WriteLine($"[LOG] File read successfully. Lines: {lines}, Characters: {characters}");
            }
            else
            {
                Console.WriteLine($"[LOG] File access denied or file is empty.");
            }

            Console.WriteLine($"[LOG] Closing file: {path}");

            return content;
        }

    }
}
