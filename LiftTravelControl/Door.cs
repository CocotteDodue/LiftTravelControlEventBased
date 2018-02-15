using LiftTravelControl.Events;
using LiftTravelControl.Interfaces;
using LiftTravelControl.Poco;
using System;
using System.Threading.Tasks;

namespace LiftTravelControl
{
    internal class Door : IDoor
    {
        public virtual event EventHandler<DoorMovmentEventArgs> DoorEvent;
        public bool IsOpen { get; private set; }

        private TimeConfiguration _timeConfig;

        public Door(TimeConfiguration timeConfig)
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

        protected void Open()
        {
            IsOpen = true;
            DoorEvent?.Invoke(this, new DoorMovmentEventArgs(IsOpen));
        }

        public async Task<bool> RequestClosing()
        {
            await Task.Delay(_timeConfig.InMillisecondSeconds);
            Close();
            return IsOpen;
        }

        protected void Close()
        {
            IsOpen = false;
            DoorEvent?.Invoke(this, new DoorMovmentEventArgs(IsOpen));
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
