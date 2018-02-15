namespace LiftTravelControl.Tests.Dummies
{
    internal class DummyDoor : Door
    {
        public DummyDoor() : base(new TimeConfigurationNoDelayDummyForTest())
        { }

        public void InvokeDoorMovmentEvent (bool doorClosed)
        {
            if (doorClosed)
            {
                Close();
            }
            else
            {
                Open();
            }
        }
    }
}
