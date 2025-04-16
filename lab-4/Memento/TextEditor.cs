using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    public class TextEditor
    {
        private TextDocument _currentDocument;
        private readonly Stack<IDocumentMemento> _history = new Stack<IDocumentMemento>();
        private int _version = 1;

        public TextEditor(TextDocument initialDocument)
        {
            _currentDocument = initialDocument;
            Save("Початкова версія");
        }

        public void EditContent(string newContent, string changeDescription = "")
        {
            _currentDocument.Content = newContent;
            Save($"Зміна вмісту: {changeDescription}");
        }

        public void EditTitle(string newTitle, string changeDescription = "")
        {
            _currentDocument.Title = newTitle;
            Save($"Зміна заголовка: {changeDescription}");
        }

        private void Save(string description)
        {
            _history.Push(new DocumentMemento(_currentDocument, $"{_version++}: {description}"));
            Console.WriteLine($"Збережено версію: {_history.Peek().Description} ({_history.Peek().CreationDate:T})");
        }

        public void Undo()
        {
            if (_history.Count <= 1) return;

            var lastState = _history.Pop();
            var previousState = _history.Peek();

            _currentDocument.Content = ((DocumentMemento)previousState).DocumentSnapshot.Content;
            _currentDocument.Title = ((DocumentMemento)previousState).DocumentSnapshot.Title;

            Console.WriteLine($"\nВідновлено версію: {previousState.Description}");
            PrintDocument();
        }

        public void PrintDocument()
        {
            Console.WriteLine("Поточний документ:");
            Console.WriteLine(_currentDocument);
            Console.WriteLine($"Час останньої зміни: {_history.Peek().CreationDate:T}\n");
        }

        public void PrintHistory()
        {
            Console.WriteLine("\nІсторія змін:");
            foreach (var memento in _history)
            {
                Console.WriteLine($"- {memento.Description} ({memento.CreationDate:T})");
            }
        }
    }
}
