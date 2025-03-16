using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    public class FileWriter
    {
        private string filePath = "log.txt";

        public void Write(string message)
        {
            File.AppendAllText(filePath, message);
        }

        public void WriteLine(string message)
        {
            File.AppendAllText(filePath, message + Environment.NewLine);
        }
    }
}
