using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedoneComposer
{
    public abstract class LightNode
    {
        public abstract string OuterHTML();
        public abstract string InnerHTML();

        public string Render()
        {
            OnCreated();
            string result = OuterHTML();
            OnRendered();
            return result;
        }
        protected virtual void OnCreated() { }
        protected virtual void OnInserted() { }
        protected virtual void OnRemoved() { }
        protected virtual void OnStylesApplied() { }
        protected virtual void OnClassListApplied() { }
        protected virtual void OnTextRendered() { }
        protected virtual void OnRendered() { }
    }
}
