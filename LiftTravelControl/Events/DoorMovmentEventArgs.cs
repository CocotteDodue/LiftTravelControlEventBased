namespace LiftTravelControl.Events
{
    public class DoorMovmentEventArgs
    {
        public bool IsOpen { get; set; }

        public DoorMovmentEventArgs(bool doorOpen)
        {
            IsOpen = doorOpen;
        }
    }
}
