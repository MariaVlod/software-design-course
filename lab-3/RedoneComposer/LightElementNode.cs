using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedoneComposer
{
    internal class LightElementNode : LightNode
    {
        public string TagName { get; set; }
        public string DisplayType { get; set; }
        public bool IsSelfClosing { get; set; }
        public List<string> CssClassList { get; set; } = new List<string>();
        public List<LightNode> ChildNodes { get; set; } = new List<LightNode>();

        public LightElementNode(string tagName, string displayType, bool isSelfClosing)
        {
            TagName = tagName;
            DisplayType = displayType;
            IsSelfClosing = isSelfClosing;
        }

        public void AddChild(LightNode childNode)
        {
            ChildNodes.Add(childNode);
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
    }
}
