using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedoneComposer
{
    internal class LightTextNode : LightNode
    {
        public string TextContent { get; set; }

        public LightTextNode(string text)
        {
            TextContent = text;
        }

        protected override void OnCreated()
        {
            Console.WriteLine("Текстовий вузол був створений");
        }

        protected override void OnTextRendered()
        {
            Console.WriteLine($"Текст '{TextContent}' був відрендерений");
        }
        internal override void Accept(INodeVisitor visitor)
        {
            visitor.VisitText(this);
        }

        public override string OuterHTML()
        {
            OnTextRendered();
            return TextContent;
        }

        public override string InnerHTML()
        {
            return TextContent;
        }
    }
}
