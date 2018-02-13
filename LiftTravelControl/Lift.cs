using LiftTravelControl.Exceptions;
using LiftTravelControl.Extensions;
using System;

namespace LiftTravelControl
{
    internal class Lift : ILift
    {
        public int CurrentFloor { get; set; }
        public int MinFloor { get; set; }
        public int MaxFloor { get; set; }

        public Lift(int currentFloor, int lowestFloor, int highestFloor)
        {
            Initialize(currentFloor, lowestFloor, highestFloor);
        }

        private void Initialize(int currentFloor, int lowestFloor, int highestFloor)
        {
            if (lowestFloor >= highestFloor)
            {
                throw new ArgumentException("ground floor is higher than top floor");
            }

            if (!currentFloor.IsValidFloor(lowestFloor, highestFloor))
            {
                throw new UnknowFloorExecption(currentFloor);
            }

            CurrentFloor = currentFloor;
            MinFloor = lowestFloor;
            MaxFloor = highestFloor;
        }
    }
}
