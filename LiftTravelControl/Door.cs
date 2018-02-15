using LiftTravelControl.Events;
using System;
using System.Threading.Tasks;

namespace LiftTravelControl
{
    internal class Door : IDoor
    {
        public event EventHandler<DoorMovmentEventArgs> DoorEvent;

        public bool IsOpen { get; private set; }

        private ITimeConfiguration _timeConfig;

        public Door(ITimeConfiguration timeConfig)
        {
            _timeConfig = timeConfig;
        }

        public async Task RequestOpening()
        {
            if (!IsOpen)
            {
                Open();
                await RequestClosing();
            }
        }

        private void Open()
        {
            IsOpen = true;
            DoorEvent?.Invoke(this, new DoorMovmentEventArgs(IsOpen));
        }

        public async Task<bool> RequestClosing()
        {
            await Task.Delay(_timeConfig.InMillisecondSeconds);

            IsOpen = false;
            DoorEvent?.Invoke(this, new DoorMovmentEventArgs(IsOpen));
            return IsOpen;
        }

        public void SubscribeToDoorMovmentEvents(EventHandler<DoorMovmentEventArgs> delegateMethod)
        {
            DoorEvent += delegateMethod;
        }

        public void UnsubscribeToDoorMovmentEvents(EventHandler<DoorMovmentEventArgs> delegateMethod)
        {
            DoorEvent -= delegateMethod;
        }
    }
}
