using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    class DocumentMemento : IDocumentMemento
    {
        public TextDocument DocumentSnapshot { get; }
        public DateTime CreationDate { get; }
        public string Description { get; }

        public DocumentMemento(TextDocument document, string description)
        {
            DocumentSnapshot = new TextDocument(document.Title, document.Content);
            CreationDate = DateTime.Now;
            Description = description;
            Thread.Sleep(1000); 
        }
    }
}
