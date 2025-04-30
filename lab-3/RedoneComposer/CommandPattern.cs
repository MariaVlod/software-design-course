using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RedoneComposer
{
    public interface ICommand
    {
        void Execute();
        void Undo();
        void Redo();
    }

    internal class AddChildCommand : ICommand
    {
        private readonly LightElementNode _parent;
        private readonly LightNode _child;
        private bool _isExecuted = false;

        public AddChildCommand(LightElementNode parent, LightNode child)
        {
            _parent = parent;
            _child = child;
        }

        public void Execute()
        {
            if (!_isExecuted)
            {
                _parent.AddChild(_child);
                _isExecuted = true;
            }
        }

        public void Undo()
        {
            if (_isExecuted)
            {
                _parent.RemoveChild(_child);
                _isExecuted = false;
            }
        }

        public void Redo()
        {
            if (!_isExecuted)
            {
                _parent.AddChild(_child);
                _isExecuted = true;
            }
        }
    }

    internal class RemoveChildCommand : ICommand
    {
        private readonly LightElementNode _parent;
        private readonly LightNode _child;
        private bool _isExecuted = false;
        private int _originalIndex = -1;

        public RemoveChildCommand(LightElementNode parent, LightNode child)
        {
            _parent = parent;
            _child = child;
        }

        public void Execute()
        {
            if (!_isExecuted)
            {
                _originalIndex = _parent.ChildNodes.IndexOf(_child);
                if (_originalIndex >= 0)
                {
                    _parent.RemoveChild(_child);
                    _isExecuted = true;
                }
            }
        }

        public void Undo()
        {
            if (_isExecuted && _originalIndex >= 0)
            {
                if (_originalIndex <= _parent.ChildNodes.Count)
                {
                    _parent.ChildNodes.Insert(_originalIndex, _child);
                }
                else
                {
                    _parent.AddChild(_child);
                }
                _isExecuted = false;
            }
        }

        public void Redo()
        {
            if (!_isExecuted)
            {
                Execute(); // Повторно виконуємо видалення
            }
        }
    }

    public class CommandHistory
    {
        private readonly Stack<ICommand> _undoStack = new Stack<ICommand>();
        private readonly Stack<ICommand> _redoStack = new Stack<ICommand>();

        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
            _undoStack.Push(command);
            _redoStack.Clear();
        }

        public void Undo()
        {
            if (_undoStack.Count > 0)
            {
                var command = _undoStack.Pop();
                command.Undo();
                _redoStack.Push(command);
            }
        }

        public void Redo()
        {
            if (_redoStack.Count > 0)
            {
                var command = _redoStack.Pop();
                command.Redo();
                _undoStack.Push(command);
            }
        }
    }
}
