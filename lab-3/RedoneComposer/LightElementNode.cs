using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedoneComposer
{
    internal class LightElementNode : LightNode
    {
        private INodeState _currentState;
        public string TagName { get; set; }
        public string DisplayType { get; set; }
        public bool IsSelfClosing { get; set; }
        public List<string> CssClassList { get; set; } = new List<string>();
        public List<LightNode> ChildNodes { get; set; } = new List<LightNode>();

        private EventManager _eventManager = new EventManager();

        public LightElementNode(string tagName, string displayType, bool isSelfClosing)
        {
            TagName = tagName;
            DisplayType = displayType;
            IsSelfClosing = isSelfClosing;
            _currentState = new VisibleState(); // стан за замовчуванням

        }
        public void SetState(INodeState state)
        {
            _currentState = state;
            _currentState.ApplyState(this);
            Console.WriteLine($"Елемент {TagName} переведено в стан: {_currentState.GetStateName()}");
        }

        public string GetCurrentState() => _currentState.GetStateName();
        public void AddChild(LightNode childNode)
        {
            ChildNodes.Add(childNode);
            if (childNode is LightElementNode elementNode)
            {
                elementNode.OnInserted();
            }
        }

        public void RemoveChild(LightNode childNode)
        {
            if (ChildNodes.Remove(childNode) && childNode is LightElementNode elementNode)
            {
                elementNode.OnRemoved();
            }
        }


        protected override void OnCreated()
        {
            Console.WriteLine($"Елемент {TagName} був створений");
        }

        protected override void OnInserted()
        {
            Console.WriteLine($"Елемент {TagName} був доданий до DOM");
        }

        protected override void OnRemoved()
        {
            Console.WriteLine($"Елемент {TagName} був видалений з DOM");
        }

        protected override void OnStylesApplied()
        {
            if (CssClassList.Count > 0)
            {
                Console.WriteLine($"Стилі були застосовані до елементу {TagName}");
            }
        }

        protected override void OnClassListApplied()
        {
            if (CssClassList.Count > 0)
            {
                Console.WriteLine($"Класи CSS були застосовані до елементу {TagName}");
            }
        }

        protected override void OnRendered()
        {
            Console.WriteLine($"Елемент {TagName} був відрендерений");
        }


        public IDOMIterator GetDepthFirstIterator()
        {
            return new DepthFirstIterator(this);
        }

        public IDOMIterator GetBreadthFirstIterator()
        {
            return new BreadthFirstIterator(this);
        }

        internal override void Accept(INodeVisitor visitor)
        {
            visitor.VisitElement(this);
            foreach (var child in ChildNodes)
            {
                child.Accept(visitor);
            }
        }


        public override string OuterHTML()
        {
            string htmlOutput = $"<{TagName}";

            if (CssClassList.Count > 0)
            {
                htmlOutput += " class=\"" + string.Join(" ", CssClassList) + "\"";
            }

            if (IsSelfClosing)
            {
                htmlOutput += " />";
            }
            else
            {
                htmlOutput += ">";
                htmlOutput += InnerHTML();
                htmlOutput += $"</{TagName}>";
            }

            return htmlOutput;
        }

        public override string InnerHTML()
        {
            string innerContent = string.Empty;

            foreach (var child in ChildNodes)
            {
                innerContent += child.OuterHTML();
            }

            return innerContent;
        }

        public void AddEventListener(string eventType, Action<LightElementNode> callback)
        {
            _eventManager.Subscribe(eventType, callback);
        }

        public void RemoveEventListener(string eventType, Action<LightElementNode> callback)
        {
            _eventManager.Unsubscribe(eventType, callback);
        }

        public void TriggerEvent(string eventType)
        {
            _eventManager.Notify(eventType, this);
        }
    }
}
