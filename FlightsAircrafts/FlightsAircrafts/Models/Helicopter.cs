using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightsAircrafts.Models
{
    class Helicopter : AbstractAircraft
    {
        public Helicopter(string name, double detoriationLevel, double ceil, double verticalSpeed, double fuelLevel)
            : base(name, detoriationLevel, ceil, verticalSpeed)
        {
            FuelLevel = fuelLevel; 
        }

        public double FuelLevel { get; private set; }


        public override bool Land(Airport airport)
        {
            throw new NotImplementedException();
        }

        public override bool Takeoff(Airport airport)
        {
            throw new NotImplementedException();
        }
    }
}
