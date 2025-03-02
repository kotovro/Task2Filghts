using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightsAircrafts.Models
{
    class Airplane : AbstratcAircraft
    {

        public override double CurrentHeight { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override bool Land()
        {
            throw new NotImplementedException();
        }

        public override bool Takeoff()
        {
            throw new NotImplementedException();
        }
    }
}
