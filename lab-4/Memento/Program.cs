using Memento;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        var document = new TextDocument("Мій документ", "Початковий вміст документу.");
        var editor = new TextEditor(document);

        editor.PrintDocument();

        editor.EditContent("Перша редакція тексту.", "Додано новий текст");
        editor.EditTitle("Оновлений документ", "Зміна назви");
        editor.EditContent("Друга редакція тексту.", "Оновлення змісту");

        editor.PrintHistory();

       
        editor.Undo(); 
        editor.Undo(); 
        editor.Undo();
    }
}