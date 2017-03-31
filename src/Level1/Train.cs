using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Level1
{
    public class Vehicle
    {
        public double Speed { get; private set; }

        public Vehicle(double speed)
        {
            Speed = speed;
        }
    }
}
