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
            FlightDirection = AircraftConsts.Direction.None;
            return true;
        }

        public override bool Takeoff(Airport airport)
        {
            var random = new Random();
            var probability = random.Next(101);
            if (probability <= CurrentDetoriationLevel)
            {
                Error = AircraftConsts.ErrorCause.Detoriation; ///got broken
                return false;
            }

            FlightDirection = AircraftConsts.Direction.TakesOff;
            return true;
        }
    }
}
