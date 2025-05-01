using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedoneComposer
{
    internal class HtmlValidationVisitor : INodeVisitor
    {
        private readonly Stack<LightElementNode> _elementStack = new Stack<LightElementNode>();
        private readonly List<string> _errors = new List<string>();

        public IReadOnlyList<string> Errors => _errors;

        public void VisitElement(LightElementNode element)
        {
            ValidateElement(element);
            _elementStack.Push(element);
        }

        public void VisitText(LightTextNode text)
        {
            // Текстові вузли не потребують валідації
        }

        public void VisitImage(LightImageNode image)
        {
            // Зображення не потребують валідації
        }

        private void ValidateElement(LightElementNode element)
        {
            if (_elementStack.Count > 0)
            {
                var parent = _elementStack.Peek();
                ValidateParentChildRelation(parent, element);
            }

            ValidateElementSpecificRules(element);
        }

        private void ValidateParentChildRelation(LightElementNode parent, LightElementNode child)
        {
            switch (child.TagName.ToLower())
            {
                case "li":
                    if (parent.TagName.ToLower() != "ul" && parent.TagName.ToLower() != "ol")
                    {
                        _errors.Add($"Помилка: <li> може бути тільки всередині <ul> або <ol> (знайдено всередині <{parent.TagName}>)");
                    }
                    break;

                case "tr":
                    if (parent.TagName.ToLower() != "table")
                    {
                        _errors.Add($"Помилка: <tr> може бути тільки всередині <table> (знайдено всередині <{parent.TagName}>)");
                    }
                    break;

                case "th":
                case "td":
                    if (parent.TagName.ToLower() != "tr")
                    {
                        _errors.Add($"Помилка: <{child.TagName}> може бути тільки всередині <tr> (знайдено всередині <{parent.TagName}>)");
                    }
                    break;
            }
        }

        private void ValidateElementSpecificRules(LightElementNode element)
        {
            switch (element.TagName.ToLower())
            {
                case "a":
                    if (!element.ChildNodes.Exists(n => n is LightTextNode))
                    {
                        _errors.Add($"Попередження: <a> повинен містити текстовий вміст");
                    }
                    break;

                case "ul":
                case "ol":
                    if (!element.ChildNodes.Exists(n => n is LightElementNode && ((LightElementNode)n).TagName.ToLower() == "li"))
                    {
                        _errors.Add($"Попередження: <{element.TagName}> повинен містити хоча б один <li>");
                    }
                    break;

                case "table":
                    bool hasHeader = element.ChildNodes.Exists(n =>
                        n is LightElementNode &&
                        ((LightElementNode)n).TagName.ToLower() == "tr" &&
                        ((LightElementNode)n).ChildNodes.Exists(c =>
                            c is LightElementNode &&
                            ((LightElementNode)c).TagName.ToLower() == "th"));

                    if (!hasHeader)
                    {
                        _errors.Add($"Попередження: <table> рекомендується мати заголовок (<th>)");
                    }
                    break;
            }
        }

        public void AfterVisit()
        {
            _elementStack.Clear();
        }
    }
}
