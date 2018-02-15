using LiftTravelControl.Pocos;

namespace LiftTravelControl.Interfaces
{
    public interface ILift
    {
        bool IsOpen { get; }
        int CurrentFloor { get; }
        bool StartTravel();
        void SummonCall(SummonInformation summonInfo);
        void RequestFloor(int requestedFloor);
    }
}
