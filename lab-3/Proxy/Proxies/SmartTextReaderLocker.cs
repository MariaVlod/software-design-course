using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Proxy.Proxies
{
    public class SmartTextReaderLocker : IService
    {
        private readonly IService _service;
        private readonly Regex _restrictionPattern;

        public SmartTextReaderLocker(IService service, string regexPattern)
        {
            _service = service;
            _restrictionPattern = new Regex(regexPattern, RegexOptions.IgnoreCase);
        }

        public char[][] ReadFile(string path)
        {
            if (_restrictionPattern.IsMatch(path))
            {
                Console.WriteLine("[ACCESS DENIED] You do not have permission to access this file.");
                return new char[0][];
            }

            return _service.ReadFile(path);
        }
    }
}
