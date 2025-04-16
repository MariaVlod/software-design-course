using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    public class CommandCentre : IMediator
    {
        private List<Runway> _runways = new List<Runway>();
        private List<Aircraft> _aircrafts = new List<Aircraft>();

        public CommandCentre(Runway[] runways, Aircraft[] aircrafts)
        {
            this._runways.AddRange(runways);
            this._aircrafts.AddRange(aircrafts);
        }

        public bool Notify(Aircraft aircraft, string eventType)
        {
            if (eventType == "Land")
            {
                foreach (var runway in _runways)
                {
                    if (runway.IsBusyWithAircraft == null)
                    {
                        runway.IsBusyWithAircraft = aircraft;
                        runway.HighLightRed();
                        return true;
                    }
                }
                return false;
            }
            else if (eventType == "TakeOff")
            {
                foreach (var runway in _runways)
                {
                    if (runway.IsBusyWithAircraft == aircraft)
                    {
                        runway.IsBusyWithAircraft = null;
                        runway.HighLightGreen();
                        return true;
                    }
                }
                return false;
            }
            return false;
        }

        public bool Notify(Runway runway, string eventType)
        {
            return false;
        }
    }
}
