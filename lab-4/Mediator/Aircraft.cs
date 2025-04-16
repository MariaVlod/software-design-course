using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    public class Aircraft
    {
        public string Name { get; }
        public bool IsTakingOff { get; set; }
        private IMediator _mediator;

        public Aircraft(string name, IMediator mediator)
        {
            this.Name = name;
            this._mediator = mediator;
        }

        public void Land()
        {
            Console.WriteLine($"Aircraft {this.Name} is requesting to land.");
            if (_mediator.Notify(this, "Land"))
            {
                Console.WriteLine($"Aircraft {this.Name} has successfully landed.");
            }
            else
            {
                Console.WriteLine($"Aircraft {this.Name} could not land, all runways are busy.");
            }
        }

        public void TakeOff()
        {
            Console.WriteLine($"Aircraft {this.Name} is requesting to take off.");
            if (_mediator.Notify(this, "TakeOff"))
            {
                Console.WriteLine($"Aircraft {this.Name} has successfully took off.");
            }
            else
            {
                Console.WriteLine($"Aircraft {this.Name} could not take off.");
            }
        }
    }
}
