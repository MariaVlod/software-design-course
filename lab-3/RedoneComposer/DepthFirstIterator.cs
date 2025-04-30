using System;
using System.Collections.Generic;

namespace RedoneComposer
{
    public class DepthFirstIterator : IDOMIterator
    {
        private readonly LightNode _root;
        private Stack<LightNode> _stack;
        private Dictionary<LightNode, int> _levels;
        private int _currentLevel;

        public int CurrentLevel => _currentLevel;

        public DepthFirstIterator(LightNode root)
        {
            _root = root;
            Reset();
        }

        public bool HasNext()
        {
            return _stack.Count > 0;
        }

        public LightNode Next()
        {
            if (!HasNext())
                throw new InvalidOperationException("No more elements");

            var current = _stack.Pop();
            _currentLevel = _levels[current];

            if (current is LightElementNode elementNode)
            {
                for (int i = elementNode.ChildNodes.Count - 1; i >= 0; i--)
                {
                    var child = elementNode.ChildNodes[i];
                    _stack.Push(child);
                    _levels[child] = _currentLevel + 1;
                }
            }

            return current;
        }

        public void Reset()
        {
            _stack = new Stack<LightNode>();
            _levels = new Dictionary<LightNode, int>();
            _currentLevel = 0;
            _stack.Push(_root);
            _levels[_root] = 0;
        }
    }
}