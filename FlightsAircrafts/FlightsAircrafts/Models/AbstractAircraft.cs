using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightsAircrafts.Models
{
    public abstract class AbstractAircraft
    {
    
        public AbstractAircraft(string name, double detoriationLevel, double ceil, double verticalSpeed)
        {
            Name = name;
            CurrentDetoriationLevel = detoriationLevel;
            Ceil = ceil;
            VerticalSpeed = verticalSpeed;
        }

        public event EventHandler<double>? HeightChanged;
        
        public double CurrentHeight { get; protected set; } = 0;
        public AircraftConsts.ErrorCause Error { get; protected set; } = AircraftConsts.ErrorCause.None;
        public string Name { get; private set; }
        public double CurrentDetoriationLevel { get; set; }
        protected double Ceil { get; private set; }
        protected double VerticalSpeed { get; private set; }
        public AircraftConsts.Direction FlightDirection { get; protected set; } = AircraftConsts.Direction.None;
        public abstract bool Takeoff(Airport airport);
        public abstract bool Land(Airport airport);
        public async void Flight()
        {
            if (FlightDirection == AircraftConsts.Direction.TakesOff)
            {
                while (CurrentHeight < Ceil - VerticalSpeed)
                {
                    CurrentHeight += VerticalSpeed;
                    HeightChanged?.Invoke(this, CurrentHeight);
                    await Task.Delay(250);
                }
                CurrentHeight = Ceil;
                HeightChanged?.Invoke(this, CurrentHeight);

                FlightDirection = AircraftConsts.Direction.Landing;

                await Task.Delay(250);
            }

            if (FlightDirection == AircraftConsts.Direction.Landing)
            {
                while (CurrentHeight > 0 + VerticalSpeed)
                {
                    CurrentHeight -= VerticalSpeed;
                    HeightChanged?.Invoke(this, CurrentHeight);
                    await Task.Delay(250);
                }
                CurrentHeight = 0;
                FlightDirection = AircraftConsts.Direction.None;
                HeightChanged?.Invoke(this, CurrentHeight);
            }
        }

        public override string ToString()
        {
            return $"Current height is:  {CurrentHeight} \n Cuerrent detoriation level: {CurrentDetoriationLevel}" ;
        }
    }
}
