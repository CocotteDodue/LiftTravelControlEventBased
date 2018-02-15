namespace LiftTravelControl.Events
{
    public class DoorMovmentEventArgs
    {
        public bool HasClosed { get; set; }

        public DoorMovmentEventArgs(bool doorOpen)
        {
            HasClosed = !doorOpen;
        }
    }
}
