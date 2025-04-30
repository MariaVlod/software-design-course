using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedoneComposer
{
    internal interface INodeState
    {
        void ApplyState(LightElementNode element);
        string GetStateName();
    }

    internal class VisibleState : INodeState
    {
        public void ApplyState(LightElementNode element)
        {
            element.CssClassList.Remove("hidden");
            element.CssClassList.Remove("highlighted");
        }

        public string GetStateName() => "visible";
    }

    internal class HiddenState : INodeState
    {
        public void ApplyState(LightElementNode element)
        {
            element.CssClassList.Remove("highlighted");
            element.CssClassList.Add("hidden");
        }

        public string GetStateName() => "hidden";
    }

    internal class HighlightedState : INodeState
    {
        public void ApplyState(LightElementNode element)
        {
            element.CssClassList.Remove("hidden");
            element.CssClassList.Add("highlighted");
        }

        public string GetStateName() => "highlighted";
    }
}
