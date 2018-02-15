using LiftTravelControl.Events;
using System;
using System.Threading.Tasks;

namespace LiftTravelControl
{
    public interface IDoor
    {
        bool IsOpen { get; }
        Task RequestOpening();
        Task<bool> RequestClosing();
        void SubscribeToDoorMovmentEvents(EventHandler<DoorMovmentEventArgs> delegateMethod);
        void UnsubscribeToDoorMovmentEvents(EventHandler<DoorMovmentEventArgs> delegateMethod);
    }
}
