using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedoneComposer
{
    internal interface INodeVisitor
    {
        void VisitElement(LightElementNode element);
        void VisitText(LightTextNode text);
        void VisitImage(LightImageNode image);  
    }


    internal class ElementCounterVisitor : INodeVisitor
    {
        public int ElementCount { get; private set; } = 0;
        public int TextCount { get; private set; } = 0;
        public int ImageCount { get; private set; } = 0;  

        public void VisitElement(LightElementNode element)
        {
            ElementCount++;
        }

        public void VisitText(LightTextNode text)
        {
            TextCount++;
        }

        public void VisitImage(LightImageNode image)
        {
            ImageCount++;  // Лічимо зображення
        }
    }

    internal class ClassCollectorVisitor : INodeVisitor
    {
        public HashSet<string> Classes { get; } = new HashSet<string>();

        public void VisitElement(LightElementNode element)
        {
            foreach (var cssClass in element.CssClassList)
            {
                Classes.Add(cssClass);
            }
        }

        public void VisitText(LightTextNode text)
        {
           
        }

        public void VisitImage(LightImageNode image)
        {
            
        }
    }

    internal class NodeRendererVisitor : INodeVisitor
    {
        public StringBuilder Output { get; } = new StringBuilder();

        public void VisitElement(LightElementNode element)
        {
            Output.AppendLine($"Рендеримо елемент <{element.TagName}> з класами: {string.Join(", ", element.CssClassList)}");
        }

        public void VisitText(LightTextNode text)
        {
            Output.AppendLine($"Рендеримо текст: '{text.TextContent}'");
        }

        public void VisitImage(LightImageNode image)
        {
            Output.AppendLine($"Рендеримо зображення: {image.OuterHTML()}");
        }
    }

}
