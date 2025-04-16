using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    public class TextDocument
    {
        public string Content { get; set; }
        public string Title { get; set; }

        public TextDocument(string title, string content)
        {
            Title = title;
            Content = content;
        }

        public override string ToString() => $"{Title}\n{Content}";
    }
}
