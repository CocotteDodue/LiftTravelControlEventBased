using LiftTravelControl.Interfaces;
using LiftTravelControl.Pocos;
using System;
using LiftTravelControl.Events;

namespace LiftTravelControl
{
    internal class Lift : ILift, IDisposable
    {
        public bool IsOpen => _door.IsOpen;

        private FloorConfiguration _floorConfig;
        private IDoor _door;
        
        public Lift(FloorConfiguration floorConfiguration, IDoor door)
        {
            Initialize(floorConfiguration, door);
        }

        internal void Initialize(FloorConfiguration floorConfiguration, IDoor door)
        {
            _floorConfig = floorConfiguration;
            _door = door;

            SuscribeEvents();
        }

        public void Dispose()
        {
            UnsuscribeEvents();
        }

        private void SuscribeEvents()
        {
            _door.SubscribeToDoorMovmentEvents(OnDoorMovment);
        }

        private void UnsuscribeEvents()
        {
            _door.UnsubscribeToDoorMovmentEvents(OnDoorMovment);
        }

        private void OnDoorMovment(object sender, DoorMovmentEventArgs e)
        {
            if (e == null)
            {
                return;
            }

            if (e.HasClosed)
            {
                StartTravel();
            }
        }

        public int CurrentFloor => _floorConfig.CurrentFloor;

        public virtual bool StartTravel()
        {
            bool travelStarted = !_door.IsOpen;
            return travelStarted;
        }

        public void SummonCall(SummonInformation summonInfo)
        {
            _door.RequestOpening();
        }

        public void RequestFloor(int requestedFloor)
        { }

    }
}
