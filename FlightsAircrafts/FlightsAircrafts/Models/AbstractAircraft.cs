using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightsAircrafts.Models
{
    abstract class AbstratcAircraft
    {
        public static class DetoriationLevel
        {
            public const double HIGH = 100.0;
            public const double MEDIUM = 65.0;
            public const double LOW = 30.0;
        }

        public abstract double CurrentHeight { get; set; }
        protected abstract double CurrentDetoriationLevel { get; set; }
        public abstract bool Takeoff();
        public abstract bool Land();

        public override string ToString()
        {
            return $"Current height is:  {CurrentHeight} \n Cueerent detoriation level: {CurrentDetoriationLevel}" ;
        }
    }
}
