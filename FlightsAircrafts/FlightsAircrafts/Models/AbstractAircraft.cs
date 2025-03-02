using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightsAircrafts.Models
{
    abstract class AbstratcAircraft
    {
        public abstract double CurrentHeight { get; set; }
        public abstract bool Takeoff();
        public abstract bool Land();

        public override string ToString()
        {
            return $"{CurrentHeight}";
        }
    }
}
