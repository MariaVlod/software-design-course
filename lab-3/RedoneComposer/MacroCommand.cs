using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedoneComposer
{
    internal class MacroCommand : ICommand
    {
        private readonly List<ICommand> _commands = new List<ICommand>();
        private readonly string _macroName;

        public MacroCommand(string macroName)
        {
            _macroName = macroName;
        }

        public void AddCommand(ICommand command)
        {
            _commands.Add(command);
        }

        public void Execute()
        {
            Console.WriteLine($"Виконуємо макрокоманду '{_macroName}' ({_commands.Count} підкоманд)");
            foreach (var command in _commands)
            {
                command.Execute();
            }
        }

        public void Undo()
        {
            Console.WriteLine($"Скасовуємо макрокоманду '{_macroName}'");
            for (int i = _commands.Count - 1; i >= 0; i--)
            {
                _commands[i].Undo();
            }
        }

        public void Redo()
        {
            Console.WriteLine($"Повторюємо макрокоманду '{_macroName}'");
            Execute();
        }
    }
}
