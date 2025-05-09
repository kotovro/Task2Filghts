using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightsAircrafts.Models
{
    public class Airplane : AbstractAircraft
    {
        public Airplane(string name, double detoriationLevel, double ceil, double verticalSpeed, double runwayLength, double landingLength, double fuelLevel) 
            : base(name, detoriationLevel, ceil, verticalSpeed)
        {
            RunwayLength = runwayLength;
            LandingLength = landingLength;
            FuelLevel = fuelLevel;
        }

        protected double FuelLevel { get; set; }
        private double RunwayLength  { get; set; }
        private double LandingLength { get; set; }

        public override bool Land(Airport airport)
        {
            if (LandingLength > airport.RunwayLength)
            {
                Error = AircraftConsts.ErrorCause.NotEnoughLandingLen;
                return false;
            }
            FlightDirection = AircraftConsts.Direction.None;
            return true;
        }

        //public override bool Takeoff(Airplane airplane)
        public override bool Takeoff(Airport airport)
        {
            var random = new Random();
            var probability = random.Next(101);
            if (probability <= CurrentDetoriationLevel)
            {
                Error = AircraftConsts.ErrorCause.Detoriation; ///got broken
                return false;
            }

            if (RunwayLength > airport.RunwayLength)
            {
                Error = AircraftConsts.ErrorCause.NotEnoughTakeoffLen;
                return false;
            }

            if (FuelLevel == 0)
            {
                Error = AircraftConsts.ErrorCause.LowFuel;
                return false;
            }
            FlightDirection = AircraftConsts.Direction.TakesOff;
            return true;
        }
    }
}
