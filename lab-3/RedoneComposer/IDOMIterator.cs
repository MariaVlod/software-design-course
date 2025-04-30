using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedoneComposer
{
    public interface IDOMIterator
    {
        bool HasNext();
        LightNode Next();
        void Reset();
        int CurrentLevel { get; } 
    }

}
