﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    public class SmartTextReader : IService
    {

        public char[][] ReadFile(string path)
        {
            string[] lines = File.ReadAllLines(path);
            char[][] result = new char[lines.Length][];

            for (int i = 0; i < lines.Length; i++)
            {
                result[i] = lines[i].ToCharArray();
            }

            return result;
        }
    }
}
