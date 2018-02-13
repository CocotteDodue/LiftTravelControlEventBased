using System;
using System.Collections.Generic;
using System.Text;

namespace LiftTravelControl
{
    public interface ILift
    {
        int CurrentFloor { get; set; }
        int MinFloor { get; set; }
        int MaxFloor { get; set; }
    }
}
