using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedoneComposer
{
    public interface IImageLoadingStrategy
    {
        void LoadImage(string href);
        string GetLoadingInfo();
    }
}
