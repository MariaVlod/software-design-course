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

        public override string OuterHTML()
        {
            return TextContent;
        }

        public override string InnerHTML()
        {
            return TextContent;
        }
    }
}
