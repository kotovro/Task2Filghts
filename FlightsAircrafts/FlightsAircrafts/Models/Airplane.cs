using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightsAircrafts.Models
{
    class Airplane : AbstratcAircraft
    {
        public Airplane(double fuelLevel, double detoriationLevel, double runwayLength)
        {
            RunwayLength = runwayLength;
            FuelLevel = fuelLevel;
            CurrentDetoriationLevel = detoriationLevel; 
        }

        protected override double CurrentDetoriationLevel { get; set; }
        protected double FuelLevel { get; set; }
        private double RunwayLength  { get; set; }
        public override double CurrentHeight { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override bool Land()
        {
            throw new NotImplementedException();
        }

        public override bool Takeoff()
        {
            Random random = new Random();
            double probability = random.NextDouble();
            ///add DetoriationLevelEnum
            if (FuelLevel > 0)
            {
                if (CurrentDetoriationLevel <= DetoriationLevel.LOW)
                {
                    return true;
                }
                if (CurrentDetoriationLevel > DetoriationLevel.LOW && CurrentDetoriationLevel <= DetoriationLevel.MEDIUM)
                {
                    if (probability > 0.4)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                if (CurrentDetoriationLevel > DetoriationLevel.MEDIUM && CurrentDetoriationLevel <= DetoriationLevel.HIGH)
                {
                    if (probability > 0.8)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                if (CurrentDetoriationLevel > DetoriationLevel.HIGH)
                {
                    if (probability > 0.95)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }
    }
}
