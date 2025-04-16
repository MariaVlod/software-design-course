using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedoneComposer
{
    internal class LightImageNode : LightNode
    {
        private string _href;
        private IImageLoadingStrategy _loadingStrategy;

        public LightImageNode(string href)
        {
            _href = href;
            SetLoadingStrategyBasedOnHref();
        }

        private void SetLoadingStrategyBasedOnHref()
        {
            if (_href.StartsWith("http://") || _href.StartsWith("https://"))
            {
                _loadingStrategy = new NetworkImageLoadingStrategy();
            }
            else
            {
                _loadingStrategy = new FileImageLoadingStrategy();
            }
        }

        public void LoadImage()
        {
            _loadingStrategy.LoadImage(_href);
        }

        public string GetLoadingInfo()
        {
            return _loadingStrategy.GetLoadingInfo();
        }

        public override string OuterHTML()
        {
            return $"<img src=\"{_href}\" alt=\"Image\">";
        }

        public override string InnerHTML()
        {
            return string.Empty;
        }
    }
}
