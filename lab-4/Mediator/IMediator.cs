using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    public interface IMediator
    {
        bool Notify(Aircraft aircraft, string eventType);
        bool Notify(Runway runway, string eventType);
    }
}
