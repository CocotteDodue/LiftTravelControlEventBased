using System;
using System.Collections.Generic;
using System.Text;

namespace LiftTravelControl
{
    internal class Lift : ILift
    {
        public int CurrentFloor { get; set; }
        public int MinFloor { get; set; }
        public int MaxFloor { get; set; }

        public Lift(int currentFloor, int lowestFloor, int highestFloor)
        {
            CurrentFloor = currentFloor;
            MinFloor = lowestFloor;
            MaxFloor = highestFloor;
        }
    }
}
