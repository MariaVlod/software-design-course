using System;
using System.Collections.Generic;

namespace RedoneComposer
{
    public class BreadthFirstIterator : IDOMIterator
    {
        private readonly LightNode _root;
        private Queue<LightNode> _queue;
        private Dictionary<LightNode, int> _levels;
        private int _currentLevel;

        public int CurrentLevel => _currentLevel;

        public BreadthFirstIterator(LightNode root)
        {
            _root = root;
            Reset();
        }

        public bool HasNext()
        {
            return _queue.Count > 0;
        }

        public LightNode Next()
        {
            if (!HasNext())
                throw new InvalidOperationException("No more elements");

            var node = _queue.Dequeue();
            _currentLevel = _levels[node];
            return node;
        }

        public void Reset()
        {
            _queue = new Queue<LightNode>();
            _levels = new Dictionary<LightNode, int>();
            _currentLevel = 0;

            var tempQueue = new Queue<(LightNode node, int level)>();
            tempQueue.Enqueue((_root, 0));

            while (tempQueue.Count > 0)
            {
                var (currentNode, currentLevel) = tempQueue.Dequeue();

                _queue.Enqueue(currentNode);
                _levels[currentNode] = currentLevel;

                if (currentNode is LightElementNode elementNode)
                {
                    foreach (var child in elementNode.ChildNodes)
                    {
                        if (child is LightTextNode)
                        {
                            tempQueue.Enqueue((child, currentLevel + 1));
                        }
                    }

                   
                    foreach (var child in elementNode.ChildNodes)
                    {
                        if (child is LightElementNode)
                        {
                            tempQueue.Enqueue((child, currentLevel + 1));
                        }
                    }
                }
            }
        }
    }
}